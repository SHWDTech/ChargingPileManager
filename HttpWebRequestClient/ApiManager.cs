using HttpWebRequestClient.Model;

namespace HttpWebRequestClient
{
    public class ApiManager
    {
        private static string ServerAddress = "http://118.31.237.242:9090";

        public static void SetServerAddress(string address)
        {
            ServerAddress = address;
        }

        public string GetServerInfo()
        {
            return new HttpRequestClient().StartRequestAsync($"{ServerAddress}/api/ServerInfo", HttpRequestClient.HttpMethodGet, new XHttpRequestParamters(), true).Result;
        }

        public string BatchGetChargingPileInfo(string[] identitys)
        {
            return new HttpRequestClient().StartRequestAsync($"{ServerAddress}/api/ChargingPile/Status", HttpRequestClient.HttpMethodGet, new XHttpRequestParamters()
            {
                BodyParamters = identitys
            }, 1 != 0).Result;
        }

        public string GetChargingPileInfo(string identity)
        {
            return new HttpRequestClient().StartRequestAsync($"{ServerAddress}/api/ChargingPile/{identity}/Status", HttpRequestClient.HttpMethodGet, new XHttpRequestParamters(), true).Result;
        }

        public string PostCommand(CommandPostViewModel model)
        {
            return new HttpRequestClient().StartRequestAsync($"{ServerAddress}/api/Command", HttpRequestClient.HttpMethodPost, new XHttpRequestParamters
            {
                BodyParamters = model
            }, 1 != 0).Result;
        }
    }
}
