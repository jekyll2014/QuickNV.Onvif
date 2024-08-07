﻿using System.ServiceModel;

namespace QuickNV.Onvif
{
    public class OnvifClientOptions
    {
        public string Scheme { get; set; } = "http";
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public HttpClientCredentialType ClientCredentialType { get; set; } = HttpClientCredentialType.Digest;
        public int RtspPort { get; set; }
        public int SnapshotPort { get; set; }
    }
}
