using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Device
{
    public partial class DeviceClient
    {
        public DeviceClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Media.XAddr)
        {
        }

        public DeviceClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
