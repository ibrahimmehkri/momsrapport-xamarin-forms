using System;
using System.Windows.Input;
using Xamarin.Forms; 

namespace MomsRapportApp.Behaviors
{
    public class ItemSelectedToCommandBehavior : Behavior<ListView>
    {
        public ItemSelectedToCommandBehavior()
        {
        }

        public static BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ItemSelectedToCommandBehavior), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            if(bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }
            bindable.ItemSelected += OnItemSelected; 
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Command?.Execute(args.SelectedItem);
        }
    }
}
