using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Event
{
    public partial class SubscriptionManagerClient
    {
        public SubscriptionManagerClient(OnvifClient client)
                    : this(client.ClientFactory, client.Capabilities.Events.XAddr)
        {
        }

        public SubscriptionManagerClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
