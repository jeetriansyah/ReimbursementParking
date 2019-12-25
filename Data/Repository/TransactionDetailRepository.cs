using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class TransactionDetailRepository : ITransactionDetailRepository
    {
        public int Create(TransactionDetailVM transactionVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionDetail> Get()
        {
            throw new NotImplementedException();
        }

        public TransactionDetail Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(int Id, TransactionDetailVM transactionVM)
        {
            throw new NotImplementedException();
        }
    }
}
