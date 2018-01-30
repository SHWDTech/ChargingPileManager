using System.Net;

namespace HttpWebRequestClient
{
    public class HttpRequestAsyncState
    {
        public HttpWebRequest Request { get; }

        public string UrlEncodedContent { get; }

        public HttpResponseHandler Handler { get; }

        public HttpRequestAsyncState(HttpWebRequest request, string urlEncodedContent, HttpResponseHandler handler)
        {
            Request = request;
            UrlEncodedContent = urlEncodedContent;
            Handler = handler;
        }
    }
}
