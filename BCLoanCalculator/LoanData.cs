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
            _endDateMonthly = DateTime.Today.Date;
            _startDateMonthly = DateTime.Today.Date;
            _endDateFlat = DateTime.Today.Date;
            _startDateFlat = DateTime.Today.Date;
            _startDateFlatDaily = DateTime.Today.Date;
            _endDateFlatDaily = DateTime.Today.Date;
            Items = new ObservableCollection<GridItem>();
            ItemsMonthly = new ObservableCollection<GridItem>();
            FlatPercentageItems = new ObservableCollection<GridItem>();
            FlatDailyItems = new ObservableCollection<GridItem>();
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
        private DateTime _releaseDate;
        private DateTime _startDateMonthly;
        private DateTime _endDateMonthly;
        private double _termMonthly;
        private double _monthlyPayment;
        private DateTime _endDateFlat;
        private DateTime _startDateFlat;
        private DateTime _releaseDateFlat;
        private double _termFlat;
        private double _monthlyPaymentFlat;
        private double _dailyPaymentFlat;
        private DateTime _endDateFlatDaily;
        private DateTime _startDateFlatDaily;
        private double _termFlatDaily;
        private double _annualInterestForMonthly;
        private double _monthlyInterest;

        #endregion

        public double MonthlyInterest
        {
            get { return _monthlyInterest; }
            set
            {
                _monthlyInterest = value;
                _annualInterestForMonthly = Math.Round(value * 12, 3, MidpointRounding.AwayFromZero);

                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterest"));
            }
        }

        public double AnnualInterestForMonthly
        {
            get { return _annualInterestForMonthly; }
            set
            {
                _annualInterestForMonthly = value;
                _monthlyInterest = Math.Round(value/12,3,MidpointRounding.AwayFromZero);
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterest"));
            }
        }

        public double DailyInterest
        {
            get { return _dailyInterest; }
            set
            {
                _dailyInterest = value;
                _annualInterest = Math.Round(value * 365, 3, MidpointRounding.AwayFromZero);

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
                _dailyInterest = Math.Round(value / 365,3,MidpointRounding.AwayFromZero);

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

        public DateTime ReleaseDate //add a method
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
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

        public DateTime EndDateMonthly
        {
            get { return _endDateMonthly; }
            set
            {
                _endDateMonthly = value;
                TermMonthly = CountMonths();

                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
            }
        }

        public DateTime ReleaseDateFlat //add a method
        {
            get { return _releaseDateFlat; }
            set { _releaseDateFlat = value; }
        }

        public DateTime StartDateFlat
        {
            get { return _startDateFlat; }
            set
            {
                _startDateFlat = value;
                TermFlat = CountMonthsForFlat();

                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
            }
        }

        public DateTime EndDateFlat
        {
            get { return _endDateFlat; }
            set
            {
                _endDateFlat = value;
                TermFlat = CountMonthsForFlat();

                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
            }
        }

        public DateTime StartdateFlatDaily
        {
            get { return _startDateFlatDaily; }
            set
            {
                _startDateFlatDaily = value;
                TermFlatDaily = CountDaysForFlatDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
            }
        }

        public DateTime EndDateFlatDaily
        {
            get { return _endDateFlatDaily; }
            set
            {
                _endDateFlatDaily = value;
                TermFlatDaily = CountDaysForFlatDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
            }
        }

        public double TermDaily
        {
            get { return _termDaily; }
            set
            {
                _termDaily = value;
                _dailyPayment = PMTDaily();
                //DateTime today = DateTime.Now;
               // _endDateDaily = today.AddDays(TermDaily);
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
                _monthlyPayment = PMTMonthly();
                GraphMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
            }
        }

        public double TermFlat
        {
            get { return _termFlat; }
            set
            {
                _termFlat = value;
                _monthlyPaymentFlat = FlatMonthly();
                GraphFlatPercentageMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
            }
        }

        public double TermFlatDaily
        {
            get { return _termFlatDaily; }
            set
            {
                _termFlatDaily = value;
                _dailyPaymentFlat = FlatDaily();
                GraphFlatPercentageDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
            }
        }

        public double DailyPayment
        {
            get { return _dailyPayment; }
            set
            {
                _dailyPayment = value;
                _termDaily = NperDaily();
                //GraphDaily();
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

        public double MonthlyPaymentFlat
        {
            get { return _monthlyPaymentFlat; }
            set
            {
                _monthlyPaymentFlat = value;
                _termFlat = NperMonthlyFlat();
                GraphFlatPercentageMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
            }
        }

        public double DailyPaymentFlat
        {
            get { return _dailyPaymentFlat; }
            set
            {
                _dailyPaymentFlat = value;
                _termFlatDaily = NperDailyFlat();
                GraphFlatPercentageDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
            }
        }

        public double CountDays()
        {
            return (EndDateDaily - StartDateDaily).Days;
        }

        public double CountDaysForMonthly()
        {
            return (EndDateMonthly - StartDateMonthly).Days;
        }

        public double CountDaysForFlat()
        {
            return (EndDateFlat - StartDateFlat).Days;
        }

        public double CountMonths()
        {
            return (EndDateMonthly.Month - StartDateMonthly.Month) + 12 * (EndDateMonthly.Year - StartDateMonthly.Year);
        }

        public double CountMonthsForFlat()
        {
            return (EndDateFlat.Month - StartDateFlat.Month) + 12 * (EndDateFlat.Year - StartDateFlat.Year);
        }

        public double CountDaysForFlatDaily()
        {
            return (EndDateFlatDaily - StartdateFlatDaily).Days;
        }

        public double PMTDaily()
        {
            double rate = DailyInterest / 100;
            double pmt = LoanAmount * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), TermDaily))));
            return Math.Round(pmt, 2, MidpointRounding.AwayFromZero);
        }

        public double PMTMonthly()
        {
            double rate = DailyInterest * CountDaysForMonthly() / (100 * TermMonthly);
            if (rate == 0)
            {
                rate = DailyInterest * TermMonthly * 30 / (100 * TermMonthly);
            }
            double pmt = LoanAmount * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), TermMonthly))));
            return Math.Round(pmt, 2, MidpointRounding.AwayFromZero);
        }

        public double FlatMonthly()
        {
            double rate = ((AnnualInterestForMonthly / 365) * (CountDaysForFlat()) / 100);
            if (rate == 0)
            {
                rate = (AnnualInterestForMonthly / 365) * TermFlat * 30 / 100;
            }
            double flatPayment = (LoanAmount + (rate * LoanAmount)) / TermFlat;
            return Math.Round(flatPayment, 2, MidpointRounding.AwayFromZero);
        }

        public double FlatDaily()
        {
            double rate = DailyInterest * CountDaysForFlatDaily() / 100;
            double flatPayment = (LoanAmount + (rate * LoanAmount)) / TermFlatDaily;
            return Math.Round(flatPayment, 2, MidpointRounding.AwayFromZero);
        }

        public double NperDaily()
        {
            double rate = DailyInterest / 100;
            double nper = -Math.Log((1 - rate * LoanAmount / DailyPayment), Math.E) / Math.Log((1 + rate), Math.E);
            return Math.Round(nper);
        }

        public double NperMonthly()
        {
            double rate = DailyInterest * CountDaysForMonthly() / (100 * TermMonthly);
            if (rate == 0)
            {
                rate = DailyInterest * TermMonthly * 30 / (100 * TermMonthly);
            }
            double nper = -Math.Log((1 - rate * LoanAmount / MonthlyPayment), Math.E) / Math.Log((1 + rate), Math.E);
            return Math.Round(nper);
        }

        public double NperMonthlyFlat()
        {
            double rate = DailyInterest * CountDaysForFlat() / 100;
            if (rate == 0)
            {
                rate = DailyInterest * TermFlat * 30 / 100;
            }
            double nper = LoanAmount * (rate + 1) / MonthlyPaymentFlat;
            return Math.Round(nper);
        }
        
        public double NperDailyFlat()
        {
            double rate = DailyInterest * CountDaysForFlatDaily() / 100;
            double nper = LoanAmount * (rate + 1) / DailyPaymentFlat;
            return Math.Round(nper);
        }

        public void GraphDaily()
        {
            Items.Clear();
            double amount = LoanAmount;
            double balance = LoanAmount;
            double dailyInterest = DailyInterest / 100;

            Items.Add(new GridItem() { Date = "თარიღი", EndingBalance = "საბოლოო ბალანსი", Interest = "პროცენტი", Payment = "გადასახადი", PaymentNumber = "#", Principal = "ძირი", StartingBalance = "საწყისი ბალანსი" });

            for (int i = 1; i <= TermDaily; i++)
            {
                DateTime dateTime = StartDateDaily.AddDays(i);
                double interest = Math.Round(amount * dailyInterest,2, MidpointRounding.AwayFromZero);
                double principal = Math.Round(PMTDaily() - interest, 2, MidpointRounding.AwayFromZero);
                //double interest = 
                balance -= principal;
                Items.Add(new GridItem() { PaymentNumber = i.ToString(), Date = dateTime.Date.ToString("dd/MM/yyyy"), Payment = DailyPayment.ToString(), EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(), Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(), Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(), StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString() });
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("Items"));
            }
        }

        public void GraphMonthly()
        {
            ItemsMonthly.Clear();
            double amount = LoanAmount;
            double balance = LoanAmount;
            double monthlyRate = Math.Round(DailyInterest * CountDaysForMonthly() / (100 * TermMonthly), 2, MidpointRounding.AwayFromZero);
            if (monthlyRate == 0)
            {
                monthlyRate = DailyInterest * TermFlat * 30 / (100 * TermMonthly);
            }
            ItemsMonthly.Add(new GridItem() { Date = "თარიღი", EndingBalance = "საბოლოო ბალანსი", Interest = "პროცენტი", Payment = "გადასახადი", PaymentNumber = "#", Principal = "ძირი", StartingBalance = "საწყისი ბალანსი" });

            for (int i = 1; i <= TermMonthly; i++)
            {
                DateTime dateTime = StartDateMonthly.AddMonths(i);
                double principal = Math.Round(PMTMonthly() - amount * monthlyRate,2,MidpointRounding.AwayFromZero);
                double interest = amount * monthlyRate;
                ItemsMonthly.Add(new GridItem() { PaymentNumber = i.ToString(), Date = dateTime.Date.ToString("dd/MM/yyyy"), Payment = MonthlyPayment.ToString(), Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(), Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(), StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString() });
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("ItemsMonthly"));
            }
        }

        public void GraphFlatPercentageMonthly()
        {
            FlatPercentageItems.Clear();
            double amount = LoanAmount;
            double rate = ((AnnualInterestForMonthly / 365) * (CountDaysForFlat()) / 100);
            if (rate == 0)
            {
                rate = DailyInterest * TermFlat * 30 / 100;
            }
            FlatPercentageItems.Add(new GridItem() { Date = "თარიღი", EndingBalance = "საბოლოო ბალანსი", Interest = "პროცენტი", Payment = "გადასახადი", PaymentNumber = "#", Principal = "ძირი", StartingBalance = "საწყისი ბალანსი" });

            for (int i = 1; i <= TermFlat; i++)
            {
                DateTime dateTime = StartDateFlat.AddMonths(i);
                double principal = Math.Round((LoanAmount / TermFlat),2,MidpointRounding.AwayFromZero);
                double interest = LoanAmount * rate / TermFlat;
                FlatPercentageItems.Add(new GridItem() { PaymentNumber = i.ToString(), Date = dateTime.Date.ToString("dd/MM/yyyy"), Payment = FlatMonthly().ToString(), Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(), Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(), StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString() });
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("FlatPercentageItems"));
            }

        }

        public void GraphFlatPercentageDaily()
        {
            FlatDailyItems.Clear();
            double amount = LoanAmount;
            double rate = DailyInterest * CountDays() / 100;
            FlatDailyItems.Add(new GridItem() { Date = "თარიღი", EndingBalance = "საბოლოო ბალანსი", Interest = "პროცენტი", Payment = "გადასახადი", PaymentNumber = "#", Principal = "ძირი", StartingBalance = "საწყისი ბალანსი" });

            for (int i = 1; i <= TermFlatDaily; i++)
            {
                DateTime dateTime = StartDateFlat.AddDays(i);
                double principal = LoanAmount / TermFlatDaily;
                double interest = LoanAmount * rate / TermFlatDaily;
                FlatDailyItems.Add(new GridItem() { PaymentNumber = i.ToString(), Date = dateTime.Date.ToString("dd/MM/yyyy"), Payment = FlatDaily().ToString(), Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(), Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(), StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString() });
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("FlatDailyItems"));
            }
        }

        public ObservableCollection<GridItem> FlatDailyItems { get; set; }

        public ObservableCollection<GridItem> FlatPercentageItems { get; set; }

        public ObservableCollection<GridItem> ItemsMonthly { get; set; }

        public ObservableCollection<GridItem> Items { get; set; }
    }
}
