using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator
{
    public class LoanData : INotifyPropertyChanged
    {
        public LoanData()
        {
            _startDate = DateTime.Today.Date;
            _endDate = DateTime.Today.Date;
            Items = new ObservableCollection<GridItem>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #region Private Variables
        private double _dailyInterest;
        private double _annualInterest;
        private double _loanAmount;
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

                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterest"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterest"));
            }
        }

        public double AnnualInterest
        {
            get { return _annualInterest; }
            set
            {
                _annualInterest = value;
                _dailyInterest = value / 365;

                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterest"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterest"));
            }
        }

        public double LoanAmount
        {
            get { return _loanAmount; }
            set
            {
                _loanAmount = value;

                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmount"));
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                Term = CountDays();

                OnPropertyChanged(new PropertyChangedEventArgs("Term"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDate"));
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                Term = CountDays();

                OnPropertyChanged(new PropertyChangedEventArgs("Term"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDate"));
            }
        }

        public double Term
        {
            get { return _term; }
            set
            {
                _term = value;
                _dailyPayment = PMT();

                OnPropertyChanged(new PropertyChangedEventArgs("Term"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));

                Graph();
            }
        }

        public double DailyPayment
        {
            get { return _dailyPayment; }
            set
            {
                _dailyPayment = value;
                _term = Nper();

                OnPropertyChanged(new PropertyChangedEventArgs("Term"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
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
            double nper = -Math.Log((1 - rate * LoanAmount / DailyPayment), Math.E) / Math.Log((1 + rate), Math.E);
            //double nper = LoanAmount / rate;
            return Math.Round(nper);
        }

        private void Graph()
        {
            Items.Clear();
            double amount = LoanAmount;
            double dailyInterest = DailyInterest / 100;
            //Items = new List<GridItem>();

            Items.Add(new GridItem() { Date = "Date", EndingBalance = "EndingBalance", Interest = "Interest", Payment = "Payment", PaymentNumber = "PaymentNumber", Principal = "Principal", StartingBalance = "StartingBalance" });

            for (int i = 1; i <= Term; i++)
            {
                DateTime dateTime = StartDate.AddDays(1);
                double principal = PMT() - amount * dailyInterest;
                double startingBalance = amount - principal;
                double interest = startingBalance * dailyInterest;
                amount -= principal;
                Items.Add(new GridItem() { PaymentNumber = i.ToString(), Date = dateTime.Date.ToString(), Payment = DailyPayment.ToString(), Principal = principal.ToString(), Interest = interest.ToString(), StartingBalance = startingBalance.ToString() });

                OnPropertyChanged(new PropertyChangedEventArgs("Items"));
            }
        }
        public ObservableCollection<GridItem> Items { get; set; }
    }
}
