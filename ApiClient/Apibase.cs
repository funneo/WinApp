using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ApiClient
{
    public class UserClaim
    {
        public const string Roles = "roles";
        public const string Id = "id";
        public const string Permissions = "permissions";
        public const string FullName = "fullName";
        public const string Avatar = "avatar";
        public const string UserName = "userName";
        public const string Email = "email";
        public const string EmployeeId = "employeeId";
        public const string BranchId = "branchId";
        public const string AuthorisationLevel = "authorisationLevel"; // cap quyen cu user
        public const string AdvanceConfirmLevel = "advanceConfirmLevel"; //quyen duyet tam ung
        public const string PaymentConfirmLevel = "paymentConfirmLevel"; // quyen duyet thanh toán
        public const string ListAdvanceGroupId = "listAdvanceGroupId"; //Nhom tam ung co quyen duyet
        public const string ListPaymentGroupId = "listPaymentGroupId"; //Nhom thanh toan co quyen duyet
    }
    public static class Apibase
    {
        public static Token _Token;
       // public static string _Url = "http://125.212.225.178:8099";
        public static string _Url = Common.AppConfig.URL;    
        public static bool Login(string username, string password, int branchId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Accept.Clear();
                var user = new SysUser(username, password,branchId);
                string JsonCustomer = JsonConvert.SerializeObject(user, Formatting.Indented);
                StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");
                var response = client.PostAsync(_Url + @"/api/account/login", content);
                var token = response.Result.Content.ReadAsStringAsync().Result;
                if (response.Result.IsSuccessStatusCode)
                {                 
                    _Token = JsonConvert.DeserializeObject<Token>(token);
                    Common.CommonVariable.TokenKey = _Token.token;
                    Common.CommonVariable.JwtToken = _Token.token;
                    //Common.CommonVariable.JwtToken = _Token.token.Substring(_Token.token.IndexOf("-") + 1, _Token.token.Length - _Token.token.IndexOf("-") - 1);
                    //GetLoggedInUser();
                    return true;
                }
                else
                {
                    _Token = new Token();
                    _Token.token = token;
                    Common.DeltaError.Code = ((int)response.Result.StatusCode).ToString();
                    Common.DeltaError.Message = JsonConvert.DeserializeObject<DeltaMessage>(response.Result.Content.ReadAsStringAsync().Result).Message;
                    return false;
                }
            }
        }

        public static bool Logout()
        {           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                HttpResponseMessage response = client.PostAsync(_Url + @"/api/account/logout", new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json")).Result;
                return response.IsSuccessStatusCode;
            }
        }

        public static SysUser GetLoggedInUser()
        {          
            var handler = new JwtSecurityTokenHandler();          
            var tokenS = handler.ReadToken(Common.CommonVariable.JwtToken) as JwtSecurityToken;
            //MessageBox.Show(tokenS.ToString());    
            //var idDaiLy = tokenS.Claims.FirstOrDefault(claim => claim.Type == "IdDaiLy").Value;
            var userName = tokenS.Claims.FirstOrDefault(claim => claim.Type == UserClaim.UserName).Value;
            var id = tokenS.Claims.FirstOrDefault(claim => claim.Type == UserClaim.Id).Value;
            var employeeId = tokenS.Claims.FirstOrDefault(claim => claim.Type == UserClaim.EmployeeId).Value;
            var branchId = tokenS.Claims.FirstOrDefault(claim => claim.Type == UserClaim.BranchId).Value;
            var auLevel = tokenS.Claims.FirstOrDefault(claim => claim.Type == UserClaim.AuthorisationLevel).Value;
            var adLevel = tokenS.Claims.FirstOrDefault(claim => claim.Type == UserClaim.AdvanceConfirmLevel).Value;
            var pmLevel = tokenS.Claims.FirstOrDefault(claim => claim.Type == UserClaim.PaymentConfirmLevel).Value;
            var croles= tokenS.Claims.Where(claim => claim.Type == UserClaim.Roles).ToList();
            var _permissions = tokenS.Claims.Where(claim => claim.Type == UserClaim.Permissions).ToList();
            var cpermissions = JsonConvert.DeserializeObject<List<string>>(_permissions[0]?.Value);
            var roles = new List<string>();
            var permissions = new List<string>();
            foreach (var item in croles)
                roles.Add(item.Value);
            foreach (var item in cpermissions)
                permissions.Add(item);
            if (tokenS == null)
                return new SysUser();
            else
                return new SysUser(userName,id,
                   branchId.ConvertInt(), 
                  auLevel.ConvertInt(),
                   adLevel.ConvertInt(),
                   pmLevel.ConvertInt(),
                    employeeId.ConvertInt(),
                    roles,permissions);
        }

        public static T Get<T>(string url)
        {
            using (var client = new HttpClient())
            {                
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Common.CommonVariable.JwtToken);
                var response = client.GetAsync(_Url + url).Result;
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                else {
                    //Log
                    return default;
                }               
            }
        }

        public static T Post<T>(string url, object obj)
        {
            using (var client = new HttpClient())
            {              
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result))
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    else return JsonConvert.DeserializeObject<T>("1");
                }
                else
                {
                    //Log                
                    Common.DeltaError.Code = ((int)response.StatusCode).ToString();
                    Common.DeltaError.Message = JsonConvert.DeserializeObject<DeltaMessage>(response.Content.ReadAsStringAsync().Result).Message;
                    return default;
                }
            }
        }

        public static T Put<T>(string url, object obj)
        {
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                HttpResponseMessage response = client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result))
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    else return JsonConvert.DeserializeObject<T>("1");
                }                       
                else
                {
                    //Log
                    Common.DeltaError.Code = ((int)response.StatusCode).ToString();
                    Common.DeltaError.Message = JsonConvert.DeserializeObject<DeltaMessage>(response.Content.ReadAsStringAsync().Result).Message;
                    return default;
                }
            }
        }

        public static T Delete<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result))
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    else return JsonConvert.DeserializeObject<T>("1");
                }
                else
                {
                    //Log
                    Common.DeltaError.Code = ((int)response.StatusCode).ToString();
                    Common.DeltaError.Message = JsonConvert.DeserializeObject<DeltaMessage>(response.Content.ReadAsStringAsync().Result).Message;
                    return default;
                }
            }
        }

        public static HttpResponseMessage Get(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                var response = client.GetAsync(_Url + url).Result;
                return response;
            }
        }

        public static HttpResponseMessage Post(string url, object obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                HttpResponseMessage response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result;
                return response;
            }
        }

        public static HttpResponseMessage Put(string url, object obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                HttpResponseMessage response = client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Result;
                return response;
            }
        }

        public static HttpResponseMessage Delete(string url)
        {
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri(_Url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _Token.token);
                var response = client.DeleteAsync(url).Result;
                return response;
            }
        }
    }
}
