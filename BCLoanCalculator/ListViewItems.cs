using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator
{
    public class ListViewItems
    {
        LoanData Data = new LoanData();
        public List<int> NumberOfPayment()
        {
            for (int i = 1; i <= Data.Term; i++)
            {
                NumberOfPayment().Add(i);
            }
            return NumberOfPayment();
        }
        public List<DateTime> Date()
        {
            for (int i = 0; i < Data.Term; i++)
            {
                DateTime dateTime = Data.StartDate.AddDays(1);
                Date().Add(dateTime);
            }
            return Date();
        }
        public List<double> Payment()
        {
            for (int i = 0; i < Data.Term; i++)
            {
                Payment().Add(Data.DailyPayment);
            }
            return Payment();
        }
        public List<double> Principal()
        {
            for (int i = 0; i < Data.Term; i++)
            {
                double principal = Data.PMT() - Data.LoanAmount * Data.DailyInterest / 100;
                Principal().Add(principal);
                Data.LoanAmount -= principal;
            }
            return Principal();
        }
        public List<double> Interest()
        {
            for (int i = 0; i < Data.Term; i++)
            {
                double startingBalance = Data.LoanAmount - (Data.PMT() - Data.LoanAmount * Data.DailyInterest / 100);
                double interest = startingBalance * Data.DailyInterest / 100;
                Interest().Add(interest);
            }
            return Interest();
        }
        public List<double> StartingBalance()
        {
            for (int i = 0; i < Data.Term; i++)
            {
                double startingBalance = Data.LoanAmount - (Data.PMT() - Data.LoanAmount * Data.DailyInterest / 100);
                StartingBalance().Add(startingBalance);
            }
            return StartingBalance();
        }
    }
}
