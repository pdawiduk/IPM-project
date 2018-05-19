using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IPM_FINAL_REALLY
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static HttpClient client = new HttpClient();
        static async Task<List<Rate>> GetCurrencyAsync()
        {

            List<MainRate> tmp = null;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage respones = await client.GetAsync("http://api.nbp.pl/api/exchangerates/tables/A/?format=json");

            if (respones.IsSuccessStatusCode)
            {

                string x = await respones.Content.ReadAsStringAsync();
                try
                {
                    tmp = JsonConvert.DeserializeObject<List<MainRate>>(x);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
               
            }
            return new List<Rate>();
        }
        public MainPage()
        {
            this.InitializeComponent();

            GetCurrencyAsync();

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
