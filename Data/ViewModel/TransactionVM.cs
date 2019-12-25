using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModel
{
    public class TransactionVM
    {
        public int Id { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Costs { get; set; }
        public string ApprovedBy { get; set; }
        public DateTimeOffset ApprovedDate { get; set; }
        public string Status { get; set; }
    }
}
