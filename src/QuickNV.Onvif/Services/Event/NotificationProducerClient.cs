﻿using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Event
{
    public partial class NotificationProducerClient
    {
        public NotificationProducerClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Events.XAddr)
        {
        }

        public NotificationProducerClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
