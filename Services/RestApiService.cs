using System;
using System.Collections.Generic;
using System.Text;

namespace LiveGreeterWpfDemo.Services
{
    public interface IRestApiService
    {
        string GetCurrentDate();
    }
    public class RestApiService:IRestApiService
    {
        public string GetCurrentDate()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
