﻿using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class TransactionRepository : ITransactionRepository
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
