using System;
using System.Globalization;
using Xamarin.Forms;

namespace MomsRapportApp.Behaviors
{
    public class OnEntryUnfocusedBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Unfocused += Bindable_Unfocused;
        }

        private void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrWhiteSpace(entry.Text))
            {
                double amount = Double.Parse(entry.Text, NumberStyles.Float | NumberStyles.AllowThousands); 
                CultureInfo.CurrentCulture = new CultureInfo("sv-SE");
                entry.Text = amount.ToString("c");
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Unfocused -= Bindable_Unfocused;
        }
    }
}
