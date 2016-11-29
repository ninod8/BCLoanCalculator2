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
            _annualInterestForMonthlyF = App.AnnualInterestFM;
            _monthlyInterestF = App.MonthlyInterestFM;
            _loanAmountFM = App.LoanAmountFM;
            _monthlyPaymentFlat = App.PeymentFM;
            _termFlat = App.TermFM;

            _startDateFlat = DateTime.Today.Date.AddMonths(1);
            if (App.StartDateFM != DateTime.Today.Date.AddMonths(1))
            {
                _startDateFlat = App.StartDateFM;
            }

            _endDateFlat = DateTime.Today.Date.AddMonths(1);
            if (App.EndDateFM != DateTime.Today.Date.AddMonths(1))
            {
                _endDateFlat = App.EndDateFM;
            }

            _releaseDateFlat = DateTime.Today.Date;
            if (App.ReleaseDateFM != DateTime.Today.Date)
            {
                _releaseDateFlat = App.ReleaseDateFM;
            }

            _annualInterestEL = App.AnnualInterestEL;
            _dailyInterestEL = App.DailyInterestEL;
            _loanAmountEL = App.LoanAmountEL;
            _dailyPayment = App.PeymentEL;
            _interestOnlyEL = App.InterestOnlyEL;
            _termDaily = App.TermEL;

            _startDateDaily = DateTime.Today.Date;
            if (App.StartDateEL != DateTime.Today.Date)
            {
                _startDateDaily = App.StartDateEL;
            }
            _endDateDaily = DateTime.Today.Date;

            if (App.EndDateEL != DateTime.Today.Date)
            {
                _endDateDaily = App.EndDateEL;
            }

            _loanAmountELM = App.LoanAmountELM;
            _termMonthly = App.TermELM;
            _monthlyPayment = App.PeymentELM;
            _interestOnlyELM = App.InterestOnlyELM;
            _monthlyInterestELM = App.MonthlyInterestELM;
            _annualInterestForMonthlyELM = App.AnnualInterestELM;
            _monthlyInterestELM = App.MonthlyInterestELM;
            _endDateMonthly = DateTime.Today.Date.AddMonths(1);

            if (App.EndDateELM != DateTime.Today.Date.AddMonths(1))
            {
                _endDateMonthly = App.EndDateELM;
            }
            _startDateMonthly = DateTime.Today.Date.AddMonths(1);

            if (App.StartDateELM != DateTime.Today.Date.AddMonths(1))
            {
                _startDateMonthly = App.StartDateELM;
            }

            _releaseDate = DateTime.Today.Date;
            if (App.ReleaseDateELM != DateTime.Today.Date)
            {
                _releaseDate = App.ReleaseDateELM;
            }

            _loanAmountF = App.LoanAmountF;
            _termFlatDaily = App.TermF;
            _dailyPaymentFlat = App.PeymentF;
            _annualInterestF = App.AnnualInterestF;
            _dailyInterestF = App.DailyInterestF;
            _startDateFlatDaily = DateTime.Today.Date;
            if (App.StartDateF != DateTime.Today.Date)
            {
                _startDateFlatDaily = App.StartDateF;
            }
            _endDateFlatDaily = DateTime.Today.Date;
            if (App.EndDateF != DateTime.Today.Date)
            {
                _endDateFlatDaily = App.EndDateF;
            }

            Items = new ObservableCollection<GridItem>();
            ItemsSum = new ObservableCollection<GridItem>();
            ItemsMonthly = new ObservableCollection<GridItem>();
            ItemsMonthlySum = new ObservableCollection<GridItem>();
            FlatPercentageItems = new ObservableCollection<GridItem>();
            FlatPercentageItemsSum = new ObservableCollection<GridItem>();
            FlatDailyItems = new ObservableCollection<GridItem>();
            FlatDailyItemsSum = new ObservableCollection<GridItem>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);

        }

        #region Private Variables
        private string _interestOnlyEL;
        private string _interestOnlyELM;

        private string _annualInterestForMonthlyF;
        private string _annualInterestForMonthlyELM;

        private string _monthlyInterestELM;
        private string _monthlyInterestF;

        private string _dailyInterestEL;
        private string _dailyInterestF;
        private string _dailyInterestFM;
        private string _dailyInterestELM;


        private string _annualInterestEL;
        private string _annualInterestELM;
        private string _annualInterestFM;
        private string _annualInterestF;

        private DateTime _startDateDaily;
        private DateTime _startDateMonthly;
        private DateTime _startDateFlat;
        private DateTime _startDateFlatDaily;

        private DateTime _endDateDaily;
        private DateTime _endDateMonthly;
        private DateTime _endDateFlat;
        private DateTime _endDateFlatDaily;

        private DateTime _releaseDate;
        private DateTime _releaseDateFlat;

        private string _termDaily;
        private string _termMonthly;
        private string _termFlat;
        private string _termFlatDaily;

        private string _dailyPayment;
        private string _monthlyPayment;
        private string _monthlyPaymentFlat;
        private string _dailyPaymentFlat;

        private string _loanAmountEL;
        private string _loanAmountELM;
        private string _loanAmountFM;
        private string _loanAmountF;

        #endregion
        private string _ex;

        public string Ex
        {
            get { return _ex; }
            set { _ex = value; }
        }

        public string MonthlyInterestELM
        {
            get { return _monthlyInterestELM; }
            set
            {
                try
                {
                    _monthlyInterestELM = value;
                    _annualInterestForMonthlyELM = Math.Round(Convert.ToDouble(value) * 12, 3, MidpointRounding.AwayFromZero).ToString();
                    _dailyInterestELM = (Convert.ToDouble(_annualInterestForMonthlyELM) / 365).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
            }
        }

        public string MonthlyInterestF
        {
            get { return _monthlyInterestF; }
            set
            {
                try
                {
                    _monthlyInterestF = value;
                    _annualInterestForMonthlyF = Math.Round(Convert.ToDouble(value) * 12, 3, MidpointRounding.AwayFromZero).ToString();
                    _dailyInterestF = (Convert.ToDouble(_annualInterestForMonthlyF) / 365).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
            }
        }

        public string AnnualInterestForMonthlyF
        {
            get { return _annualInterestForMonthlyF; }
            set
            {
                try
                {
                    _annualInterestForMonthlyF = value;
                    _monthlyInterestF = Math.Round(Convert.ToDouble(value) / 12, 3, MidpointRounding.AwayFromZero).ToString();
                    _dailyInterestF = (Convert.ToDouble(_annualInterestForMonthlyF) / 365).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
            }
        }
        public string AnnualInterestForMonthlyELM
        {
            get { return _annualInterestForMonthlyELM; }
            set
            {
                try
                {
                    _annualInterestForMonthlyELM = value;
                    _monthlyInterestELM = Math.Round(Convert.ToDouble(value) / 12, 3, MidpointRounding.AwayFromZero).ToString();
                    _dailyInterestELM = (Convert.ToDouble(_annualInterestForMonthlyELM) / 365).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
            }
        }

        public string DailyInterestEL
        {
            get { return _dailyInterestEL; }
            set
            {
                try
                {
                    _dailyInterestEL = value;
                    _annualInterestEL = Math.Round(Convert.ToDouble(value) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
            }
        }

        public string DailyInterestELM
        {
            get { return _dailyInterestELM; }
            set
            {
                try
                {
                    _dailyInterestELM = value;
                    _annualInterestELM = Math.Round(Convert.ToDouble(value) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestELM"));
            }
        }

        public string DailyInterestFM
        {
            get { return _dailyInterestFM; }
            set
            {
                try
                {
                    _dailyInterestFM = value;
                    _annualInterestFM = Math.Round(Convert.ToDouble(value) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestFM"));
            }
        }

        public string DailyInterestF
        {
            get { return _dailyInterestF; }
            set
            {
                try
                {
                    _dailyInterestF = value;
                    _annualInterestF = Math.Round(Convert.ToDouble(value) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
            }
        }
        public string AnnualInterestEL
        {
            get { return _annualInterestEL; }
            set
            {
                try
                {
                    _annualInterestEL = value;
                    _dailyInterestEL = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
            }
        }
        public string AnnualInterestELM
        {
            get { return _annualInterestELM; }
            set
            {
                try
                {
                    _annualInterestELM = value;
                    _dailyInterestELM = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestELM"));
            }
        }
        public string AnnualInterestFM
        {
            get { return _annualInterestFM; }
            set
            {
                try
                {
                    _annualInterestFM = value;
                    _dailyInterestFM = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestFM"));
            }
        }
        public string AnnualInterestF
        {
            get { return _annualInterestF; }
            set
            {
                try
                {
                    _annualInterestF = value;
                    _dailyInterestF = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));
            }
        }

        public string LoanAmountEL
        {
            get { return _loanAmountEL; }
            set
            {
                try
                {
                    _loanAmountEL = Convert.ToDouble(value).ToString();                   
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
            }
        }
        public string LoanAmountELM
        {
            get { return _loanAmountELM; }
            set
            {
                try
                {
                    _loanAmountELM = Convert.ToDouble(value).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
            }
        }
        public string LoanAmountFM
        {
            get { return _loanAmountFM; }
            set
            {
                try
                {
                    _loanAmountFM = Convert.ToDouble(value).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
            }
        }
        public string LoanAmountF
        {
            get { return _loanAmountF; }
            set
            {
                try
                {
                    _loanAmountF = Convert.ToDouble(value).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
            }
        }

        public DateTime StartDateDaily
        {
            get { return _startDateDaily; }
            set
            {
                try
                {
                    _startDateDaily = value;
                    TermDaily = CountDays().ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
            }
        }

        public DateTime EndDateDaily
        {
            get { return _endDateDaily; }
            set
            {
                try
                {
                    _endDateDaily = value;
                    TermDaily = CountDays().ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
            }
        }

        public DateTime ReleaseDate //add a method
        {
            get { return _releaseDate; }
            set
            {
                _releaseDate = value;
            }
        }

        public DateTime StartDateMonthly
        {
            get { return _startDateMonthly; }
            set
            {
                try
                {
                    _startDateMonthly = value;
                    TermMonthly = CountMonths().ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
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
                TermMonthly = CountMonths().ToString();
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
            }
        }

        public DateTime ReleaseDateFlat
        {
            get { return _releaseDateFlat; }
            set
            {
                _releaseDateFlat = value;
            }
        }

        public DateTime StartDateFlat
        {
            get { return _startDateFlat; }
            set
            {
                _startDateFlat = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
            }
        }

        public DateTime EndDateFlat
        {
            get { return _endDateFlat; }
            set
            {
                _endDateFlat = value;
                TermFlat = CountMonthsForFlat().ToString();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
            }
        }

        public DateTime StartdateFlatDaily
        {
            get { return _startDateFlatDaily; }
            set
            {
                _startDateFlatDaily = value;
                TermFlatDaily = CountDaysForFlatDaily().ToString();
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
                TermFlatDaily = CountDaysForFlatDaily().ToString();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
            }
        }

        public string TermDaily
        {
            get { return _termDaily; }
            set
            {
                _termDaily = value;
                _dailyPayment = PMTDaily();
                GraphDaily();
                SumDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
            }
        }

        public string TermMonthly
        {
            get { return _termMonthly; }
            set
            {
                _termMonthly = value;
                _monthlyPayment = PMTMonthly();
                GraphMonthly();
                SumMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
            }
        }

        public string TermFlat
        {
            get { return _termFlat; }
            set
            {
                try
                {
                    _termFlat = value;
                    _endDateFlat = StartDateFlat.AddMonths(Convert.ToInt32(TermFlat) - 1);
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5.)";
                }

                _monthlyPaymentFlat = FlatMonthly();
                GraphFlatPercentageMonthly();
                FlatMonthlySum();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
            }
        }

        public string TermFlatDaily
        {
            get { return _termFlatDaily; }
            set
            {
                try
                {
                    _termFlatDaily = value;
                    _dailyPaymentFlat = FlatDaily();
                    _endDateFlatDaily = _startDateFlatDaily.AddDays(Convert.ToInt32(TermFlatDaily));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }

                GraphFlatPercentageDaily();
                FlatSum();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
            }
        }

        public string DailyPayment
        {
            get { return _dailyPayment; }
            set
            {
                _dailyPayment = value;
                //_termDaily = NperDaily();
                //GraphDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
            }
        }

        public string MonthlyPayment
        {
            get { return _monthlyPayment; }
            set
            {
                _monthlyPayment = value;
                //_termMonthly = NperMonthly();
                GraphMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
            }
        }

        public string MonthlyPaymentFlat
        {
            get { return _monthlyPaymentFlat; }
            set
            {
                _monthlyPaymentFlat = value;
                // _termFlat = NperMonthlyFlat();
                // GraphFlatPercentageMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
            }
        }

        public string DailyPaymentFlat
        {
            get { return _dailyPaymentFlat; }
            set
            {
                _dailyPaymentFlat = value;
                // _termFlatDaily = NperDailyFlat();
                GraphFlatPercentageDaily();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
            }
        }

        public int CounterForFlat()
        {
            return (StartDateFlat - ReleaseDateFlat).Days;
        }

        public int CountDays()
        {
            return (EndDateDaily - StartDateDaily).Days;
        }

        public int CountDaysForMonthly()
        {
            return (EndDateMonthly - StartDateMonthly).Days;
        }
        public int CounterForMonthly()
        {
            return (StartDateMonthly - ReleaseDate).Days;
        }

        public int CountDaysForFlat()
        {
            return (EndDateFlat - StartDateFlat).Days;
        }

        public int CountMonths()
        {
            return (EndDateMonthly.Month - StartDateMonthly.Month) + 12 * (EndDateMonthly.Year - StartDateMonthly.Year);
        }

        public int CountMonthsForFlat()
        {
            return (EndDateFlat.Month - StartDateFlat.Month) + 12 * (EndDateFlat.Year - StartDateFlat.Year);
        }

        public int CountDaysForFlatDaily()
        {
            return (EndDateFlatDaily - StartdateFlatDaily).Days;
        }

        public string PMTDaily()
        {
            try
            {
                double rate = Convert.ToDouble(DailyInterestEL) / 100;
                double pmt = Convert.ToDouble(LoanAmountEL) * Convert.ToDouble(rate) / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermDaily) - Convert.ToDouble(InterestOnlyEL)))));
                return Math.Round(pmt, 2, MidpointRounding.AwayFromZero).ToString();
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            return "";
        }

        public string PMTMonthly()
        {
            try
            {
                double rate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
                if (rate == 0)
                {
                    rate = Convert.ToDouble(DailyInterestELM) * Convert.ToDouble(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
                }
                double pmt = Convert.ToDouble(LoanAmountELM) * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermMonthly) - Convert.ToDouble(InterestOnlyELM)))));
                return pmt.ToString();
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            return "";
        }

        public string FlatMonthly()
        {
            try
            {
                double flatPayment;
                double rate = ((Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * (CountDaysForFlat()) / 100);
                if (rate == 0)
                {
                    rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * Convert.ToDouble(TermFlat) * 30 / 100;
                }
                if (CounterForFlat() > 31)
                {
                    flatPayment = (Convert.ToDouble(LoanAmountFM) + (rate * Convert.ToDouble(LoanAmountFM))) / (Convert.ToDouble(TermFlat) + 1);
                }
                flatPayment = (Convert.ToDouble(LoanAmountFM) + (rate * Convert.ToDouble(LoanAmountFM))) / Convert.ToDouble(TermFlat);
                return Math.Round(flatPayment, 2, MidpointRounding.AwayFromZero).ToString();
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            return "";
        }

        public string FlatDaily()
        {
            try
            {
                double rate = Convert.ToDouble(DailyInterestF) * CountDaysForFlatDaily() / 100;
                double flatPayment = (Convert.ToDouble(LoanAmountF) + (rate * Convert.ToDouble(LoanAmountF))) / Convert.ToDouble(TermFlatDaily);
                return flatPayment.ToString();
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            return "";
        }

        //public string NperDaily()
        //{
        //    try
        //    {
        //        double rate = Convert.ToDouble(DailyInterestEL) / 100;
        //        double nper = -Math.Log((1 - rate * Convert.ToDouble(LoanAmountEL) / Convert.ToDouble(DailyPayment)), Math.E) / Math.Log((1 + rate), Math.E);
        //        return nper.ToString();
        //    }
        //    catch (Exception)
        //    {
        //        _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
        //    }
        //    return "";
        //}

        //public string NperMonthly()
        //{
        //    try
        //    {
        //        double rate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
        //        if (rate == 0)
        //        {
        //            rate = Convert.ToDouble(DailyInterestELM) * Convert.ToDouble(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
        //        }
        //        double nper = -Math.Log((1 - rate * Convert.ToDouble(LoanAmountELM) / Convert.ToDouble(MonthlyPayment)), Math.E) / Math.Log((1 + rate), Math.E);
        //        return nper.ToString();
        //    }
        //    catch (Exception)
        //    {
        //        _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
        //    }
        //    return "";
        //}

        //public string NperMonthlyFlat()
        //{
        //    try
        //    {
        //        double rate = Convert.ToDouble(DailyInterestFM) * CountDaysForFlat() / 100;
        //        if (rate == 0)
        //        {
        //            rate = Convert.ToDouble(DailyInterestFM) * Convert.ToDouble(TermFlat) * 30 / 100;
        //        }
        //        double nper = Convert.ToDouble(LoanAmountFM) * (rate + 1) / Convert.ToDouble(MonthlyPaymentFlat);
        //        return nper.ToString();
        //    }
        //    catch (Exception)
        //    {
        //        _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
        //    }
        //    return "";
        //}

        //public string NperDailyFlat()
        //{
        //    try
        //    {
        //        double rate = Convert.ToDouble(DailyInterestF) * CountDaysForFlatDaily() / 100;
        //        double nper = Convert.ToDouble(LoanAmountF) * (rate + 1) / Convert.ToDouble(DailyPaymentFlat);
        //        return nper.ToString();
        //    }
        //    catch (Exception)
        //    {
        //        _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
        //    }
        //    return "";
        //}

        public string InterestOnlyEL
        {
            get { return _interestOnlyEL; }
            set
            {
                _interestOnlyEL = value;
            }
        }

        public string InterestOnlyELM
        {
            get { return _interestOnlyELM; }
            set
            {
                _interestOnlyELM = value;
            }
        }

        public void SumDaily()
        {
            try
            {
                ItemsSum.Clear();
                double amount = Convert.ToDouble(LoanAmountEL);
                double balance = Convert.ToDouble(LoanAmountEL);
                double dailyInterest = Convert.ToDouble(DailyInterestEL) / 100;
                double sumP = 0;
                double sumI = 0;
                double interest = 0;
                for (int i = 1; i <= Convert.ToDouble(TermDaily); i++)
                {
                    if (Convert.ToDouble(InterestOnlyEL) > 0)
                    {
                        while (i <= Convert.ToDouble(InterestOnlyEL))
                        {
                            i++;
                            double interest1 = amount * dailyInterest;
                            sumI += interest1;
                            amount = Convert.ToDouble(LoanAmountEL);
                        }
                    }

                    interest = amount * dailyInterest;
                    double principal = Convert.ToDouble(PMTDaily()) - interest;
                    balance -= principal;

                    amount -= principal;
                    sumI += interest;
                    sumP = sumI + Convert.ToDouble(LoanAmountEL);
                    OnPropertyChanged(new PropertyChangedEventArgs("ItemsSum"));
                }
                ItemsSum.Add(new GridItem()
                {
                    InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(),
                    PeymentSum = Math.Round(sumP, 2, MidpointRounding.AwayFromZero).ToString()
                });

            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
        }

        public void GraphDaily()
        {
            try
            {
                Items.Clear();
                double amount = Convert.ToDouble(LoanAmountEL);
                double balance = Convert.ToDouble(LoanAmountEL);
                double dailyInterest = Convert.ToDouble(DailyInterestEL) / 100;
                Items.Add(new GridItem()
                {
                    Date = "თარიღი",
                    EndingBalance = "საბოლოო ბალანსი",
                    Interest = "პროცენტი",
                    Payment = "გადასახადი",
                    PaymentNumber = "#",
                    Principal = "ძირი",
                    StartingBalance = "საწყისი ბალანსი"
                });

                for (int i = 0; i < Convert.ToDouble(TermDaily); i++)
                {
                    if (Convert.ToDouble(InterestOnlyEL) > 0)
                    {
                        while (i < Convert.ToDouble(InterestOnlyEL))
                        {
                            i++;
                            DateTime dateTime1 = StartDateDaily.AddDays(i);
                            double interest1 = amount * dailyInterest;
                            double principal1 = 0.00;
                            balance = Convert.ToDouble(LoanAmountEL);
                            Items.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount = Convert.ToDouble(LoanAmountEL);
                        }
                    }

                    DateTime dateTime = StartDateDaily.AddDays(i + 1);
                    double interest = amount * dailyInterest;
                    double principal = Convert.ToDouble(PMTDaily()) - interest;
                    balance -= principal;
                    Items.Add(new GridItem()
                    {
                        PaymentNumber = (i + 1).ToString(),
                        Date = dateTime.Date.ToString("dd/MM/yyyy"),
                        Payment = Math.Round(Convert.ToDouble(DailyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                        EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                        Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                        Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                    });
                    amount -= principal;
                    OnPropertyChanged(new PropertyChangedEventArgs("Items"));
                }
            }
            catch (Exception)
            {

                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }

        }

        public void SumMonthly()
        {
            try
            {
                ItemsMonthlySum.Clear();
                double amount = Convert.ToDouble(LoanAmountELM);
                double balance = Convert.ToDouble(LoanAmountELM);
                double sumP = 0;
                double sumI = 0;
                double monthlyRate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
                if (monthlyRate == 0)
                {
                    monthlyRate = Convert.ToDouble(DailyInterestELM) * Convert.ToInt32(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
                }
                for (int i = 1; i <= Convert.ToDouble(TermMonthly); i++)
                {
                    if (Convert.ToDouble(InterestOnlyELM) > 0)
                    {
                        while (i <= Convert.ToDouble(InterestOnlyELM))
                        {
                            i++;
                            double interest1 = amount * monthlyRate;
                            sumI += interest1;
                        }
                        sumP = sumI;
                    }
                    double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                    double interest = amount * monthlyRate;
                    sumI += interest;

                    amount -= principal;
                    OnPropertyChanged(new PropertyChangedEventArgs("ItemsMonthly"));
                }
                sumP = sumI + Convert.ToDouble(LoanAmountELM);
                ItemsMonthlySum.Add(new GridItem()
                {
                    InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(),
                    PeymentSum = Math.Round(sumP, 2, MidpointRounding.AwayFromZero).ToString()
                });
            }
            catch (Exception)
            {

                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }

        }

        public void GraphMonthly()
        {
            try
            {
                ItemsMonthly.Clear();
                double amount = Convert.ToDouble(LoanAmountELM);
                double balance = Convert.ToDouble(LoanAmountELM);
                double monthlyRate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
                if (monthlyRate == 0)
                {
                    monthlyRate = Convert.ToDouble(DailyInterestELM) * Convert.ToInt32(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
                }
                ItemsMonthly.Add(new GridItem()
                {
                    Date = "თარიღი",
                    EndingBalance = "საბოლოო ბალანსი",
                    Interest = "პროცენტი",
                    Payment = "გადასახადი",
                    PaymentNumber = "#",
                    Principal = "ძირი",
                    StartingBalance = "საწყისი ბალანსი"
                });

                for (int i = 1; i <= Convert.ToDouble(TermMonthly); i++)
                {
                    if (CounterForMonthly() > 31)
                    {
                        //while (i<2)                               
                        //{
                        //    double rate = Convert.ToDouble(DailyInterestELM) * CounterForMonthly() / 100;
                        //    double payment = Convert.ToDouble(LoanAmountELM) * rate;
                        //    ItemsMonthly.Add(new GridItem()
                        //    {
                        //        PaymentNumber = (i).ToString(),
                        //        Date = StartDateMonthly.Date.ToString("dd/MM/yyyy"),
                        //        Payment = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),                     yoveldgiuri pmt unda
                        //        EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                        //        Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                        //        Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                        //        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                        //    });
                        //    i++;
                        //}
                    }
                    if (Convert.ToDouble(InterestOnlyELM) > 0)
                    {
                        while (i <= Convert.ToDouble(InterestOnlyELM))
                        {

                            DateTime dateTime1 = StartDateDaily.AddMonths(i - 1);
                            double interest1 = amount * monthlyRate;
                            double principal1 = 0.00;
                            balance = Convert.ToDouble(LoanAmountELM);
                            ItemsMonthly.Add(new GridItem()
                            {
                                PaymentNumber = (i).ToString(),
                                Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount = Convert.ToDouble(LoanAmountELM);
                            i++;
                        }
                        DateTime dateTime = StartDateMonthly.AddMonths(i - 2);
                        double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                        double interest = amount * monthlyRate;
                        balance -= principal;
                        ItemsMonthly.Add(new GridItem()
                        {
                            PaymentNumber = (i).ToString(),
                            Date = dateTime.Date.ToString("dd/MM/yyyy"),
                            Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                            Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                            Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                        });
                        amount -= principal;
                    }

                    else
                    {
                        DateTime dateTime = StartDateMonthly.AddMonths(i - 1);
                        double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                        double interest = amount * monthlyRate;
                        balance -= principal;
                        ItemsMonthly.Add(new GridItem()
                        {
                            PaymentNumber = (i).ToString(),
                            Date = dateTime.Date.ToString("dd/MM/yyyy"),
                            Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                            Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                            Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                        });
                        amount -= principal;
                    }
                    OnPropertyChanged(new PropertyChangedEventArgs("ItemsMonthly"));
                }
            }
            catch (Exception)
            {

                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }

        }

        public void FlatMonthlySum()
        {
            try
            {
                FlatPercentageItemsSum.Clear();
                double h = CountDaysForFlat();
                double rate;
                double principal;
                double SumI = 0;
                double SumP = 0;
                for (int i = 1; i <= Convert.ToDouble(TermFlat) + 1; i++)
                {
                    if (CounterForFlat() > 31)
                    {
                        while (i < 2)
                        {
                            rate = ((Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * CounterForFlat() / 100);
                            double principal1 = Convert.ToDouble(LoanAmountFM) / (Convert.ToDouble(TermFlat) + 1);
                            double interest1 = principal1 * rate;
                            double peyment = interest1 + principal1;
                            i++;
                            SumI = peyment;
                            SumP = interest1;
                        }
                    }
                    rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * CountDaysForFlat() / 100;
                    if (rate == 0)
                    {
                        rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * Convert.ToDouble(TermFlat) * 30 / 100;
                    }
                    if (CounterForFlat() > 31)
                    {
                        principal = Convert.ToDouble(LoanAmountFM) / (Convert.ToDouble(TermFlat) + 1);
                    }
                    else principal = Convert.ToDouble(LoanAmountFM) / Convert.ToDouble(TermFlat);
                    double interest = principal * rate;
                    SumI += Convert.ToDouble(FlatMonthly());
                    SumP += interest;

                }
                FlatPercentageItemsSum.Add(new GridItem()
                {
                    InterestSum = Math.Round(SumI, 2, MidpointRounding.AwayFromZero).ToString(),
                    PeymentSum = Math.Round(SumP, 2, MidpointRounding.AwayFromZero).ToString().ToString()
                });
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }

        }//needs corrections

        public void GraphFlatPercentageMonthly()
        {
            try
            {
                FlatPercentageItems.Clear();
                double amount = Convert.ToDouble(LoanAmountFM);
                double balance = Convert.ToDouble(LoanAmountFM);
                double rate;
                double principal;
                FlatPercentageItems.Add(new GridItem()
                {
                    Date = "თარიღი",
                    EndingBalance = "საბოლოო ბალანსი",
                    Interest = "პროცენტი",
                    Payment = "გადასახადი",
                    PaymentNumber = "#",
                    Principal = "ძირი",
                    StartingBalance = "საწყისი ბალანსი"
                });

                for (int i = 1; i <= Convert.ToDouble(TermFlat) + 1; i++)
                {
                    if (CounterForFlat() > 31)
                    {
                        while (i < 2)
                        {
                            rate = ((Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * CounterForFlat() / 100);
                            DateTime dateTime1 = StartDateFlat.AddMonths(i - 1);
                            double principal1 = Convert.ToDouble(LoanAmountFM) / (Convert.ToDouble(TermFlat) + 1);
                            double interest1 = principal1 * rate;
                            balance -= principal1;
                            double peyment = interest1 + principal1;
                            FlatPercentageItems.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(peyment, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal1;
                            i++;
                        }
                    }
                    rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * CountDaysForFlat() / 100;
                    if (rate == 0)
                    {
                        rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * Convert.ToDouble(TermFlat) * 30 / 100;
                    }
                    DateTime dateTime = StartDateFlat.AddMonths(i - 1);
                    if (CounterForFlat() > 31)
                    {
                        principal = Convert.ToDouble(LoanAmountFM) / (Convert.ToDouble(TermFlat) + 1);

                    }
                    else principal = Convert.ToDouble(LoanAmountFM) / Convert.ToDouble(TermFlat);
                    double interest = principal * rate;
                    balance -= principal;
                    FlatPercentageItems.Add(new GridItem()
                    {
                        PaymentNumber = i.ToString(),
                        Date = dateTime.Date.ToString("dd/MM/yyyy"),
                        Payment = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString(),
                        Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                        Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                        EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                    });
                    amount -= principal;
                    OnPropertyChanged(new PropertyChangedEventArgs("FlatPercentageItems"));
                }
            }
            catch (Exception)
            {

                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";

            }

        }

        public void FlatSum()
        {
            try
            {
                FlatDailyItemsSum.Clear();
                string sumP = Math.Round((Convert.ToDouble(FlatDaily()) * Convert.ToDouble(TermFlatDaily)), 2, MidpointRounding.AwayFromZero).ToString();
                double rate = Convert.ToDouble(DailyInterestF) * CountDaysForFlatDaily() / 100;
                string sumI = Math.Round((Convert.ToDouble(LoanAmountF) * rate), 2, MidpointRounding.AwayFromZero).ToString();
                FlatDailyItemsSum.Add(new GridItem()
                {
                    InterestSum = sumI,
                    PeymentSum = sumP
                });
            }
            catch (Exception)
            {

                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }

        }

        public void GraphFlatPercentageDaily()
        {
            try
            {
                FlatDailyItems.Clear();
                double amount = Convert.ToDouble(LoanAmountF);
                double sj = CountDaysForFlatDaily();
                double rate = Convert.ToDouble(DailyInterestF) * CountDaysForFlatDaily() / 100;
                double balance = Convert.ToDouble(LoanAmountF);
                FlatDailyItems.Add(new GridItem()
                {
                    Date = "თარიღი",
                    EndingBalance = "საბოლოო ბალანსი",
                    Interest = "პროცენტი",
                    Payment = "გადასახადი",
                    PaymentNumber = "#",
                    Principal = "ძირი",
                    StartingBalance = "საწყისი ბალანსი"
                });
                for (int i = 1; i <= Convert.ToDouble(TermFlatDaily); i++)
                {
                    DateTime dateTime = StartDateFlat.AddDays(i);
                    double principal = Convert.ToDouble(LoanAmountF) / Convert.ToDouble(TermFlatDaily);
                    double interest = Convert.ToDouble(DailyPaymentFlat) - principal;
                    balance -= principal;
                    FlatDailyItems.Add(new GridItem()
                    {
                        PaymentNumber = i.ToString(),
                        Date = dateTime.Date.ToString("dd/MM/yyyy"),
                        Payment = FlatDaily(),
                        Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                        Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                        EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                    });
                    amount -= principal;
                    OnPropertyChanged(new PropertyChangedEventArgs("FlatDailyItems"));
                }
            }
            catch (Exception)
            {

                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }

        }

        public ObservableCollection<GridItem> FlatDailyItems { get; set; }

        public ObservableCollection<GridItem> FlatDailyItemsSum { get; set; }

        public ObservableCollection<GridItem> FlatPercentageItems { get; set; }

        public ObservableCollection<GridItem> FlatPercentageItemsSum { get; set; }

        public ObservableCollection<GridItem> ItemsMonthly { get; set; }

        public ObservableCollection<GridItem> ItemsMonthlySum { get; set; }

        public ObservableCollection<GridItem> Items { get; set; }

        public ObservableCollection<GridItem> ItemsSum { get; set; }


    }
}
