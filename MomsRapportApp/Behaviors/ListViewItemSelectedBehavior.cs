using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MomsRapportApp.Behaviors
{
    public class ListViewItemSelectedBehavior : Behavior<ListView>
    {
        public ListView AssociatedObject { get; set; }

        public static readonly BindableProperty CommandProperty =
                   BindableProperty.Create("Command", typeof(ICommand), typeof(ListViewItemSelectedBehavior), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
            bindable.ItemSelected += Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Command?.Execute(e.SelectedItem);
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            BindingContext = AssociatedObject.BindingContext;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
            bindable.ItemSelected -= Bindable_ItemSelected;
        }


    }

    }