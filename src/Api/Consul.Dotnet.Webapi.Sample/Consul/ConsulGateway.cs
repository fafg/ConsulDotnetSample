using System;
using System.Text;
using System.Threading.Tasks;

namespace Consul.Gateway
{
    public class ConsulGateway
    {
        public ConsulGateway()
        {

        }

        public static async Task<string> GetValue(string key)
        {
            string value = string.Empty;
       
            if (string.IsNullOrWhiteSpace(key))
                return value;

            try
            {
                using (ConsulClient client = new ConsulClient(c => 
                {
                    c.Address = new Uri("http://localhost:8500");
                    c.Datacenter = "dc1";
                    c.Token = "DUYH9oRaiWXu+gMMIUSGmg==";
                }))
                {
                    QueryResult<KVPair> getPair = await client.KV.Get(key);
                    value = Encoding.UTF8.GetString(getPair.Response.Value, 0,
                        getPair.Response.Value.Length);
                }
            }
            catch (Exception ex)
            {
                value = "ERROR";
                Console.WriteLine(ex.Message);
            }

            return value;
        }
    }
}