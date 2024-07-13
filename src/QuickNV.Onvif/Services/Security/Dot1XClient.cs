using QuickNV.Onvif.Factorys;

using System.ServiceModel;

namespace QuickNV.Onvif.Security
{
    public partial class Dot1XClient
    {
        public Dot1XClient(OnvifClient client)
            : this(client.ClientFactory, client.GetExtensionXAddr(nameof(Security)))
        {
        }

        public Dot1XClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
