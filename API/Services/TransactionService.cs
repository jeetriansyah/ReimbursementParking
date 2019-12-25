using API.Services.Interface;
using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class TransactionService : ITransactionService
    {
        public int Create(TransactionVM transactionVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> Get()
        {
            throw new NotImplementedException();
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
