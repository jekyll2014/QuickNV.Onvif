using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.DeviceIO
{
    public partial class DeviceClient
    {
        public DeviceClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Extension.DeviceIO.XAddr)
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
