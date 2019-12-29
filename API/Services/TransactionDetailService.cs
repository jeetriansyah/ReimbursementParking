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
    public class TransactionDetailService : ITransactionDetailService
    {
        private ITransactionDetailRepository _transDetailRepository = new TransactionDetailRepository();

        public TransactionDetailService() { }

        public TransactionDetailService(ITransactionDetailRepository transDetailRepository)
        {
            _transDetailRepository = transDetailRepository;
        }

        public int Create(TransactionDetailVM transactionVM)
        {
            if (string.IsNullOrWhiteSpace(transactionVM.PlatNumber) || string.IsNullOrWhiteSpace(transactionVM.User.ToString()) || string.IsNullOrWhiteSpace(transactionVM.Vehicle.ToString()))
            {
                return 0;
            }
            else
            {
                return _transDetailRepository.Create(transactionVM);
            }
        }

        public IEnumerable<TransactionDetail> Get()
        {
            return _transDetailRepository.Get();
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
