using System;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTest
{
    public partial class App : Application
    {
        public App()
        {
            const string url = "http://demo.macroscop.com:8080/configex?login=root";

            InitializeComponent();

            CfgHolder cfgHolder = new CfgHolder(XDocument.Load(url));
            var pageCameraData = new CameraData(cfgHolder);
            var pageCameraFrames = new CameraFrames(cfgHolder);
            MainPage = new TabbedPage
            {
                Children =
                {
                    pageCameraData,
                    pageCameraFrames
                }
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
