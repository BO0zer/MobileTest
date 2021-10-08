using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using MobileTest.Utilities;

namespace MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraFrames : ContentPage
    {
        public List<Camera> Cameras { get; set; }
        public CameraFrames(CfgHolder cfgHolder)
        {
            Cameras = cfgHolder.GetChannels();
            InitializeComponent();
            this.BindingContext = this;
        }
        public async void LoadImagesAsync()
        {
            //foreach (var camera in Cameras)
            //{

            //}
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://demo.macroscop.com/")
            };

            FrameReciever frameReciever = new FrameReciever(httpClient);

            var imageBin = await frameReciever.GetFrameByteArray(Cameras[0].Id.ToString(), "root");

        }

        private void ShowImages_Clicked(object sender, EventArgs e)
        {
            LoadImagesAsync();
        }
    }
}