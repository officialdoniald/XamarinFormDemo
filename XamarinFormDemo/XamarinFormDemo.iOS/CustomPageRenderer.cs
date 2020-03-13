using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormDemo.iOS;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
namespace XamarinFormDemo.iOS
{
    public class CustomPageRenderer : PageRenderer, IUIGestureRecognizerDelegate
    {
        [Preserve(Conditional = true)]
        public CustomPageRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (NavigationController != null)
            {
                NavigationController.InteractivePopGestureRecognizer.Delegate = this;
                NavigationController.InteractivePopGestureRecognizer.Enabled = true;
            }
        }
    }
}