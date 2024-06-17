using QuickNV.Onvif.Factorys;

using System.Xml;

namespace QuickNV.Onvif
{
    public class OnvifClient
    {
        public OnvifClientOptions Options { get; private set; }
        public Device.GetDeviceInformationResponse DeviceInformation { get; private set; }
        public Device.Capabilities Capabilities { get; private set; }
        public Device.DeviceClient DeviceClient { get; private set; }
        public ClientFactory ClientFactory { get; private set; }
        public OnvifClient(OnvifClientOptions options)
        {
            this.Options = options;
        }

        public string CorrectUri(string addr, bool includePort = true)
        {
            var uriBuilder = new UriBuilder(addr);
            if (uriBuilder.Host != Options.Host)
                uriBuilder.Host = Options.Host;
            if (includePort && uriBuilder.Port != Options.Port)
                uriBuilder.Port = Options.Port;
            return uriBuilder.Uri.ToString();
        }

        private void HandleCapabilitiesItem<T>(T t, Func<T, string> getter, Action<T, string> setter)
            where T : class, new()
        {
            if (t == null)
                return;
            var v = getter(t);
            if (!string.IsNullOrEmpty(v))
                setter(t, CorrectUri(v));
        }

        private T HandleCapabilitiesExtensionItem<T>(T t, string propertyName, Action<T, string> setter)
            where T : class, new()
        {
            if (t == null)
            {
                var tmp = GetExtensionXAddr(propertyName);
                if (string.IsNullOrEmpty(tmp))
                    return null;
                t = new T();
                setter(t, tmp);
            }
            return t;
        }

        public async Task ConnectAsync()
        {
            ClientFactory = ClientFactory.GetClientFactory(
                Options.Scheme,
                Options.UserName,
                Options.Password,
                Options.ClientCredentialType);
            var deviceClientUriBuilder = new UriBuilder();
            deviceClientUriBuilder.Scheme = Options.Scheme;
            deviceClientUriBuilder.Host = Options.Host;
            deviceClientUriBuilder.Port = Options.Port;
            deviceClientUriBuilder.Path = "/onvif/device_service";
            var deviceClientUri = deviceClientUriBuilder.Uri.ToString();
            DeviceClient = new Device.DeviceClient(ClientFactory, deviceClientUri);
            //Get Device Information
            DeviceInformation = await DeviceClient.GetDeviceInformationAsync(new Device.GetDeviceInformationRequest());
            //Get Capabilities
            {
                var rep = await DeviceClient.GetCapabilitiesAsync(new Device.CapabilityCategory[]
                {
                  Device.CapabilityCategory.All
                });
                Capabilities = rep.Capabilities;
                HandleCapabilitiesItem(Capabilities.Analytics, t => t.XAddr, (t, v) => t.XAddr = v);
                HandleCapabilitiesItem(Capabilities.Device, t => t.XAddr, (t, v) => t.XAddr = v);
                HandleCapabilitiesItem(Capabilities.Events, t => t.XAddr, (t, v) => t.XAddr = v);
                HandleCapabilitiesItem(Capabilities.Imaging, t => t.XAddr, (t, v) => t.XAddr = v);
                HandleCapabilitiesItem(Capabilities.Media, t => t.XAddr, (t, v) => t.XAddr = v);
                HandleCapabilitiesItem(Capabilities.PTZ, t => t.XAddr, (t, v) => t.XAddr = v);

                if (Capabilities.Extension.Any != null)
                {
                    foreach (var element in Capabilities.Extension.Any)
                    {
                        if (element == null)
                        {
                            continue;
                        }
                        foreach (var child in element.ChildNodes)
                        {
                            if (child is not XmlElement elXAddr)
                                continue;
                            if (elXAddr.LocalName != "XAddr")
                                continue;
                            if (!string.IsNullOrEmpty(elXAddr.InnerText))
                                elXAddr.InnerText = CorrectUri(elXAddr.InnerText);
                        }
                    }
                }

                Capabilities.Extension.AnalyticsDevice =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.AnalyticsDevice,
                    nameof(Capabilities.Extension.AnalyticsDevice), (t, v) => t.XAddr = v);
                Capabilities.Extension.DeviceIO =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.DeviceIO,
                    nameof(Capabilities.Extension.DeviceIO), (t, v) => t.XAddr = v);
                Capabilities.Extension.DeviceIO =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.DeviceIO,
                    nameof(Capabilities.Extension.DeviceIO), (t, v) => t.XAddr = v);
                Capabilities.Extension.Display =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.Display,
                    nameof(Capabilities.Extension.Display), (t, v) => t.XAddr = v);
                Capabilities.Extension.Receiver =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.Receiver,
                    nameof(Capabilities.Extension.Receiver), (t, v) => t.XAddr = v);
                Capabilities.Extension.Recording =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.Recording,
                    nameof(Capabilities.Extension.Recording), (t, v) => t.XAddr = v);
                Capabilities.Extension.Replay =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.Replay,
                    nameof(Capabilities.Extension.Replay), (t, v) => t.XAddr = v);
                Capabilities.Extension.Search =
                    HandleCapabilitiesExtensionItem(Capabilities.Extension.Search,
                    nameof(Capabilities.Extension.Search), (t, v) => t.XAddr = v);
            }
        }

        public string GetExtensionXAddr(string name)
        {
            var xmlElement = Capabilities.Extension.Any?.FirstOrDefault(t => t.LocalName == name);

            return xmlElement?.ChildNodes.OfType<XmlElement>()
                .Where(elXAddr => elXAddr.LocalName == "XAddr")
                .Select(elXAddr => elXAddr.InnerText)
                .FirstOrDefault();
        }
    }
}
