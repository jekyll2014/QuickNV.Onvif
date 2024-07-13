using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Security
{
    public partial class TLSServerClient
    {
        public TLSServerClient(OnvifClient client)
            : this(client.ClientFactory, client.GetExtensionXAddr(nameof(Security)))
        {
        }

        public TLSServerClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
