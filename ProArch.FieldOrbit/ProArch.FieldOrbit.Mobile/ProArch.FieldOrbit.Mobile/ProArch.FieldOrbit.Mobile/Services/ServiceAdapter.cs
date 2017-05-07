using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ProArch.FieldOrbit.Mobile.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ProArch.FieldOrbit.Mobile.Services
{
    internal class ServiceAdapter
    {
        private const string API_URI = "http://192.168.21.161/test-fieldorbit-api/api/"; //"http://192.168.21.117/HackathonMock/api/";

        private HttpClient client;
        private static ServiceAdapter instance;

        private ServiceAdapter()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public static ServiceAdapter Instance
        {
            get
            {
                if (instance == null) instance = new ServiceAdapter();

                return instance;
            }
        }
    

        public async Task<T> Get<T>(string path)
        {
            string restUrl = API_URI + path;
            var uri = new Uri(restUrl, UriKind.Absolute);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content.Result);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

            return default(T);
        }

        public async Task Post<T>(string path, object o)
        {
            if (o == null) return;

            string restUrl = API_URI + path;
            var uri = new Uri(restUrl, UriKind.Absolute);

            try
            {
                var json = JsonConvert.SerializeObject(o);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        public async Task Put<T>(string path, object o)
        {
            if (o == null) return;

            string restUrl = API_URI + path;
            var uri = new Uri(restUrl, UriKind.Absolute);

            try
            {
                var json = JsonConvert.SerializeObject(o);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(uri, content);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        public async Task<bool> ValidateUser<T>(string path)
        {
            string restUrl = API_URI + path;
            var uri = new Uri(restUrl, UriKind.Absolute);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();
                    App.Identity = JsonConvert.DeserializeObject<UserIdentity>(content.Result);
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

            return false;
        }



    }
}
