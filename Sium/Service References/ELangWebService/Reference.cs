﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sium.ELangWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ELangWebService.GoEXSoap")]
    public interface GoEXSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 HelloWorldResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        Sium.ELangWebService.HelloWorldResponse HelloWorld(Sium.ELangWebService.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<Sium.ELangWebService.HelloWorldResponse> HelloWorldAsync(Sium.ELangWebService.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloBool", ReplyAction="*")]
        bool HelloBool();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloBool", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> HelloBoolAsync();
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 Jjson 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/stringJson", ReplyAction="*")]
        Sium.ELangWebService.stringJsonResponse stringJson(Sium.ELangWebService.stringJsonRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/stringJson", ReplyAction="*")]
        System.Threading.Tasks.Task<Sium.ELangWebService.stringJsonResponse> stringJsonAsync(Sium.ELangWebService.stringJsonRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public Sium.ELangWebService.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(Sium.ELangWebService.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public Sium.ELangWebService.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(Sium.ELangWebService.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class stringJsonRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="stringJson", Namespace="http://tempuri.org/", Order=0)]
        public Sium.ELangWebService.stringJsonRequestBody Body;
        
        public stringJsonRequest() {
        }
        
        public stringJsonRequest(Sium.ELangWebService.stringJsonRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class stringJsonRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string Jjson;
        
        public stringJsonRequestBody() {
        }
        
        public stringJsonRequestBody(string Jjson) {
            this.Jjson = Jjson;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class stringJsonResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="stringJsonResponse", Namespace="http://tempuri.org/", Order=0)]
        public Sium.ELangWebService.stringJsonResponseBody Body;
        
        public stringJsonResponse() {
        }
        
        public stringJsonResponse(Sium.ELangWebService.stringJsonResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class stringJsonResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string stringJsonResult;
        
        public stringJsonResponseBody() {
        }
        
        public stringJsonResponseBody(string stringJsonResult) {
            this.stringJsonResult = stringJsonResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GoEXSoapChannel : Sium.ELangWebService.GoEXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GoEXSoapClient : System.ServiceModel.ClientBase<Sium.ELangWebService.GoEXSoap>, Sium.ELangWebService.GoEXSoap {
        
        public GoEXSoapClient() {
        }
        
        public GoEXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GoEXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GoEXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GoEXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sium.ELangWebService.HelloWorldResponse Sium.ELangWebService.GoEXSoap.HelloWorld(Sium.ELangWebService.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            Sium.ELangWebService.HelloWorldRequest inValue = new Sium.ELangWebService.HelloWorldRequest();
            inValue.Body = new Sium.ELangWebService.HelloWorldRequestBody();
            Sium.ELangWebService.HelloWorldResponse retVal = ((Sium.ELangWebService.GoEXSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Sium.ELangWebService.HelloWorldResponse> Sium.ELangWebService.GoEXSoap.HelloWorldAsync(Sium.ELangWebService.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<Sium.ELangWebService.HelloWorldResponse> HelloWorldAsync() {
            Sium.ELangWebService.HelloWorldRequest inValue = new Sium.ELangWebService.HelloWorldRequest();
            inValue.Body = new Sium.ELangWebService.HelloWorldRequestBody();
            return ((Sium.ELangWebService.GoEXSoap)(this)).HelloWorldAsync(inValue);
        }
        
        public bool HelloBool() {
            return base.Channel.HelloBool();
        }
        
        public System.Threading.Tasks.Task<bool> HelloBoolAsync() {
            return base.Channel.HelloBoolAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sium.ELangWebService.stringJsonResponse Sium.ELangWebService.GoEXSoap.stringJson(Sium.ELangWebService.stringJsonRequest request) {
            return base.Channel.stringJson(request);
        }
        
        public string stringJson(string Jjson) {
            Sium.ELangWebService.stringJsonRequest inValue = new Sium.ELangWebService.stringJsonRequest();
            inValue.Body = new Sium.ELangWebService.stringJsonRequestBody();
            inValue.Body.Jjson = Jjson;
            Sium.ELangWebService.stringJsonResponse retVal = ((Sium.ELangWebService.GoEXSoap)(this)).stringJson(inValue);
            return retVal.Body.stringJsonResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Sium.ELangWebService.stringJsonResponse> Sium.ELangWebService.GoEXSoap.stringJsonAsync(Sium.ELangWebService.stringJsonRequest request) {
            return base.Channel.stringJsonAsync(request);
        }
        
        public System.Threading.Tasks.Task<Sium.ELangWebService.stringJsonResponse> stringJsonAsync(string Jjson) {
            Sium.ELangWebService.stringJsonRequest inValue = new Sium.ELangWebService.stringJsonRequest();
            inValue.Body = new Sium.ELangWebService.stringJsonRequestBody();
            inValue.Body.Jjson = Jjson;
            return ((Sium.ELangWebService.GoEXSoap)(this)).stringJsonAsync(inValue);
        }
    }
}
