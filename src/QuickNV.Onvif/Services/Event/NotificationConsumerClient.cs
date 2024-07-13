using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Event
{
    public partial class NotificationConsumerClient
    {
        public NotificationConsumerClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Events.XAddr)
        {
        }

        public NotificationConsumerClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
