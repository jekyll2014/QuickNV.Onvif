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
[XmlRoot("RelatesTo", Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing", IsNullable = false)]
public class Relationship
{
    private XmlQualifiedName relationshipTypeField;

    private XmlAttribute[] anyAttrField;

    private string valueField;

    [XmlAttribute]
    public XmlQualifiedName RelationshipType
    {
        get
        {
            return relationshipTypeField;
        }
        set
        {
            relationshipTypeField = value;
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

    [XmlText(DataType = "anyURI")]
    public string Value
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
