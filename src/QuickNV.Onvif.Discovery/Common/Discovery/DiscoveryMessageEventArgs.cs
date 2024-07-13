using QuickNV.Onvif.Discovery.Common.Soap;

using System.Net;

namespace QuickNV.Onvif.Discovery.Common.Discovery;

public class DiscoveryMessageEventArgs : EventArgs
{
    public SoapMessage<object> Message { get; protected set; }

    public IPAddress Sender { get; protected set; }

    public DiscoveryMessageEventArgs(SoapMessage<object> message, IPAddress sender)
    {
        Message = message;
        Sender = sender;
    }
}
