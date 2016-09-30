using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator
{
    public class LoanData
    {
        #region Private Variables
        private double _dailyInterest;
        private double _annualInterest;
        private DateTime _startDate;
        private DateTime _endDate;
        private double _term;
        private double _dailyPayment;
        #endregion
        public double DailyInterest
        {
            get { return _dailyInterest; }
            set
            {
                _dailyInterest = value;
                _annualInterest = value * 365;
            }
        }

        public double AnnualInterest
        {
            get { return _annualInterest; }
            set
            {
                _annualInterest = value;
                _dailyInterest = value / 365;
            }
        }

        public double LoanAmount { get; set; }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                Term = CountDays();
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                Term = CountDays();
            }
        }

        public double Term
        {
            get { return _term; }
            set
            {
                _term = value;

                _dailyPayment = PMT();
            }
        }        

        public double DailyPayment
        {
            get { return _dailyPayment; }
            set
            {
                _dailyPayment = value;
                _term = Nper();
            }
        }

        public double CountDays()
        {
            return (EndDate - StartDate).Days;
        }
        public double PMT()
        {
            double rate = DailyInterest / 100;
            double pmt = LoanAmount * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Term))));
            return Math.Round(pmt, 2);
        }
        public double Nper()
        {
            double rate = DailyInterest / 100;
            //double nper = -Math.Log((1 - rate * LoanAmount / DailyPayment), Math.E) / Math.Log((1 + rate), Math.E);
            double nper = LoanAmount / rate;
            return Math.Round( nper);
        }
    }
}
