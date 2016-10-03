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

        public int PaymentNumber { get; set; }
        public DateTime DateTime { get; set; }
        public double Payment { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double StartingBalance { get; set; }
        public double EndingBalance { get; set; }
    }
}
