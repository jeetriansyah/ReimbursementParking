using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class TransactionDetailRepository : ITransactionDetailRepository
    {
        MyContext myContext = new MyContext();

        public int Create(TransactionDetailVM transactionVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionDetail> Get()
        {
            var transDetail = myContext.TransactionDetails.Include("Transaction").Include("User").Include("Vehicle").Where(td => td.IsDelete == false);
            return transDetail;
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
