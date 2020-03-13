using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormDemo.BLL;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormDemo
{
    public partial class App : Application
    {
        public App()
        {
            GlobalVariableContainer.ConnectionString = XamarinFormDemo.Properties.Resources.ResourceManager.GetString("ConnectionString");

            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new AbsoluteLayoutDemo();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
