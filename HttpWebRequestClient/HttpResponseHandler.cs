using System;

namespace HttpWebRequestClient
{
    public class HttpResponseHandler
    {
        public Action<HttpRequestEventArgs> OnResponse { get; set; }

        public Action<HttpRequestEventArgs> OnError { get; set; }

        public void Response(string response)
        {
            OnResponse?.Invoke(new HttpRequestEventArgs
            {
                Response = response
            });
        }

        public void Error(Exception exception)
        {
            OnError?.Invoke(new HttpRequestEventArgs
            {
                Exception = exception
            });
        }
    }
}
