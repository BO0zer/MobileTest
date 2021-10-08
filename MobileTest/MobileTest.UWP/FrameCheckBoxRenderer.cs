using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using MobileTest;
using MobileTest.UWP;

[assembly: ExportRenderer(typeof(FrameCheckBox), typeof(FrameCheckBoxRenderer))]
namespace MobileTest.UWP
{
    class FrameCheckBoxRenderer: CheckBoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.CheckBox> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //Control.Background = new SolidColorBrush(Windows.UI.Colors.LightBlue);
                //Control.BorderBrush = new SolidColorBrush(Windows.UI.Colors.CadetBlue);
            }
        }
    }
}
