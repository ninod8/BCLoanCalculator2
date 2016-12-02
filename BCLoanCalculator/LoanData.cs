﻿using System;
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
            if (App.StartDateFM != DateTime.Today.Date.AddMonths(1) || App.StartDateFM != DateTime.MinValue)
            {
                _startDateFlat = App.StartDateFM;
            }

            _endDateFlat = DateTime.Today.Date.AddMonths(1);
            if (App.EndDateFM != DateTime.Today.Date.AddMonths(1) || App.EndDateFM != DateTime.MinValue)
            {
                _endDateFlat = App.EndDateFM;
            }
            _releaseDateFlat = DateTime.Today.Date;
            if (App.ReleaseDateFM != DateTime.Today.Date || App.ReleaseDateFM != DateTime.MinValue)
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
            if (App.StartDateEL != DateTime.Today.Date || App.StartDateEL != DateTime.MinValue)
            {
                _startDateDaily = App.StartDateEL;
            }
            _endDateDaily = DateTime.Today.Date;

            if (App.EndDateEL != DateTime.Today.Date || App.EndDateEL != DateTime.MinValue)
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

            if (App.EndDateELM != DateTime.Today.Date.AddMonths(1) || App.EndDateELM != DateTime.MinValue)
            {
                _endDateMonthly = App.EndDateELM;
            }
            _startDateMonthly = DateTime.Today.Date.AddMonths(1);

            if (App.StartDateELM != DateTime.Today.Date.AddMonths(1) || App.StartDateELM != DateTime.MinValue)
            {
                _startDateMonthly = App.StartDateELM;
            }

            _releaseDate = DateTime.Today.Date;
            if (App.ReleaseDateELM != DateTime.Today.Date || App.ReleaseDateELM != DateTime.MinValue)
            {
                _releaseDate = App.ReleaseDateELM;
            }

            _loanAmountF = App.LoanAmountF;
            _termFlatDaily = App.TermF;
            _dailyPaymentFlat = App.PeymentF;
            _annualInterestF = App.AnnualInterestF;
            _dailyInterestF = App.DailyInterestF;
            _startDateFlatDaily = DateTime.Today.Date;
            if (App.StartDateF != DateTime.Today.Date || App.StartDateF != DateTime.MinValue)
            {
                _startDateFlatDaily = App.StartDateF;
            }
            _endDateFlatDaily = DateTime.Today.Date;
            if (App.EndDateF != DateTime.Today.Date || App.EndDateF != DateTime.MinValue)
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
        private string _ex;
        #endregion


        public string Ex
        {
            get { return _ex; }
            set
            {
                _ex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
            }
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
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
            }
        }

        public string MonthlyInterestF
        {
            get { return _monthlyInterestF; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));


            }
        }

        public string AnnualInterestForMonthlyF
        {
            get { return _annualInterestForMonthlyF; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));


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
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();

                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
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
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }

                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
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
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();

                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
            }
        }

        public string DailyInterestFM
        {
            get { return _dailyInterestFM; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();

                    _dailyInterestFM = value;
                    _annualInterestFM = Math.Round(Convert.ToDouble(value) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));


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
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));
            }
        }
        public string AnnualInterestEL
        {
            get { return _annualInterestEL; }
            set
            {
                try
                {
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    _annualInterestEL = value;
                    _dailyInterestEL = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }

                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));


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
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();


                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
            }
        }
        public string AnnualInterestFM
        {
            get { return _annualInterestFM; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();

                    _annualInterestFM = value;
                    _dailyInterestFM = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));


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
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
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
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    _loanAmountEL = Convert.ToDouble(value).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));


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
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
            }
        }
        public string LoanAmountFM
        {
            get { return _loanAmountFM; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();


                    _loanAmountFM = Convert.ToDouble(value).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));

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
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));
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
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    TermDaily = CountDays().ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }

                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));


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
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    TermDaily = CountDays().ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
            }
        }

        public DateTime ReleaseDate //add a method
        {
            get { return _releaseDate; }
            set
            {
                try
                {
                    _releaseDate = value;
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
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
                _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
            }
        }

        public DateTime EndDateMonthly
        {
            get { return _endDateMonthly; }
            set
            {
                try
                {

                    _endDateMonthly = value;
                    TermMonthly = CountMonths().ToString();
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public DateTime ReleaseDateFlat
        {
            get { return _releaseDateFlat; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();

                    _releaseDateFlat = value;
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public DateTime StartDateFlat
        {
            get { return _startDateFlat; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();

                    _startDateFlat = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public DateTime EndDateFlat
        {
            get { return _endDateFlat; }
            set
            {
                try
                {
                    _endDateFlat = value;
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();

                    TermFlat = CountMonthsForFlat().ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public DateTime StartdateFlatDaily
        {
            get { return _startDateFlatDaily; }
            set
            {
                try
                {
                    _startDateFlatDaily = value;
                    TermFlatDaily = CountDaysForFlatDaily().ToString();
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public DateTime EndDateFlatDaily
        {
            get { return _endDateFlatDaily; }
            set
            {
                try
                {
                    _endDateFlatDaily = value;
                    //_dailyPaymentFlat = FlatDaily().ToString();       
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));

                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public string TermDaily
        {
            get { return _termDaily; }
            set
            {
                try
                {

                    _termDaily = value;
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()),2,MidpointRounding.AwayFromZero).ToString();
                    //_endDateDaily = _startDateDaily.AddDays(Convert.ToInt32(TermDaily)).Date;
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));

                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public string TermMonthly
        {
            get { return _termMonthly; }
            set
            {
                try
                {
                    //_endDateMonthly = _startDateMonthly.AddMonths(Convert.ToInt32(TermMonthly)).Date;
                    _termMonthly = value;
                    _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()),2 ,MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public string TermFlat
        {
            get { return _termFlat; }
            set
            {
                try
                {
                    //_endDateFlat = _startDateFlat.AddMonths(Convert.ToInt32(TermFlat)).Date;
                    _termFlat = value;
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()),2,MidpointRounding.AwayFromZero).ToString();
                    // _endDateFlat = StartDateFlat.AddMonths(Convert.ToInt32(TermFlat) - 1);
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5.)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));


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
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()),2,MidpointRounding.AwayFromZero).ToString();
                    //_endDateFlatDaily = _startDateFlatDaily.AddDays(Convert.ToInt32(TermFlatDaily));

                    //  _endDateFlatDaily = _startDateFlatDaily.AddDays(Convert.ToInt32(TermFlatDaily)).Date;
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }

                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));
            }
        }

        public string DailyPaymentFlat
        {
            get { return _dailyPaymentFlat; }
            set
            {
                try
                {
                    _dailyPaymentFlat = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestF"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }
        public string DailyPayment
        {
            get { return _dailyPayment; }
            set
            {
                try
                {
                    _dailyPayment = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                    OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public string MonthlyPayment
        {
            get { return _monthlyPayment; }
            set
            {
                try
                {
                    _monthlyPayment = value;
                    //_termMonthly = NperMonthly();
                    GraphMonthly();
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                    OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public string MonthlyPaymentFlat
        {
            get { return _monthlyPaymentFlat; }
            set
            {
                try
                {
                    _monthlyPaymentFlat = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                    OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
                    OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDateFlat"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
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
                string peyment = pmt.ToString();
                if (!Double.IsNaN(pmt) && !Double.IsInfinity(pmt) && pmt != 0)
                {
                    return peyment;
                }
                else return string.Empty;
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
                double pmt;
                double h = CountDaysForMonthly();
                double rate = Convert.ToDouble(DailyInterestELM) * h / (100 * Convert.ToDouble(TermMonthly));
                if (rate == 0)
                {
                    rate = Convert.ToDouble(DailyInterestELM) * Convert.ToDouble(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
                }
                if (CounterForMonthly() > 31)
                {
                    pmt = Convert.ToDouble(LoanAmountELM) * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermMonthly) - Convert.ToDouble(InterestOnlyELM)))));
                }
                else pmt = Convert.ToDouble(LoanAmountELM) * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermMonthly) - Convert.ToDouble(InterestOnlyELM) + 1))));
                string peyment = pmt.ToString();
                if (!Double.IsNaN(pmt) && !Double.IsInfinity(pmt) && pmt != 0)
                {
                    return peyment;
                }
                else return string.Empty;
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
                string peyment = flatPayment.ToString();
                if (!Double.IsNaN(flatPayment) && !Double.IsInfinity(flatPayment) && flatPayment != 0)
                {
                    return peyment;
                }
                else return string.Empty;
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
                string peyment = flatPayment.ToString();
                if (!Double.IsNaN(flatPayment) && !Double.IsInfinity(flatPayment) && flatPayment != 0)
                {
                    return peyment;
                }
                else return string.Empty;
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
                    if (Convert.ToDouble(InterestOnlyELM) > 0)
                    {
                        if (CounterForMonthly() > 31)
                        {
                            while (i < 2)
                            {
                                DateTime dateTime11 = StartDateMonthly.AddMonths(i - 1);
                                double h = Convert.ToDouble(PMTMonthly());
                                double principal11 = h - amount * monthlyRate;
                                double interest11 = CounterForMonthly() * principal11;
                                double peyment = principal11 + interest11;
                                balance -= principal11;
                                ItemsMonthly.Add(new GridItem()
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round(peyment, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                });
                                amount -= principal11;
                                i++;
                            }
                            while (i <= (Convert.ToDouble(InterestOnlyELM) + 1))
                            {
                                DateTime dateTime1 = StartDateMonthly.AddMonths(i - 1);
                                double interest1 = amount * monthlyRate;
                                double principal1 = 0.00;
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
                            while (i <= Convert.ToDouble(InterestOnlyELM))
                            {
                                DateTime dateTime1 = StartDateMonthly.AddMonths(i - 1);
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
                    }
                    else
                    {
                        if (CounterForMonthly() > 0)
                        {
                            while (i < 2)
                            {
                                DateTime dateTime11 = StartDateMonthly.AddMonths(i - 1);
                                double h = Convert.ToDouble(PMTMonthly());
                                double principal11 = h - amount * monthlyRate;
                                double interest11 = CounterForMonthly() * principal11;
                                double peyment = principal11 + interest11;
                                balance -= principal11;
                                ItemsMonthly.Add(new GridItem()
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round(peyment, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                });
                                amount -= principal11;
                                i++;
                            }
                        }
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
                        Payment = FlatDaily().ToString(),
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
