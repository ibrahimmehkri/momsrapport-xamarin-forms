using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MomsRapportApp.ViewModels;
using SQLite;

namespace MomsRapportApp.Data
{
    public class AppData : ViewModelBase
    {

        SQLiteConnection db;
        public AppData()
        {
            string libaryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = "MySQLite.db3";
            string dbPath = Path.Combine(libaryPath, filePath);
            db = new SQLiteConnection(dbPath);
            db.CreateTable<AccountVM>();
            db.CreateTable<TransactionVM>();
            if(db.Table<AccountVM>().Count() == 0)
            {
                AccountVM acc1 = new AccountVM { AccountNumber = 12345678910, AccountType = "Private" };
                AccountVM acc2 = new AccountVM { AccountNumber = 10987654321, AccountType = "Savings" };
                db.Insert(acc1);
                db.Insert(acc2);
            }
            
            Accounts = db.Table<AccountVM>().ToList();
            
            if (db.Table<TransactionVM>().Count() != 0)
            {
                foreach(var item in db.Table<TransactionVM>()){
                    foreach(var acc in Accounts)
                    {
                        if(acc.AccountNumber == item.AccountNumber)
                        {
                            acc.Transactions.Add(item);
                        }
                    }
                }
            }
            ActiveAccount = Accounts[0];
        }

        AccountVM activeAccount;
        public AccountVM ActiveAccount
        {
            get { return activeAccount; }
            set { SetProperty(ref activeAccount, value); }
        }

        TransactionVM activeTransaction;
        public TransactionVM ActiveTransaction
        {
            get { return activeTransaction; }
            set { SetProperty(ref activeTransaction, value); }
        }

        public List<AccountVM> Accounts { get; set; }

        public void Remove()
        {
            TransactionVM transaction = ActiveTransaction;
            ActiveTransaction = null;
            ActiveAccount.Transactions.Remove(transaction);
        }

        public void Keep()
        {
            TransactionVM transaction = ActiveTransaction;
            ActiveTransaction = null;
            transaction.AccountNumber = ActiveAccount.AccountNumber; 
            db.Insert(transaction); 
        }

        public void Prepare(TransactionVM tr, bool isNew)
        {
            ActiveTransaction = tr;
            if (isNew)
            {
                ActiveAccount.Transactions.Add(tr);
            }
        }

        double totalSalesxTaxPaid;
        public double TotalSalesTaxPaid
        {
            get { return totalSalesxTaxPaid; }
            set { SetProperty(ref totalSalesxTaxPaid, value); }
        }

        public List<TransactionVM> GetExpenses() {
            long accountNum = ActiveAccount.AccountNumber;
            var query = from item in db.Table<TransactionVM>() where item.AccountNumber == accountNum && !item.IsIncome select item;
            TotalSalesTaxPaid = query.Sum(delegate (TransactionVM item) { return item.Amount * ((double)item.Moms / 100.0); });
            return query.ToList();
        }
    }
}

