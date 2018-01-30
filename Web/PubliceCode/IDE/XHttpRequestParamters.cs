using System.Collections.Generic;

namespace WebClientAuthentication
{
    public class XHttpRequestParamters
    {
        public Dictionary<string, string> HeaderStrings  = new Dictionary<string, string>();

        public Dictionary<string, string> BodyParamters  = new Dictionary<string, string>();

        public void AddHeader(string key, string value)
        {
            HeaderStrings[key] = value;
        }

        public void AddBodyParamter(string key, string value)
        {
            BodyParamters[key] = value;
        }
    }
}
