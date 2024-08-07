﻿using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Imaging
{
    public partial class ImagingPortClient
    {
        public ImagingPortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Imaging.XAddr)
        {
        }

        public ImagingPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}