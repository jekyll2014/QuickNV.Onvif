﻿using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace QuickNV.Onvif.Factorys.Workrounds
{
    internal class HttpMessageHandlerBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            bindingParameters.Add(new Func<HttpClientHandler, HttpMessageHandler>(GetHttpMessageHandler));
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

        public void Validate(ServiceEndpoint endpoint) { }

        public HttpMessageHandler GetHttpMessageHandler(HttpClientHandler httpClientHandler)
        {
            return new InterceptingHttpMessageHandler(httpClientHandler);
        }
    }
}
