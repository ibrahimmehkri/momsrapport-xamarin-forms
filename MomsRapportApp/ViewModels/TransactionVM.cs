using System;
using SQLite;
namespace MomsRapportApp.ViewModels
{
    [Table("transactions")]
    public class TransactionVM : ViewModelBase
    {
        public TransactionVM()
        {
        }

        double amount;
        bool isIncome;
        DateTime date;
        int moms;
        string description;
        long accountNumber;

        public long AccountNumber
        {
            get { return accountNumber; }
            set { SetProperty(ref accountNumber, value); }
        }

        public double Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        public bool IsIncome
        {
            get { return isIncome; }
            set { SetProperty(ref isIncome, value); }
        }

        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public int Moms
        {
            get { return moms;  }
            set { SetProperty(ref moms, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
