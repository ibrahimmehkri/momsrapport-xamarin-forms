using System;
using System.Collections.Generic;
using System.ComponentModel;
using MomsRapportApp.Models; 

namespace MomsRapportApp.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        public ListViewModel()
        {
            
        }

        private List<Transaction> _transactions;
        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set
            {
                if(_transactions != value)
                {
                    _transactions = value;
                    OnPropertyChanged("Transactions");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
