using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraData : ContentPage
    {
        public List<Camera> Cameras { get; set; } = new List<Camera>();
        public CameraData(CfgHolder cfgHolder)
        {
            InitializeComponent();
            Cameras = cfgHolder.GetChannels();
            BindingContext = this;
        }

    }
}