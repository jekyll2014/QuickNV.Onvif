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
[XmlType(Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery")]
[XmlRoot("ResolveMatches", Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery", IsNullable = false)]
public class ResolveMatchesType
{
    private ResolveMatchType resolveMatchField;

    private XmlElement[] anyField;

    private XmlAttribute[] anyAttrField;

    public ResolveMatchType ResolveMatch
    {
        get
        {
            return resolveMatchField;
        }
        set
        {
            resolveMatchField = value;
        }
    }

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

    [XmlAnyAttribute]
    public XmlAttribute[] AnyAttr
    {
        get
        {
            return anyAttrField;
        }
        set
        {
            anyAttrField = value;
        }
    }
}
