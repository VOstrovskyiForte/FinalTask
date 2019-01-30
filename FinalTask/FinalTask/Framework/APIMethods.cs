using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework
{
    public class APIMethods
    {


        public IRestResponse SendRequest(Method requestMethod, string baseURL, string resource, object body = null, string contentType = "application/json")
        {


            IRestClient client = new RestClient(baseURL);
            IRestRequest request = new RestRequest(resource, requestMethod);
            if (body != null)
                request.AddBody(body);
            request.AddHeader("Content-Type", contentType);
            return client.Execute(request);
        }

        public T DeserializeResponse<T>(IRestResponse response)
        {
            JsonDeserializer deserializer = new JsonDeserializer();
            return deserializer.Deserialize<T>(response);
        }
    }
}
