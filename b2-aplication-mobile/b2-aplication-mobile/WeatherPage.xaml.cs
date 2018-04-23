using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using b2_aplication_mobile.Models;

namespace b2_aplication_mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = new Weather();

        }
        public async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            Weather weather = await App1.Service.WeatherService.GetWeather("75000");
            this.LabelCity.Text = weather.Title;
            this.LabelTempérature.Text = weather.Temperature;
        }
    }
}