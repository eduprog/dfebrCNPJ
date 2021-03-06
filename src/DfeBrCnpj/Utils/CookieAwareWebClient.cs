using System;
using System.Net;

namespace DfeBrCnpj.Utils
{
    public class CookieAwareWebClient : WebClient
    {
        private CookieContainer _mContainer;

        public void SetCookieContainer(CookieContainer container)
        {
            _mContainer = container;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            var webRequest = (HttpWebRequest)request;
            if (webRequest == null) return null;
            webRequest.CookieContainer = _mContainer;
            webRequest.KeepAlive = true;
            webRequest.ProtocolVersion = HttpVersion.Version10;
            return request;
        }

    }

}