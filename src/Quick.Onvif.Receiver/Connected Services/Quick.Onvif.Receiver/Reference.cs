﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quick.Onvif.Receiver
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.onvif.org/ver10/receiver/wsdl", ConfigurationName="Quick.Onvif.Receiver.ReceiverPort")]
    public interface ReceiverPort
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetServiceCapabilities", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Capabilities")]
        System.Threading.Tasks.Task<Quick.Onvif.Receiver.Capabilities> GetServiceCapabilitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetReceivers", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Quick.Onvif.Receiver.GetReceiversResponse> GetReceiversAsync(Quick.Onvif.Receiver.GetReceiversRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetReceiver", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Receiver")]
        System.Threading.Tasks.Task<Quick.Onvif.Receiver.Receiver> GetReceiverAsync(string ReceiverToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/CreateReceiver", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Receiver")]
        System.Threading.Tasks.Task<Quick.Onvif.Receiver.Receiver> CreateReceiverAsync(Quick.Onvif.Receiver.ReceiverConfiguration Configuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/DeleteReceiver", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task DeleteReceiverAsync(string ReceiverToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/ConfigureReceiver", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task ConfigureReceiverAsync(string ReceiverToken, Quick.Onvif.Receiver.ReceiverConfiguration Configuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/SetReceiverMode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task SetReceiverModeAsync(string ReceiverToken, Quick.Onvif.Receiver.ReceiverMode Mode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetReceiverState", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="ReceiverState")]
        System.Threading.Tasks.Task<Quick.Onvif.Receiver.ReceiverStateInformation> GetReceiverStateAsync(string ReceiverToken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/receiver/wsdl")]
    public partial class Capabilities
    {
        
        private System.Xml.XmlElement[] anyField;
        
        private bool rTP_MulticastField;
        
        private bool rTP_MulticastFieldSpecified;
        
        private bool rTP_TCPField;
        
        private bool rTP_TCPFieldSpecified;
        
        private bool rTP_RTSP_TCPField;
        
        private bool rTP_RTSP_TCPFieldSpecified;
        
        private int supportedReceiversField;
        
        private int maximumRTSPURILengthField;
        
        private bool maximumRTSPURILengthFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=0)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RTP_Multicast
        {
            get
            {
                return this.rTP_MulticastField;
            }
            set
            {
                this.rTP_MulticastField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RTP_MulticastSpecified
        {
            get
            {
                return this.rTP_MulticastFieldSpecified;
            }
            set
            {
                this.rTP_MulticastFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RTP_TCP
        {
            get
            {
                return this.rTP_TCPField;
            }
            set
            {
                this.rTP_TCPField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RTP_TCPSpecified
        {
            get
            {
                return this.rTP_TCPFieldSpecified;
            }
            set
            {
                this.rTP_TCPFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RTP_RTSP_TCP
        {
            get
            {
                return this.rTP_RTSP_TCPField;
            }
            set
            {
                this.rTP_RTSP_TCPField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RTP_RTSP_TCPSpecified
        {
            get
            {
                return this.rTP_RTSP_TCPFieldSpecified;
            }
            set
            {
                this.rTP_RTSP_TCPFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SupportedReceivers
        {
            get
            {
                return this.supportedReceiversField;
            }
            set
            {
                this.supportedReceiversField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaximumRTSPURILength
        {
            get
            {
                return this.maximumRTSPURILengthField;
            }
            set
            {
                this.maximumRTSPURILengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaximumRTSPURILengthSpecified
        {
            get
            {
                return this.maximumRTSPURILengthFieldSpecified;
            }
            set
            {
                this.maximumRTSPURILengthFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class ReceiverStateInformation
    {
        
        private ReceiverState stateField;
        
        private bool autoCreatedField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ReceiverState State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool AutoCreated
        {
            get
            {
                return this.autoCreatedField;
            }
            set
            {
                this.autoCreatedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=2)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum ReceiverState
    {
        
        /// <remarks/>
        NotConnected,
        
        /// <remarks/>
        Connecting,
        
        /// <remarks/>
        Connected,
        
        /// <remarks/>
        Unknown,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class Transport
    {
        
        private TransportProtocol protocolField;
        
        private Transport tunnelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public TransportProtocol Protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Transport Tunnel
        {
            get
            {
                return this.tunnelField;
            }
            set
            {
                this.tunnelField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum TransportProtocol
    {
        
        /// <remarks/>
        UDP,
        
        /// <remarks/>
        TCP,
        
        /// <remarks/>
        RTSP,
        
        /// <remarks/>
        HTTP,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class StreamSetup
    {
        
        private StreamType streamField;
        
        private Transport transportField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public StreamType Stream
        {
            get
            {
                return this.streamField;
            }
            set
            {
                this.streamField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Transport Transport
        {
            get
            {
                return this.transportField;
            }
            set
            {
                this.transportField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=2)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum StreamType
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("RTP-Unicast")]
        RTPUnicast,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("RTP-Multicast")]
        RTPMulticast,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class ReceiverConfiguration
    {
        
        private ReceiverMode modeField;
        
        private string mediaUriField;
        
        private StreamSetup streamSetupField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ReceiverMode Mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI", Order=1)]
        public string MediaUri
        {
            get
            {
                return this.mediaUriField;
            }
            set
            {
                this.mediaUriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public StreamSetup StreamSetup
        {
            get
            {
                return this.streamSetupField;
            }
            set
            {
                this.streamSetupField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=3)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum ReceiverMode
    {
        
        /// <remarks/>
        AutoConnect,
        
        /// <remarks/>
        AlwaysConnect,
        
        /// <remarks/>
        NeverConnect,
        
        /// <remarks/>
        Unknown,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class Receiver
    {
        
        private string tokenField;
        
        private ReceiverConfiguration configurationField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Token
        {
            get
            {
                return this.tokenField;
            }
            set
            {
                this.tokenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public ReceiverConfiguration Configuration
        {
            get
            {
                return this.configurationField;
            }
            set
            {
                this.configurationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=2)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetReceivers", WrapperNamespace="http://www.onvif.org/ver10/receiver/wsdl", IsWrapped=true)]
    public partial class GetReceiversRequest
    {
        
        public GetReceiversRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetReceiversResponse", WrapperNamespace="http://www.onvif.org/ver10/receiver/wsdl", IsWrapped=true)]
    public partial class GetReceiversResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/receiver/wsdl", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Receivers")]
        public Quick.Onvif.Receiver.Receiver[] Receivers;
        
        public GetReceiversResponse()
        {
        }
        
        public GetReceiversResponse(Quick.Onvif.Receiver.Receiver[] Receivers)
        {
            this.Receivers = Receivers;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ReceiverPortChannel : Quick.Onvif.Receiver.ReceiverPort, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class ReceiverPortClient : System.ServiceModel.ClientBase<Quick.Onvif.Receiver.ReceiverPort>, Quick.Onvif.Receiver.ReceiverPort
    {
        
        public ReceiverPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Receiver.Capabilities> GetServiceCapabilitiesAsync()
        {
            return base.Channel.GetServiceCapabilitiesAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Quick.Onvif.Receiver.GetReceiversResponse> Quick.Onvif.Receiver.ReceiverPort.GetReceiversAsync(Quick.Onvif.Receiver.GetReceiversRequest request)
        {
            return base.Channel.GetReceiversAsync(request);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Receiver.GetReceiversResponse> GetReceiversAsync()
        {
            Quick.Onvif.Receiver.GetReceiversRequest inValue = new Quick.Onvif.Receiver.GetReceiversRequest();
            return ((Quick.Onvif.Receiver.ReceiverPort)(this)).GetReceiversAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Receiver.Receiver> GetReceiverAsync(string ReceiverToken)
        {
            return base.Channel.GetReceiverAsync(ReceiverToken);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Receiver.Receiver> CreateReceiverAsync(Quick.Onvif.Receiver.ReceiverConfiguration Configuration)
        {
            return base.Channel.CreateReceiverAsync(Configuration);
        }
        
        public System.Threading.Tasks.Task DeleteReceiverAsync(string ReceiverToken)
        {
            return base.Channel.DeleteReceiverAsync(ReceiverToken);
        }
        
        public System.Threading.Tasks.Task ConfigureReceiverAsync(string ReceiverToken, Quick.Onvif.Receiver.ReceiverConfiguration Configuration)
        {
            return base.Channel.ConfigureReceiverAsync(ReceiverToken, Configuration);
        }
        
        public System.Threading.Tasks.Task SetReceiverModeAsync(string ReceiverToken, Quick.Onvif.Receiver.ReceiverMode Mode)
        {
            return base.Channel.SetReceiverModeAsync(ReceiverToken, Mode);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Receiver.ReceiverStateInformation> GetReceiverStateAsync(string ReceiverToken)
        {
            return base.Channel.GetReceiverStateAsync(ReceiverToken);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
    }
}