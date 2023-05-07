using FruitVice_API_Services_Data.Models;
using FruitVice_Services_Core.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FruitVice_Services_Core.Implementations
{
    public class FruityViceService : IFruityViceService
    {
        #region Local Variables and Properties
        private IConfiguration _configuration;
        #endregion


        #region Constructor
        public FruityViceService(IConfiguration config)
        {
            _configuration = config;
        }

        #endregion

        public async Task<List<FruityViceResponseModel>> GetAllFruitsCollection()
        {
            List<FruityViceResponseModel> responseData = new List<FruityViceResponseModel>();
            try
            {
                string url = _configuration.GetSection("FruitViceConfiguration").GetSection("redirect_uri").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url+"all");
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = client.GetAsync("").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        responseData = JsonConvert.DeserializeObject<List<FruityViceResponseModel>>(data);
                    }
                }
                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FruityViceResponseModel>> GetAllFruitsByFamily(string family)
        {
            List<FruityViceResponseModel> responseData = new List<FruityViceResponseModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = _configuration.GetSection("FruitViceConfiguration").GetSection("redirect_uri").Value;

                    client.BaseAddress = new Uri(url + "family/"+family);
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = client.GetAsync("").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        responseData = JsonConvert.DeserializeObject<List<FruityViceResponseModel>>(data);
                    }
                }
                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
