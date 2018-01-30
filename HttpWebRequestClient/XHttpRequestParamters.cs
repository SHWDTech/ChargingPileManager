using System.Collections.Generic;

namespace HttpWebRequestClient
{
    public class XHttpRequestParamters
    {
        public Dictionary<string, string> HeaderStrings { get; }

        public object BodyParamters { get; set; }

        public XHttpRequestParamters()
        {
            HeaderStrings = new Dictionary<string, string>();
        }

        public void AddHeader(string key, string value)
        {
            HeaderStrings[key] = value;
        }
    }
}
