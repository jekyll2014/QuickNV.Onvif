using QuickNV.Onvif.Discovery.Common.Soap;
using QuickNV.Onvif.Discovery.WSDiscovery;

using System.Reflection;
using System.Xml.Schema;

namespace QuickNV.Onvif.Discovery.Common.Discovery;

internal class DiscoverySoapBuilder : SoapBuilder
{
    static DiscoverySoapBuilder()
    {
        Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Quick.Onvif.Discovery.Common.Discovery.Schemas.xml.xsd");
        XmlSchema item = XmlSchema.Read(manifestResourceStream, null);
        manifestResourceStream.Close();
        Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Quick.Onvif.Discovery.Common.Discovery.Schemas.soap-envelope.xsd");
        XmlSchema item2 = XmlSchema.Read(manifestResourceStream2, null);
        manifestResourceStream2.Close();
        SoapBuilder._soapSchemas = new List<XmlSchema> { item, item2 };
        SoapBuilder.GetDeserializer<ProbeMatchesType>(SoapBuilder.GetAttributeOverrides<ProbeMatchesType>());
    }
}
