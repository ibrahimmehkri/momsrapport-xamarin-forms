using System;
using System.Collections.Generic;
using System.Diagnostics;
using MomsRapportApp.Data;
using MomsRapportApp.ViewModels;
using Xamarin.Forms;

namespace MomsRapportApp.Views
{
    public partial class EntriesPage : ContentPage
    {

        AppData appData = ((App)Application.Current).AppData;
        public EntriesPage()
        {
            InitializeComponent();
            Title = "Transactions";
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnAddEntryClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EntryPage());
            appData.Prepare(new TransactionVM(), true);
        }

        void OnMoreButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ShareOptionsPage());
        }

        async void OnItemClicked(object sender, SelectedItemChangedEventArgs args)
        {
            await Navigation.PushAsync(new EntryDetailsPage());
            appData.Prepare((TransactionVM)args.SelectedItem, false); 
        }
    }
}
