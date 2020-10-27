using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleOrderBooking
{
    public class ORDNN
    {

		public string COMP { get; set; }
		public string UNIT { get; set; }
		public string DCOD { get; set; }
		public string ORDN { get; set; }
		public string DBCD { get; set; }
		public DateTime ORDT { get; set; }
		public string PORD { get; set; }
		public string PCOD { get; set; }
		public string TXCD { get; set; }
		public string BRCD { get; set; }
		public string ICOD { get; set; }
		public string TRCD { get; set; }
		public decimal QNTY { get; set; }
		public decimal RATE { get; set; }
		public decimal ARAT { get; set; }
		public decimal OSRC { get; set; }
		public string PARTY { get; set; }
		public string AGENT { get; set; }
		public string ITEM { get; set; }
		public string GRADE { get; set; }

		public string DCODE { get; set; }
		public string ADDR { get; set; }

	}

    public class ORDMANT
    {

        public string ORDN { get; set; }

        public string ITEM { get; set; }

    }
}