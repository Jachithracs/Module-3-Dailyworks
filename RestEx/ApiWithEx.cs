using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEx
{
    public class ApiWithEx
    {
        string baseUrl = "https://reqres.in/api";

        //JSON 

        public void GetSingleUser()
        {
            var client = new RestClient(baseUrl);
            var req = new RestRequest("users/23", Method.Get);
            var response = client.Execute(req);

            if (!response.IsSuccessful)
            {
                if (IsJson(response.Content))
                {
                    try
                    {
                        var errorDetails = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                        if (errorDetails != null)
                        {
                            Console.WriteLine($"API Error: {errorDetails.Error}");
                        }
                    }
                    catch (JsonException)
                    {
                        Console.WriteLine("Failed to deserialize error response");
                    }
                }
                else
                {
                    Console.WriteLine($"Non-JSON error response :{response.Content}");
                }
            }
            static bool IsJson(string content)
            {
                try
                {
                    JToken.Parse(content);
                    return true;
                }
                catch(ArgumentNullException)
                {
                    return false;
                }
            }
        }
    }
}
