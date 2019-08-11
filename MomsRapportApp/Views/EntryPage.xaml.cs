using System;
using System.Collections.Generic;
using MomsRapportApp.Data;
using MomsRapportApp.ViewModels;
using Xamarin.Forms;

namespace MomsRapportApp.Views
{
    public partial class EntryPage : ContentPage
    {
        AppData appData = ((App)Application.Current).AppData;
        public EntryPage()
        {
            InitializeComponent();
            datePicker.MinimumDate = new DateTime(2000, 1, 1);
            datePicker.MaximumDate = DateTime.Now;
        }


        public void GoBackButtonClicked(object sender, EventArgs args)
        {
            appData.Keep();
            Navigation.PopModalAsync();
        }

        public void CancelButtonClicked(object sender, EventArgs args)
        {
            appData.Remove();
            Navigation.PopModalAsync();
        }
    }
}
