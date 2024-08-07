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
public class ServiceNameType
{
    private string portNameField;

    private XmlAttribute[] anyAttrField;

    private XmlQualifiedName valueField;

    [XmlAttribute(DataType = "NCName")]
    public string PortName
    {
        get
        {
            return portNameField;
        }
        set
        {
            portNameField = value;
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

    [XmlText]
    public XmlQualifiedName Value
    {
        get
        {
            return valueField;
        }
        set
        {
            valueField = value;
        }
    }
}
