using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get();
        Transaction Get(int Id);
        int Create(TransactionVM transactionVM);
        int Update(int Id, TransactionVM transactionVM);
    }
}
