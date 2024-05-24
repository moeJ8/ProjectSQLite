using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite
{
    public class PaymentInfo
    {
        public double TotalPrice { get; set; }
        public int ID { get; internal set; }
        public string CardHolderName { get; internal set; }
        public string CardNumber { get; internal set; }
        public string ExpiryMonth { get; internal set; }
        public string ExpiryYear { get; internal set; }
        public string CVV { get; internal set; }
    }
}
