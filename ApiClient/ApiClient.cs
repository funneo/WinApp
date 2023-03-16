using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.IO;

namespace ApiClient
{
    public class ApiClient
    {
        public static string _Url = Common.AppConfig.URL;

        public static T Post<T>(string url, object obj)
        {
            var client = new RestClient(_Url + url);
            var request = new RestRequest(Method.POST);
            //var jwtToken = Common.CommonVariable.TokenKey.Substring(Common.CommonVariable.TokenKey.IndexOf("-") + 1, Common.CommonVariable.TokenKey.Length - Common.CommonVariable.TokenKey.IndexOf("-") - 1);
            request.AddHeader("Authorization", "Bearer " + Common.CommonVariable.JwtToken);
            request.AddHeader("Content-Type", "Application/json");
            request.AddHeader("Accept", "*/*");
            request.AddJsonBody(obj);
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var response = client.Execute(request);
                return JsonConvert.DeserializeObject<T>(response.Content,settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T PostFormData<T>(string url, string parameters,List<string>filesPath)
        {
            var client = new RestClient(_Url + url);
            var request = new RestRequest(Method.POST);
            //var jwtToken = Common.CommonVariable.TokenKey.Substring(Common.CommonVariable.TokenKey.IndexOf("-") + 1, Common.CommonVariable.TokenKey.Length - Common.CommonVariable.TokenKey.IndexOf("-") - 1);
            request.AddHeader("Authorization", "Bearer " + Common.CommonVariable.JwtToken);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddParameter("TokenKey", parameters , ParameterType.RequestBody);
            foreach(var item in filesPath)
            {
                request.AddFile("Files", item);
            }
            request.AddHeader("Accept", "*/*");
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var response = client.Execute(request);
                return JsonConvert.DeserializeObject<T>(response.Content,settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T PostIFormFile<T>(string url, List<string> filesPath)
        {
            var client = new RestClient(_Url + url);
            var request = new RestRequest(Method.POST);
            //var jwtToken = Common.CommonVariable.TokenKey.Substring(Common.CommonVariable.TokenKey.IndexOf("-") + 1, Common.CommonVariable.TokenKey.Length - Common.CommonVariable.TokenKey.IndexOf("-") - 1);
            request.AddHeader("Authorization", "Bearer " + Common.CommonVariable.JwtToken);
            request.AddHeader("Content-Type", "multipart/form-data");
            foreach (var item in filesPath)
            {
                request.AddFile("files", item);
            }
            request.AddHeader("Accept", "*/*");
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var response = client.Execute(request);
                return JsonConvert.DeserializeObject<T>(response.Content, settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
