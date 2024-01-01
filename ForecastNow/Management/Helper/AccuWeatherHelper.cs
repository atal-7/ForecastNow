using ForecastNow.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForecastNow.Management.Helper
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "k2TdtVuVVpL32BpLBqjuAj5T7iTSgdUq";

        public static async Task<List<City>> GetCities(string query)
        {

            List<City>? cities = new List<City>();
            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            string json = await response.Content.ReadAsStringAsync();
                            cities = JsonConvert.DeserializeObject<List<City>>(json);
                            break;
                        case System.Net.HttpStatusCode.ServiceUnavailable:
                            MessageBox.Show("Daily Limited exceeded. Try again tomorrow", "Limit Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        default:
                            MessageBox.Show("Request Failed", "Unknown Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                MessageBox.Show("Request Failed", "UnknownError", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return cities ?? new List<City>();
        }

        public static async Task<CurrentWeather> GetCurrentWeather(string cityKey)
        {
            CurrentWeather? currentWeather = null;

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        string json = await response.Content.ReadAsStringAsync();
                        var weatherlist = JsonConvert.DeserializeObject<List<CurrentWeather>>(json);
                        currentWeather = weatherlist?.FirstOrDefault();
                        break;
                    case System.Net.HttpStatusCode.ServiceUnavailable:
                        MessageBox.Show("Daily Limited exceeded. Try again tomorrow", "Limit Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                    default:
                        MessageBox.Show("Request Failed", "Unknown Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }

            return currentWeather ?? new CurrentWeather();
        }
    }
}
