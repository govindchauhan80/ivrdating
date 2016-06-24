using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace ivrdating.Web.App_Start
{
    public class RequestDelegate : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
                                                 HttpRequestMessage request,
                                                    CancellationToken token)
        {
            HttpMessageContent requestContent = new HttpMessageContent(request);
            string requestMessage = requestContent.ReadAsStringAsync().Result;
            //HttpRequestContext rq = new HttpRequestContext();
            //request.GetRequestContext().IncludeErrorDetail = true;
            //requestContent.HttpRequestMessage.SetRequestContext()
            return await base.SendAsync(request, token);
        }
    }
}