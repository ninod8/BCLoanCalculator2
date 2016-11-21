using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator
{
    public class GridItem
    {
        private LoanData Data = new LoanData();

        public string PaymentNumber { get; set; }
        public string Date { get; set; }
        public string Payment { get; set; }
        public string Principal { get; set; }
        public string Interest { get; set; }
        public string StartingBalance { get; set; }
        public string EndingBalance { get; set; }
        public string PeymentSum { get; set; }
        public string InterestSum { get; set; }
    }
}
