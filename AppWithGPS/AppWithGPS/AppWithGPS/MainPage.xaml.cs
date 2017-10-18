using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppWithGPS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //Github for documentation for geolocator plugin: https://github.com/jamesmontemagno/GeolocatorPlugin
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));

            lblLongitude.Text = position.Longitude.ToString();
            lblLatitude.Text = position.Latitude.ToString();
        }
    }
}
