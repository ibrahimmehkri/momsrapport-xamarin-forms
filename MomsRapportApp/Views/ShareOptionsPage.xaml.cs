using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MomsRapportApp.Views
{
    public partial class ShareOptionsPage : ContentPage
    {
        public List<ToolListItem> List { get; set; }

        public ShareOptionsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            List = new List<ToolListItem>();
            List.Add(new ToolListItem
            {
                ToolIconUri = "https://img.icons8.com/ios/50/000000/statistics-report.png",
                Text = "Sales tax report",
                RelatedTool = Tools.SalexTaxReport
            });
            List.Add(new ToolListItem
            {
                ToolIconUri = "https://img.icons8.com/ios/50/000000/settings.png",
                Text = "Settings",
                RelatedTool = Tools.Settings
            });
            toolsListView.ItemsSource = List;
        }

        void Handle_Clicked(object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if(args.SelectedItem != null)
            {
                toolsListView.SelectedItem = null;
                ToolListItem item = (ToolListItem)args.SelectedItem;
                switch (item.RelatedTool)
                {
                    case Tools.SalexTaxReport:
                        Navigation.PushAsync(new SalesTaxReportPage());
                        break;
                    case Tools.Settings:
                        Navigation.PushAsync(new SettingsPage());
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public enum Tools { Settings, SalexTaxReport };

    public class ToolListItem {
        public string ToolIconUri { get; set; }
        public string Text { get; set; }
        public Tools RelatedTool { get; set; }
    }

}
