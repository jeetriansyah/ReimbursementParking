using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface ITransactionDetailRepository
    {
        IEnumerable<TransactionDetail> Get();
        TransactionDetail Get(int Id);
        int Create(TransactionDetailVM transactionVM);
        int Update(int Id, TransactionDetailVM transactionVM);
    }
}
