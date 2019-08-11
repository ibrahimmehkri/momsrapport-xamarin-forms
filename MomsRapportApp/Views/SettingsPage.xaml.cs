using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MomsRapportApp.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Handle_Clicked(object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }
    }
}
