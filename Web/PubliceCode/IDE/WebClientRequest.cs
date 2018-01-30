using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebClientAuthentication
{
    public class WebClientRequest
    {
        private const string AppId = "4d53bce03ec34c0a911182d4c228ee6c";

        private const string ApiKey = "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=";

        public void OpenReadAsync(Uri apiUrl, XHttpRequestParamters paramter, HttpResponseHandler handler, bool isAddAuthenticationHead = false)
        {
            var request = new WebClient();
            foreach (var headerString in paramter.HeaderStrings)
            {
                request.Headers.Add(headerString.Key, headerString.Value);
            }
            if (isAddAuthenticationHead)
            {
                AddAuthenticationHead(request, apiUrl, "GET", paramter);
            }
            request.OpenReadCompleted += OpenReadCallBack;
            request.OpenReadAsync(apiUrl, handler);
        }

        private static void OpenReadCallBack(object sender, OpenReadCompletedEventArgs args)
        {
            var handler = (HttpResponseHandler)args.UserState;
            try
            {
                var responseStream = args.Result;
                using (var reader = new StreamReader(responseStream))
                {
                    var responseStr = reader.ReadToEnd();
                    handler.OnResponse(new HttpRerquestEventArgs
                    {
                        Response = responseStr
                    });
                }
            }
            catch (Exception ex)
            {
                handler.OnError(new HttpRerquestEventArgs
                {
                    Exception = ex
                });
            }
        }

        private void AddAuthenticationHead(WebClient request, Uri apiUrl, string method, XHttpRequestParamters paramter)
        {
            var requestContentBase64String = string.Empty;

            //HttpUtility需要引用System.Web
            var requestUri = HttpUtility.UrlEncode(apiUrl.ToString().ToLower());

            var requestHttpMethod = method;

            //Calculate UNIX time
            var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            var timeSpan = DateTime.UtcNow - epochStart;
            var requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

            //create random nonce for each request
            var nonce = Guid.NewGuid().ToString("N");

            if (paramter.BodyParamters.Count > 0)
            {
                var builder = new StringBuilder();
                foreach (var bodyParamter in paramter.BodyParamters)
                {
                    builder.Append(bodyParamter.Key);
                    builder.Append("=");
                    builder.Append(bodyParamter.Value);
                    builder.Append("&");
                }
                builder.Remove(builder.Length, 1);
                var content = Encoding.UTF8.GetBytes(builder.ToString());
                var md5 = MD5.Create();
                //Hashing the request body, any change in request body will result in different hash, we'll incure message integrity
                var requestContentHash = md5.ComputeHash(content);
                requestContentBase64String = Convert.ToBase64String(requestContentHash);
            }

            var signatureRawData = "{AppId}{requestHttpMethod}{requestUri}{requestTimeStamp}{nonce}{requestContentBase64String}";

            var secretKeyByteArray = Convert.FromBase64String(ApiKey);

            var signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (var hmac = new HMACSHA256(secretKeyByteArray))
            {
                var signatureBytes = hmac.ComputeHash(signature);
                var requestSignatureBase64String = Convert.ToBase64String(signatureBytes);
                request.Headers.Add("Authorization", string.Format(" {0} {1}", "cpx", string.Format("{0}:{1}:{2}:{3}", AppId, requestSignatureBase64String, nonce, requestTimeStamp)));
            }
        }
    }
}
