using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModel
{
    public class TransactionDetailVM
    {
        public int Id { get; set; }
        public string PlatNumber { get; set; }
        public string STNKParkingReceipt { get; set; }
        public int Transaction { get; set; }
        public int User { get; set; }
        public int Vehicle { get; set; }
    }
}
