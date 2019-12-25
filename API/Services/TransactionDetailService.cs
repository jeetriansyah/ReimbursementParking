using API.Services.Interface;
using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class TransactionDetailService : ITransactionDetailService
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
