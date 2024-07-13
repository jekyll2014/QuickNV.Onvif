namespace QuickNV.Onvif.Factorys.Workrounds
{
    internal class InterceptingHttpMessageHandler : DelegatingHandler
    {
        public InterceptingHttpMessageHandler(HttpMessageHandler innerHandler)
        {
            InnerHandler = innerHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            request.Headers.ExpectContinue = false;
            response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
