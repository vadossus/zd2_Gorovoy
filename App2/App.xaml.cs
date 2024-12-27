using System;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;
using Xamarin.Forms.Xaml;

namespace App2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var assembly = typeof(App).Assembly;
            using (var stream = assembly.GetManifestResourceStream("App2.styles.css")) 
            {
                if (stream != null)
                {
                    this.Resources.Add(StyleSheet.FromReader(new System.IO.StreamReader(stream)));
                }
            }
            MainPage = new NavigationPage(new MainPage());
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
