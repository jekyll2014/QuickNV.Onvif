using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace QuickNV.Onvif.Discovery.WSDiscovery;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing")]
public class ReferenceParametersType
{
    private XmlElement[] anyField;

    [XmlAnyElement]
    public XmlElement[] Any
    {
        get
        {
            return anyField;
        }
        set
        {
            anyField = value;
        }
    }
}
