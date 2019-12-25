using Data.Base;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class TransactionDetail : BaseModel
    {
        public string PlatNumber { get; set; }
        public string STNKParkingReceipt { get; set; }
        public Transaction Transaction { get; set; }
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }

        public TransactionDetail() { }

        public TransactionDetail(TransactionDetailVM transactionDetailVM)
        {
            this.PlatNumber = transactionDetailVM.PlatNumber;
            this.STNKParkingReceipt = transactionDetailVM.STNKParkingReceipt;
        }

        public void Update(TransactionDetailVM transactionDetailVM)
        {
            this.PlatNumber = transactionDetailVM.PlatNumber;
            this.STNKParkingReceipt = transactionDetailVM.STNKParkingReceipt;
        }

    }
}
