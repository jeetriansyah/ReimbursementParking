using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface ITransactionDetailService
    {
        IEnumerable<TransactionDetail> Get();
        TransactionDetail Get(int Id);
        int Create(TransactionDetailVM transactionVM);
        int Update(int Id, TransactionDetailVM transactionVM);
    }
}
