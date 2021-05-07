using AppPets.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPets.Services
{
    public class ApiService
    {
        public string ApiUrl = "http://192.168.1.70/WebApiPet/";


        public async Task<ApiResponse> GetDataAsync(string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.GetAsync(controller);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> PostDataAsync(string controller,object data)
        {
            try
            {
                var serializeData = JsonConvert.SerializeObject(data);
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.PostAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> PutDataAsync(string controller, object data)
        {
            try
            {
                var serializeData = JsonConvert.SerializeObject(data);
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.PutAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> DeleteDataAsync(string controller, int id)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.DeleteAsync(controller + "/ " + id);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }
    }
}
