using LiveGreeterWpfDemo.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveGreeterWpfDemo.Services
{
    public interface IRestApiService
    {
        List<Vehicle> GetVehicles();
    }
    public class RestApiService:IRestApiService
    {
        public List<Vehicle> GetVehicles()
        {
            var client = new RestClient("https://demogeneral.herokuapp.com/api/vehicle");

            var request = new RestRequest("", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Vehicle>>(content);
        }
    }
}
