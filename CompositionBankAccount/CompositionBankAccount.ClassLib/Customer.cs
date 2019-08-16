using System;
using System.Collections.Generic;
using System.Text;

namespace CompositionBankAccount.ClassLib
{
    class Customer
    {
        int id;
        List<Account> accounts = new List<Account>();

        public Customer(int id, List<Account> accounts)
        {
            throw new NotImplementedException();
        }
        public Customer(List<Account> accounts)
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public List<Account> Accounts
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public int Rating
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal GetDebts()
        {
            throw new NotImplementedException();
        }
        public decimal GetAssets()
        {
            throw new NotImplementedException();
        }
        public decimal GetTotalBalance()
        {
            throw new NotImplementedException();
        }
    }
}
