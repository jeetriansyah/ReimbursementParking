using API.Services.Interface;
using Data.Model;
using Data.Repository;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository = new TransactionRepository();

        public TransactionService() { }

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        
        public int Create(TransactionVM transactionVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> Get()
        {
            return _transactionRepository.Get();
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
