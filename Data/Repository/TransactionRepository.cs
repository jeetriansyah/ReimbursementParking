using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        MyContext myContext = new MyContext();

        public int Create(TransactionVM transactionVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> Get()
        {
            var trans = myContext.Transactions.ToList();
            return trans;
        }

        public Transaction Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(int Id, TransactionVM transactionVM)
        {
            throw new NotImplementedException();
        }
    }
}
