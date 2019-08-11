using System;
using System.Collections.ObjectModel;
using SQLite; 

namespace MomsRapportApp.ViewModels
{
    [Table("accounts")]
    public class AccountVM : ViewModelBase
    {
        public AccountVM()
        {
        }

        long accountNumber;
        string accountType;
        ObservableCollection<TransactionVM> transactions = new ObservableCollection<TransactionVM>();

        public long AccountNumber
        {
            get { return accountNumber; }
            set { SetProperty(ref accountNumber, value); }
        }

        public string AccountType
        {
            get { return accountType; }
            set { SetProperty(ref accountType, value); }
        }

        [Ignore]
        public ObservableCollection<TransactionVM> Transactions
        {
            get { return transactions; }
            set { SetProperty(ref transactions, value); }
        }


        public override string ToString()
        {
            return $"{AccountType} - {AccountNumber}";
        }
    }
}
