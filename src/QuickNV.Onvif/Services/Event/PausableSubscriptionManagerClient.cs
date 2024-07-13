using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Event
{
    public partial class PausableSubscriptionManagerClient
    {
        public PausableSubscriptionManagerClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Events.XAddr)
        {
        }

        public PausableSubscriptionManagerClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
