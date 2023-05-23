﻿using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Quick.Onvif.PTZ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick.Onvif.TestUI
{
    public partial class MainForm : Form
    {
        private OnvifClient client;
        private Media.MediaClient mediaClient;
        private PTZ.PTZClient ptzClient;
        private LibVLC libVLC = new LibVLC();

        public MainForm(OnvifClient client)
        {
            this.client = client;
            mediaClient = new Media.MediaClient(client);
            ptzClient = new PTZ.PTZClient(client);
            InitializeComponent();

            Text = $"{client.DeviceInformation.Manufacturer} - {client.DeviceInformation.Model} - {client.DeviceServiceAddressUri}";
            odcDeviceInformation.FirstValueAsyncFunc = () => Task.FromResult<object>(client.DeviceInformation);
            odcDeviceCapabilities.FirstValueAsyncFunc = () => Task.FromResult<object>(client.Capabilities);
            odcNetworkInterfaces.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkInterfacesAsync();
            odcNetworkProtocols.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkProtocolsAsync();
            odcNetworkDefaultGateway.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkDefaultGatewayAsync();
            odcDNS.RefreshAsyncFunc = async () => await client.DeviceClient.GetDNSAsync();
            odcMediaVideoSourceConfigurations.RefreshAsyncFunc = async () => await mediaClient.GetVideoSourceConfigurationsAsync();
            odcMediaVideoSources.RefreshAsyncFunc = async () => await mediaClient.GetVideoSourcesAsync();
            odcMediaProfiles.RefreshAsyncFunc = async () => await mediaClient.GetProfilesAsync();
        }

        private async void tpPreview_Enter(object sender, EventArgs e)
        {
            if (cbProfiles.Items.Count == 0)
            {
                scPreview.Enabled = false;
                var rep = await mediaClient.GetProfilesAsync();
                var profiles = rep.Profiles;
                foreach (var profile in profiles)
                {
                    cbProfiles.Items.Add(profile);
                }
                cbProfiles.SelectedIndex = 0;
                scPreview.Enabled = true;
            }
        }
        private Media.Profile currentProfile;
        private void cbProfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            currentProfile = (Media.Profile)cbProfiles.SelectedItem;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"token: {currentProfile.token}");
            sb.AppendLine($"Name: {currentProfile.Name}");
            sb.AppendLine($"VideoEncoderConfiguration:");
            sb.AppendLine($"    Name: {currentProfile.VideoEncoderConfiguration.Name}");
            sb.AppendLine($"    ViewMode: {currentProfile.VideoEncoderConfiguration.Encoding}");
            sb.AppendLine($"    Resolution: {currentProfile.VideoEncoderConfiguration.Resolution.Width} * {currentProfile.VideoEncoderConfiguration.Resolution.Height}");
            sb.AppendLine($"    Quality: {currentProfile.VideoEncoderConfiguration.Quality}");
            sb.AppendLine($"    RateControl:");
            sb.AppendLine($"        FrameRateLimit: {currentProfile.VideoEncoderConfiguration.RateControl.FrameRateLimit}");
            sb.AppendLine($"        EncodingInterval: {currentProfile.VideoEncoderConfiguration.RateControl.EncodingInterval}");
            sb.AppendLine($"        BitrateLimit: {currentProfile.VideoEncoderConfiguration.RateControl.BitrateLimit}");
            txtPreviewProfileInfo.Text = sb.ToString();
            gbPreviewPTZ.Visible = currentProfile.PTZConfiguration != null;
        }

        private async void btnPreviewSnapshot_Click(object sender, EventArgs e)
        {
            try
            {
                scPreview.Panel2.Controls.Clear();
                scPreview.Enabled = false;
                var rep = await mediaClient.GetSnapshotUriAsync(currentProfile.token);
                var snapshotUri = rep.Uri;
                snapshotUri = client.CorrectUri(snapshotUri);
                //if override snapshot port 
                if (client.Options.SnapshotPort > 0)
                {
                    var uriBuilder = new UriBuilder(snapshotUri);
                    uriBuilder.Port = client.Options.SnapshotPort;
                    snapshotUri = uriBuilder.Uri.ToString();
                }
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.UseDefaultCredentials = true;
                httpClientHandler.Credentials = new NetworkCredential(client.Options.UserName, client.Options.Password);
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var snapshotStream = await httpClient.GetStreamAsync(snapshotUri))
                    {
                        var image = Image.FromStream(snapshotStream);
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = image;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        scPreview.Panel2.Controls.Add(pictureBox);
                        pictureBox.Dock = DockStyle.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                scPreview.Panel2.Controls.Clear();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                scPreview.Enabled = true;
            }
        }

        private async void btnPreviewLive_Click(object sender, EventArgs e)
        {
            try
            {
                scPreview.Panel2.Controls.Clear();
                scPreview.Enabled = false;

                var rep = await mediaClient.GetStreamUriAsync(new Media.StreamSetup()
                {
                    Stream = Media.StreamType.RTPUnicast,
                    Transport = new Media.Transport()
                    {
                        Protocol = Media.TransportProtocol.RTSP
                    }
                }, currentProfile.token);
                var streamUri = rep.Uri;
                streamUri = client.CorrectUri(streamUri);
                var uriBuilder = new UriBuilder(streamUri);
                uriBuilder.UserName = client.Options.UserName;
                uriBuilder.Password = client.Options.Password;
                if (client.Options.RtspPort > 0)
                    uriBuilder.Port = client.Options.RtspPort;
                streamUri = uriBuilder.Uri.ToString();

                var videoView = new VideoView()
                {
                    Dock = DockStyle.Fill,
                    MediaPlayer = new MediaPlayer(libVLC)
                };
                videoView.MediaPlayer.Media = new LibVLCSharp.Shared.Media(libVLC, streamUri, FromType.FromLocation);
                scPreview.Panel2.Controls.Add(videoView);
                videoView.MediaPlayer.Play();
                videoView.MediaPlayer.EncounteredError += MediaPlayer_EncounteredError;
            }
            catch (Exception ex)
            {
                scPreview.Panel2.Controls.Clear();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                scPreview.Enabled = true;
            }
        }

        private void MediaPlayer_EncounteredError(object sender, EventArgs e)
        {
            Invoke(() =>
            {
                MessageBox.Show("MediaPlayer_EncounteredError", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
        }
        private const float PTZ_MOVE_SPEED = 0.2f;
        private async Task ptzContinuousMove(float x, float y, float zoom)
        {
            try
            {
                await ptzClient.ContinuousMoveAsync(currentProfile.token, new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = x,
                        y = y
                    },
                    Zoom = new Vector1D()
                    {
                        x = zoom
                    }
                }, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPtzAny_MouseUp(object sender, MouseEventArgs e)
        {
            _ = ptzContinuousMove(0, 0, 0);
        }

        private void btnPtzUp_MouseDown(object sender, MouseEventArgs e)
        {
            _ = ptzContinuousMove(0, PTZ_MOVE_SPEED, 0);
        }


        private void btnPtzDown_MouseDown(object sender, MouseEventArgs e)
        {
            _ = ptzContinuousMove(0, 0 - PTZ_MOVE_SPEED, 0);
        }

        private void btnPtzLeft_MouseDown(object sender, MouseEventArgs e)
        {
            _ = ptzContinuousMove(0 - PTZ_MOVE_SPEED, 0, 0);
        }

        private void btnPtzRight_MouseDown(object sender, MouseEventArgs e)
        {
            _ = ptzContinuousMove(PTZ_MOVE_SPEED, 0, 0);
        }

        private void btnPtzZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            _ = ptzContinuousMove(0, 0, PTZ_MOVE_SPEED);
        }

        private void btnPtzZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            _ = ptzContinuousMove(0, 0, 0 - PTZ_MOVE_SPEED);
        }
    }
}
