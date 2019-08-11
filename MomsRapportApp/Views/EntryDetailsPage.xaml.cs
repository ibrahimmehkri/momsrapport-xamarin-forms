using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace MomsRapportApp.Views
{
    public partial class EntryDetailsPage : ContentPage
    {
        public EntryDetailsPage()
        {
            InitializeComponent();
            Title = "Details";
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }

}
