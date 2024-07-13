using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Security
{
    public partial class KeystoreClient
    {
        public KeystoreClient(OnvifClient client)
            : this(client.ClientFactory, client.GetExtensionXAddr(nameof(Security)))
        {
        }

        public KeystoreClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
