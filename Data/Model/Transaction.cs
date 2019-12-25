using Data.Base;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Transaction : BaseModel
    {
        public DateTimeOffset TransactionDate { get; set; }
        public int Costs { get; set; }
        public string ApprovedBy { get; set; }
        public DateTimeOffset ApprovedDate { get; set; }
        public string Status { get; set; }
        public bool IsApproved { get; set; }

        public Transaction() { }

        public Transaction(TransactionVM transactionVM)
        {
            this.TransactionDate = DateTimeOffset.Now.LocalDateTime;
            this.Costs = transactionVM.Costs;
            this.IsApproved = false;
        }

        public void Update(TransactionVM transactionVM)
        {
            this.ApprovedBy = transactionVM.ApprovedBy;
            this.ApprovedDate = DateTimeOffset.Now.LocalDateTime;
            this.Status = transactionVM.Status;
            this.IsApproved = true;
        }
    }
}
