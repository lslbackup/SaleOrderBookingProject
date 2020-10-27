using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleOrderBooking
{
    public class CONS
    {
      public string ADDR { get; set; }
      public string SRNO { get; set; }
      public string CONCOD { get; set; }
    }

    public class FINITM
    {
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string DVCD { get; set; }
        public string UNIT { get; set; }
    }

    public class PCOD
    {
        public string CODE { get; set; }
        public string TXCD { get; set; }
        public string BRCD { get; set; }
        public string UNIT { get; set; }
    }

}