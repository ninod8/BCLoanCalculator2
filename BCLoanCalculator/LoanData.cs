using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BCLoanCalculator
{
    public class LoanData : INotifyPropertyChanged
    {
        public LoanData()
        {
            _startDateDaily = DateTime.Today.Date;
            _endDateDaily = DateTime.Today.Date;
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
        private DateTime _startDateDaily;
        private DateTime _endDateDaily;
        private double _termDaily;
        private double _dailyPayment;
        private DateTime _startDateMonthly;
        private DateTime _endDateMonthly;
        private double _termMonthly;
        private double _monthlyPayment;
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

        public DateTime StartDateDaily
        {
            get { return _startDateDaily; }
            set
            {
                _startDateDaily = value;
                TermDaily = CountDays();

                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
            }
        }

        public DateTime StartDateMonthly
        {
            get { return _startDateMonthly; }
            set
            {
                _startDateMonthly = value;
                TermMonthly = CountMonths();

                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
            }
        }

        public DateTime EndDateDaily
        {
            get { return _endDateDaily; }
            set
            {
                _endDateDaily = value;
                TermDaily = CountDays();

                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
            }
        }

        public DateTime EndDateMonthly
        {
            get { return _endDateMonthly; }
            set
            {
                _endDateMonthly = value;
                TermMonthly = CountDays();

                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
            }
        }

        public double TermDaily
        {
            get { return _termDaily; }
            set
            {
                _termDaily = value;
                _dailyPayment = PMTDaily();
                GraphDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
            }
        }

        public double TermMonthly
        {
            get { return _termMonthly; }
            set
            {
                _termMonthly = value;
                _dailyPayment = PMTMonthly();
                GraphMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
            }
        }

        public double DailyPayment
        {
            get { return _dailyPayment; }
            set
            {
                _dailyPayment = value;
                _termDaily = NperDaily();
                GraphDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
            }
        }

        public double MonthlyPayment
        {
            get { return _monthlyPayment; }
            set
            {
                _monthlyPayment = value;
                _termMonthly = NperMonthly();
                GraphMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
            }
        }

        public double CountDays()
        {
            return (EndDateDaily - StartDateDaily).Days;
        }

        public double CountMonths()
        {
            return StartDateDaily.Subtract(EndDateDaily).Days / (365.25 / 12);
        }

        public double PMTDaily()
        {
            double rate = DailyInterest / 100;
            double pmt = LoanAmount * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), TermDaily))));
            return Math.Round(pmt, 2);
        }

        public double PMTMonthly()
        {
            double rate = AnnualInterest / 1200;
            double pmt = LoanAmount * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), TermDaily))));
            return Math.Round(pmt, 2);
        }

        public double NperDaily()
        {
            double rate = DailyInterest / 100;
            double nper = -Math.Log((1 - rate * LoanAmount / DailyPayment), Math.E) / Math.Log((1 + rate), Math.E);
            return Math.Round(nper);
        }

        public double NperMonthly()
        {
            double rate = AnnualInterest / 1200;
            double nper = -Math.Log((1 - rate * LoanAmount / DailyPayment), Math.E) / Math.Log((1 + rate), Math.E);
            return Math.Round(nper);
        }

        public void GraphDaily()
        {
            Items.Clear();
            double amount = LoanAmount;
            double dailyInterest = DailyInterest / 100;

            Items.Add(new GridItem() { Date = "თარიღი", EndingBalance = "EndingBalance", Interest = "პროცენტი", Payment = "გადასახადი", PaymentNumber = "#", Principal = "ძირი", StartingBalance = "საბოლოო ბალანსი" });

            for (int i = 1; i <= TermDaily; i++)
            {
                DateTime dateTime = StartDateDaily.AddDays(i - 1);
                double principal = PMTDaily() - amount * dailyInterest;
                double interest = amount * dailyInterest;
                Items.Add(new GridItem() { PaymentNumber = i.ToString(), Date = dateTime.Date.ToString("dd/MM/yyyy"), Payment = DailyPayment.ToString(), Principal = Math.Round(principal, 2).ToString(), Interest = Math.Round(interest, 2).ToString(), StartingBalance = Math.Round(amount, 2).ToString() });
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("Items"));
            }
        }
        public void GraphMonthly()
        {
            Items.Clear();
            double amount = LoanAmount;
            double monthlyInterest = AnnualInterest / 1200;

            Items.Add(new GridItem() { Date = "თარიღი", EndingBalance = "EndingBalance", Interest = "პროცენტი", Payment = "გადასახადი", PaymentNumber = "#", Principal = "ძირი", StartingBalance = "საბოლოო ბალანსი" });

            for (int i = 1; i <= TermMonthly; i++)
            {
                DateTime dateTime = StartDateMonthly.AddMonths(i - 1);
                double principal = PMTMonthly() - amount * monthlyInterest;
                double interest = amount * monthlyInterest;
                Items.Add(new GridItem() { PaymentNumber = i.ToString(), Date = dateTime.Date.ToString("MM/yyyy"), Payment = MonthlyPayment.ToString(), Principal = Math.Round(principal, 2).ToString(), Interest = Math.Round(interest, 2).ToString(), StartingBalance = Math.Round(amount, 2).ToString() });
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("ItemsMonthly"));
            }
        }
        public ObservableCollection<GridItem> ItemsMonthly { get; set; }
        public ObservableCollection<GridItem> Items { get; set; }
    }
}
