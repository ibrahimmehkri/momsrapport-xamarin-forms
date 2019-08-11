using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MomsRapportApp.Views;
using MomsRapportApp.Data;

namespace MomsRapportApp
{
    public partial class App : Application
    {
        public AppData AppData { get; set; }

        public App()
        {
            InitializeComponent();
            AppData = new AppData();
            MainPage = new NavigationPage(new EntriesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
