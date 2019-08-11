using System;
using System.Collections.Generic;
using MomsRapportApp.Data;
using Xamarin.Forms;

namespace MomsRapportApp.Views
{
    public partial class SalesTaxReportPage : ContentPage
    {
        AppData appData = ((App)Application.Current).AppData;
        public SalesTaxReportPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            expensesListView.ItemsSource = appData.GetExpenses();
        }

        void Handle_Clicked(object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }

        void OnSelectedIndexChanged(object sender, EventArgs args)
        {
            expensesListView.ItemsSource = appData.GetExpenses();
        }

    }
}
