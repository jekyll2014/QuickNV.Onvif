using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Event
{
    public partial class EventPortTypeClient
    {
        public EventPortTypeClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Events.XAddr)
        {
        }

        public EventPortTypeClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
