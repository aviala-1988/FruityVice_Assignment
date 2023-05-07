using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FruitVice_API_IntegrationTest.Providers
{
    public class TestClientProvider
    {
        public IConfiguration _config;
        public HttpClient HttpClient { get; set; }
        public TestClientProvider()
        {
            HttpClient = new HttpClient();
        }
    }
}
