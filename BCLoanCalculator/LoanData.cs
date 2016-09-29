using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator
{
   public class LoanData
    {
        public double Payment { get; set; }

        public double DailyPercent { get; set; }

        public double AnnualPercent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double TermsOfLoan { get; set; }

        public double PV { get; set; }

        public double t()
        {
            TimeSpan t = EndDate - StartDate;
            return t.Days;
        }
        public double PMT()
        {
            double rate = DailyPercent / 100;
            double pmt = Math.Round(PV * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), TermsOfLoan)))), 2);
            return pmt;
        }
        public double Nper()
        {
            double rate = DailyPercent / 100;
            double nper = Math.Round(-Math.Log((1 - rate * PV / Payment), Math.E) / Math.Log((1 + rate), Math.E));
            return nper;
        }
    }
}
