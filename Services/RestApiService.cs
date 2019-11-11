using LiveGreeterWpfDemo.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LiveGreeterWpfDemo.Services
{
    public interface IRestApiService
    {
        ObservableCollection<Vehicle> GetVehicles();
        bool PostVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int vehicleId);


    }
    public class RestApiService:IRestApiService
    {
        private readonly IOptions<AppSettings> _settings;
        public RestApiService(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
        public ObservableCollection<Vehicle> GetVehicles()
        {
            var client = new RestClient(_settings.Value.API);

            var request = new RestRequest("", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<ObservableCollection<Vehicle>>(content);
        }
        public bool PostVehicle(Vehicle vehicle) 
        {
            var result = false;
            var client = new RestClient(_settings.Value.API);

            var request = new RestRequest("", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(vehicle);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            if (content.ToUpper() == "CREATED")
            {
                result = true;
            }
            return result;
        }
        public bool UpdateVehicle(Vehicle vehicle)
        {
            var result = false;
            var client = new RestClient(_settings.Value.API);

            var request = new RestRequest("", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(vehicle);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            if (content.ToUpper() == "")
            {
                result = true;
            }
            return result;
        }
        public bool DeleteVehicle(int vehicleId)
        {
            var result = false;
            var client = new RestClient(_settings.Value.API+"/"+vehicleId);

            var request = new RestRequest("", Method.DELETE);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            if (string.IsNullOrEmpty(content))
            {
                result = true;
            }
            return result;
        }
    }
}
