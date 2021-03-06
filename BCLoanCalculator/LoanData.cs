﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

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
            _startDateFlat = App.StartDateFM;
            _endDateFlat = App.EndDateFM;
            _releaseDateFlat = App.ReleaseDateFM;
            _annualInterestEL = App.AnnualInterestEL;
            _dailyInterestEL = App.DailyInterestEL;
            _loanAmountEL = App.LoanAmountEL;
            _dailyPayment = App.PeymentEL;
            _interestOnlyEL = App.InterestOnlyEL;
            _termDaily = String.Empty;
            _startDateDaily = App.StartDateEL;
            _endDateDaily = App.EndDateEL;
            _loanAmountELM = App.LoanAmountELM;
            _termMonthly = App.TermELM;
            _monthlyPayment = App.PeymentELM;
            _interestOnlyELM = App.InterestOnlyELM;
            _monthlyInterestELM = App.MonthlyInterestELM;
            _annualInterestForMonthlyELM = App.AnnualInterestELM;
            _endDateMonthly = App.EndDateELM;
            _startDateMonthly = App.StartDateELM;
            _releaseDate = App.ReleaseDateELM;       
            _loanAmountF = App.LoanAmountF;
            _termFlatDaily = App.TermF;
            _dailyPaymentFlat = App.PeymentF;
            _annualInterestF = App.AnnualInterestF;
            _dailyInterestF = App.DailyInterestF;
            _startDateFlatDaily = App.StartDateF;
            _endDateFlatDaily = App.EndDateF;
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
        private string _effectiveRate;
        private string _effectiveRateD;


        #endregion


        public string EffectiveRate
        {
            get { return _effectiveRate; }
            set
            {
                _effectiveRate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
                OnPropertyChanged(new PropertyChangedEventArgs("EffectiveRate"));

            }
        }
        public string EffectiveRateD
        {
            get { return _effectiveRateD; }
            set
            {
                _effectiveRateD = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyELM"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
                OnPropertyChanged(new PropertyChangedEventArgs("EffectiveRateD"));

            }
        }

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
                    _effectiveRate = Math.Round((Math.Pow((1 + Convert.ToDouble(AnnualInterestForMonthlyELM) / 12), 12) - 1) * 100, 3, MidpointRounding.AwayFromZero).ToString();

                    _dailyInterestELM = (Convert.ToDouble(_annualInterestForMonthlyELM) / 365).ToString();
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    }


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
                OnPropertyChanged(new PropertyChangedEventArgs("EffectiveRate"));

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
                    _dailyInterestF = (Convert.ToDouble(value) / 365).ToString();
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));

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
                    _monthlyInterestF = Math.Round(Convert.ToDouble(_annualInterestForMonthlyF) / 12, 3, MidpointRounding.AwayFromZero).ToString();
                    _dailyInterestF = (Convert.ToDouble(_annualInterestForMonthlyF) / 365).ToString();
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterestF"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));

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
                    _effectiveRate = Math.Round((Math.Pow((1 + Convert.ToDouble(AnnualInterestForMonthlyELM) / 12), 12) - 1) * 100, 3, MidpointRounding.AwayFromZero).ToString();

                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
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
                OnPropertyChanged(new PropertyChangedEventArgs("EffectiveRate"));

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
                    _effectiveRateD = ((Math.Pow((1 + Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500), 365) - 1) * 100).ToString();

                    if (App.Toggle1 != true)
                    {
                        _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    }

                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)"; ;
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("EffectiveRateD"));

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
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
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
                    _dailyInterestFM = value;
                    _annualInterestForMonthlyF = Math.Round(Convert.ToDouble(value) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                    _annualInterestEL = value;
                    _dailyInterestEL = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                    _effectiveRateD = ((Math.Pow((1 + Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500), 365) - 1) * 100).ToString();
                    if (App.Toggle1 != true)
                    {
                        _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EffectiveRateD"));

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
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
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
                    //_monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    _annualInterestFM = value;
                    _dailyInterestFM = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthlyF"));
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
                    _loanAmountEL = value;
                    if (App.Toggle1 != true)
                    {
                        _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));

            }
        }
        public string LoanAmountELM
        {
            get { return _loanAmountELM; }
            set
            {
                try
                {
                    _loanAmountELM = value;
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
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

                    _loanAmountFM = value;
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountFM"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
            }
        }
        public string LoanAmountF
        {
            get { return _loanAmountF; }
            set
            {
                try
                {
                    _loanAmountF = value;
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPaymentFlat"));
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
                    if (App.Toggle1 != true)
                    {
                        _termDaily = CountDays().ToString();
                        _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
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
                    if (App.Toggle1 == false)
                    {
                        _termDaily = CountDays().ToString();
                        _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
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
                    _termMonthly = CountMonths().ToString();
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                    _termMonthly = CountMonths().ToString();
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
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

        public DateTime EndDateMonthly
        {
            get { return _endDateMonthly; }
            set
            {
                try
                {
                    _endDateMonthly = value;
                    _termMonthly = CountMonths().ToString();
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                    _releaseDateFlat = value;
                    _termFlat = CountMonthsForFlat().ToString();
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                    _startDateFlat = value;
                    MonthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                    _termFlat = CountMonthsForFlat().ToString();
                    _monthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                    _termFlatDaily = CountDaysForFlatDaily().ToString();
                    _dailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
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
                    _termFlatDaily = CountDaysForFlatDaily().ToString();
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
                    if (App.Toggle1 == false)
                    {
                        if (Convert.ToDouble(_dailyPayment) > 0)
                        {
                            _termDaily = NperDaily();
                        }
                        else
                        {
                            _termDaily = value;
                            DailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                        }
                        OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                        OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                        OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
                        OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                    }
                    else _termDaily = value;
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
                    if (App.Toggle2 == false)
                    {
                        if (Convert.ToDouble(MonthlyPayment) > 0)
                        {
                            _termMonthly = NperMonthly().ToString();
                        }
                        else
                        {
                            _termMonthly = value;
                            MonthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                        }
                        OnPropertyChanged(new PropertyChangedEventArgs("TermMonthly"));
                        OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPayment"));
                        OnPropertyChanged(new PropertyChangedEventArgs("EndDateMonthly"));
                        OnPropertyChanged(new PropertyChangedEventArgs("StartDateMonthly"));
                        OnPropertyChanged(new PropertyChangedEventArgs("ReleaseDate"));
                    }
                    else _termMonthly = value;
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
                    _termFlat = value;
                    if (App.Toggle22 == false)
                    {
                        MonthlyPaymentFlat = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5.)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartDateFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlat"));
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
                    if (App.Toggle11 == false)
                    {
                        DailyPaymentFlat = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    }
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("StartdateFlatDaily"));
                OnPropertyChanged(new PropertyChangedEventArgs("EndDateFlatDaily"));
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

                    if (App.Toggle1 == false)
                    {
                        if (Convert.ToDouble(_dailyPayment) > 0)
                        {
                            TermDaily = NperDaily();
                        }
                        OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                        OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                        OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                        OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                        OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                        OnPropertyChanged(new PropertyChangedEventArgs("TermDaily"));
                        OnPropertyChanged(new PropertyChangedEventArgs("StartDateDaily"));
                        OnPropertyChanged(new PropertyChangedEventArgs("EndDateDaily"));
                    }
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
                    if (App.Toggle2 == false)
                    {
                        if (Convert.ToDouble(_monthlyPayment) > 0)
                        {
                            TermMonthly = NperMonthly().ToString();
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

        public int CountDaysM()
        {
            return (EndDateMonthly - StartDateMonthly).Days;
        }

        public int CountDaysForMonthly()
        {
            return (EndDateMonthly - ReleaseDate).Days;
        }

        public int CounterForMonthly()
        {
            return (StartDateMonthly - ReleaseDate).Days;
        }

        public int CountDaysForFlat()
        {
            return (EndDateFlat - StartDateFlat).Days;
        }
        public int CountDaysFromStartDateToNextPayment()
        {
            return ((StartDateMonthly.Date.AddMonths(CountMonthsFromStartToRelease() - 1) - ReleaseDate).Days);
        }
        public int CountMonthsFromStartToRelease()
        {
            return (StartDateMonthly.Month - ReleaseDate.Month) + 12 * (StartDateMonthly.Year - ReleaseDate.Year);
        }
        public int CountMonthsFromStartToReleaseFlat()
        {
            return (StartDateFlat.Month - ReleaseDateFlat.Month) + 12 * (StartDateFlat.Year - ReleaseDateFlat.Year);
        }
        public int CountMonths()
        {
            return (EndDateMonthly.Month - ReleaseDate.Month) + 12 * (EndDateMonthly.Year - ReleaseDate.Year);
        }
        public int CountMonthsEndRelease()
        {
            return (EndDateMonthly.Month - StartDateMonthly.Month) + 12 * (EndDateMonthly.Year - StartDateMonthly.Year) + 1;
        }
        public int CountMonthsForFlat()
        {
            return (EndDateFlat.Month - ReleaseDateFlat.Month) + 12 * (EndDateFlat.Year - ReleaseDateFlat.Year);
        }
        public int CountMonthsForFlatStartEnd()
        {
            return (EndDateFlat.Month - StartDateFlat.Month) + 12 * (EndDateFlat.Year - StartDateFlat.Year) + 1;
        }
        public int CountDaysForFlatDaily()
        {
            return (EndDateFlatDaily - StartdateFlatDaily).Days;
        }
        public string PMTDaily()
        {
            try
            {
                int interestonly;
                if (String.IsNullOrEmpty(InterestOnlyEL))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnlyEL);
                double rate = Convert.ToDouble(DailyInterestEL) / 100;
                double pmt = Convert.ToDouble(LoanAmountEL) * Convert.ToDouble(rate) / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermDaily) - interestonly))));
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
                int interestonly;
                if (String.IsNullOrEmpty(InterestOnlyELM))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnlyELM);
                double pmt;
                // double rate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
                double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 1200;

                //if (rate == 0)
                //{
                //    rate = Convert.ToDouble(DailyInterestELM) * Convert.ToDouble(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
                //}
                //if (CounterForMonthly() > 0)
                //{
                //    pmt = Convert.ToDouble(LoanAmountELM) * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermMonthly) - interestonly + 1))));
                //}
                if (ReleaseDate.Date.AddMonths(1) == StartDateMonthly.Date)
                {
                    pmt = Convert.ToDouble(LoanAmountELM) * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermMonthly) - interestonly))));
                }
                else
                {
                    pmt = Convert.ToDouble(LoanAmountELM) * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), CountMonthsEndRelease() - interestonly))));
                }
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
                double rate = Convert.ToDouble(MonthlyInterestF) / 100;

                //if (rate == 0)
                //{
                //    rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * Convert.ToDouble(TermFlat) * 30 / 100;
                //}
                //if (CounterForFlat() > 0)
                //{
                //    rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * CountDaysForFlat() / (100 * (Convert.ToDouble(TermFlat) + 1));
                //    flatPayment = (Convert.ToDouble(LoanAmountFM) + (rate * Convert.ToDouble(LoanAmountFM))) / (Convert.ToDouble(TermFlat) + 1);
                //}
                if (ReleaseDateFlat.Date.AddDays(1).AddMonths(1).AddDays(-1) == StartDateFlat.Date)
                {
                    flatPayment = rate * Convert.ToDouble(LoanAmountFM) + Convert.ToDouble(LoanAmountFM) / Convert.ToInt32(TermFlat);
                }
                else
                {
                    flatPayment = rate * Convert.ToDouble(LoanAmountFM) + Convert.ToDouble(LoanAmountFM) / CountMonthsForFlatStartEnd();
                }
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

        public string NperDaily()
        {
            double nper = 0;
            try
            {
                double rate = Convert.ToDouble(DailyInterestEL) / 100;
                nper = -Math.Log((1 - (rate * Convert.ToDouble(LoanAmountEL) / Convert.ToDouble(DailyPayment))), Math.E) / Math.Log((1 + rate), Math.E);
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            return nper.ToString();
        }

        public int NperMonthly()
        {
            double nper = 0;
            try
            {
                //double rate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
                double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 1200;
                nper = -Math.Log((1 - (rate * Convert.ToDouble(LoanAmountELM) / Convert.ToDouble(MonthlyPayment))), Math.E) / Math.Log((1 + rate), Math.E);
                if (Double.IsNaN(nper))
                {
                    nper = 0;
                }
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            return Convert.ToInt32(nper);
        }

        //public int NperMonthlyFlat()
        //{
        //    double nper = 0;
        //    try
        //    {
        //        //double rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * CountDaysForFlat() / (100 * Convert.ToDouble(TermFlat));

        //        double rate = (Convert.ToDouble(AnnualInterestForMonthlyF) / 365) * CountDaysForFlat() / 100;
        //        //if (rate == 0)
        //        //{
        //        //    rate = Convert.ToDouble(DailyInterestFM) * Convert.ToDouble(TermFlat) * 30 / 100;
        //        //}
        //        nper = (Convert.ToDouble(LoanAmountFM) * (rate + 1)) / Convert.ToDouble(MonthlyPaymentFlat);
        //    }
        //    catch (Exception)
        //    {
        //        _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
        //    }
        //    return Convert.ToInt32(nper);
        //}

        //public int NperDailyFlat()
        //{
        //    double nper = 0;
        //    try
        //    {
        //        double rate = (Convert.ToDouble(AnnualInterestF)/365) * CountDaysForFlatDaily() / 100;
        //        nper = Convert.ToDouble(LoanAmountF) * (rate + 1) / Convert.ToDouble(DailyPaymentFlat);
        //    }
        //    catch (Exception)
        //    {
        //        _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
        //    }
        //    return Convert.ToInt32(nper);
        //}

        public string InterestOnlyEL
        {
            get { return _interestOnlyEL; }
            set
            {
                try
                {

                    _interestOnlyEL = value;
                    _dailyPayment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(new PropertyChangedEventArgs("LoanAmountEL"));
                    OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestEL"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyInterestEL"));
                    OnPropertyChanged(new PropertyChangedEventArgs("DailyPayment"));
                    OnPropertyChanged(new PropertyChangedEventArgs("InterestOnlyEL"));
                }
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public string InterestOnlyELM
        {
            get { return _interestOnlyELM; }
            set
            {
                try
                {
                    _interestOnlyELM = value;
                    if (App.Toggle2 == false)
                    {
                        _monthlyPayment = Math.Round(Convert.ToDouble(PMTMonthly()), 2, MidpointRounding.AwayFromZero).ToString();
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
                catch (Exception)
                {
                    _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
                }
            }
        }

        public void GraphDaily()
        {
            try
            {
                Items.Clear();
                // CultureInfo ci = new CultureInfo("en-US");
                double sumI = 0;
                double sumP = 0;
                double amount = Convert.ToDouble(LoanAmountEL);
                double balance = Convert.ToDouble(LoanAmountEL);
                double dailyInterest = Convert.ToDouble(DailyInterestEL) / 100;
                int term = Convert.ToInt32(TermDaily) - 1;
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
                int interestonly;
                if (String.IsNullOrEmpty(InterestOnlyEL))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnlyEL);

                for (int i = 0; i < Convert.ToInt32(TermDaily); i++)
                {
                    if (App.Toggle1 == true)
                    {
                        if (Convert.ToDouble(PMTDaily()) < Convert.ToDouble(DailyPayment))
                        {
                            do
                            {
                                if (Convert.ToDouble(interestonly) > 0)
                                {
                                    while (i < Convert.ToDouble(interestonly))
                                    {
                                        i++;
                                        DateTime dateTime10 = StartDateDaily.AddDays(i);
                                        double interest10 = amount * dailyInterest;
                                        double principal10 = 0.00;
                                        balance = Convert.ToDouble(LoanAmountEL);
                                        Items.Add(new GridItem()
                                        {
                                            PaymentNumber = i.ToString(),
                                            Date = dateTime10.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(interest10, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = Math.Round(principal10, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Interest = Math.Round(interest10, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                        });
                                        amount = Convert.ToDouble(LoanAmountEL);
                                        sumI += Math.Round(interest10, 2, MidpointRounding.AwayFromZero);
                                        sumP += Math.Round(interest10, 2, MidpointRounding.AwayFromZero);
                                    }
                                }
                                DateTime dateTime = StartDateDaily.AddDays(i + 1);
                                double interest = amount * dailyInterest;
                                double principal = Convert.ToDouble(DailyPayment) - Math.Round(interest, 2, MidpointRounding.AwayFromZero);
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
                                i++;
                                sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                sumP += Convert.ToDouble(DailyPayment);
                            }
                            while ((balance - Convert.ToDouble(DailyPayment)) > 0);
                            DateTime dateTime1 = StartDateDaily.AddDays(i + 1);
                            double interest1 = amount * dailyInterest;
                            double principal1 = balance;
                            balance -= principal1;
                            Items.Add(new GridItem()
                            {
                                PaymentNumber = (i + 1).ToString(),
                                Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round((interest1 + amount), 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal1;
                            sumP += Math.Round((interest1 + amount), 2, MidpointRounding.AwayFromZero);
                            sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            i = Convert.ToInt32(TermDaily);
                            OnPropertyChanged(new PropertyChangedEventArgs("Items"));

                        }
                        else
                        {
                            if ((Convert.ToDouble(PMTDaily()) > Convert.ToDouble(DailyPayment)))
                            {
                                while (i < term)
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        while (i < Convert.ToDouble(interestonly))
                                        {
                                            i++;
                                            DateTime dateTime12 = StartDateDaily.AddDays(i);
                                            double interest12 = amount * dailyInterest;
                                            double principal12 = 0.00;
                                            balance = Convert.ToDouble(LoanAmountEL);
                                            Items.Add(new GridItem()
                                            {
                                                PaymentNumber = i.ToString(),
                                                Date = dateTime12.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest12, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal12, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest12, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                            });
                                            amount = Convert.ToDouble(LoanAmountEL);
                                            sumI += Math.Round(interest12, 2, MidpointRounding.AwayFromZero);
                                            sumP += Math.Round(interest12, 2, MidpointRounding.AwayFromZero);

                                        }
                                    }
                                    DateTime dateTime = StartDateDaily.AddDays(i + 1);
                                    double interest = amount * dailyInterest;
                                    double principal = Convert.ToDouble(DailyPayment) - Math.Round(interest, 2, MidpointRounding.AwayFromZero);
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
                                    i++;
                                    sumP += Math.Round(Convert.ToDouble(DailyPayment), 2, MidpointRounding.AwayFromZero);
                                    sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                }
                                DateTime dateTime1 = StartDateDaily.AddDays(i + 1);
                                double interest1 = amount * dailyInterest;
                                double principal1 = amount;
                                balance -= principal1;
                                Items.Add(new GridItem()
                                {
                                    PaymentNumber = (i + 1).ToString(),
                                    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round(interest1 + amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                });
                                amount -= principal1;
                                sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                sumP += Math.Round(interest1 + amount, 2, MidpointRounding.AwayFromZero);
                                OnPropertyChanged(new PropertyChangedEventArgs("Items"));
                            }
                            else
                            {
                                if (Convert.ToDouble(interestonly) > 0)
                                {
                                    while (i < Convert.ToDouble(interestonly))
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
                                        sumP += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                        sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
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
                                    Payment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                });
                                amount -= principal;
                                OnPropertyChanged(new PropertyChangedEventArgs("Items"));
                                sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                sumP += Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(interestonly) > 0)
                        {
                            while (i < Convert.ToDouble(interestonly))
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
                                sumP += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
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
                            Payment = Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero).ToString(),
                            EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                            Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                            Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                        });
                        amount -= principal;
                        OnPropertyChanged(new PropertyChangedEventArgs("Items"));
                        sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                        sumP += Math.Round(Convert.ToDouble(PMTDaily()), 2, MidpointRounding.AwayFromZero);
                    }
                }
                ItemsSum.Add(new GridItem()
                {
                    InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(),
                    PeymentSum = Math.Round(sumP, 2, MidpointRounding.AwayFromZero).ToString(),
                    sumSum = Math.Round(sumP / sumI, 2, MidpointRounding.AwayFromZero).ToString()
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
                double SumI = 0;
                double SumP = 0;
                ItemsMonthly.Clear();
                double amount = Convert.ToDouble(LoanAmountELM);
                double balance = Convert.ToDouble(LoanAmountELM);
                //double monthlyRate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly)); //// <<<<<<<
                double monthlyRate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 1200;
                int time = CountMonthsFromStartToRelease();
                DateTime DT = ReleaseDate.Date.AddMonths(CountMonthsFromStartToRelease());
                if (monthlyRate == 0)
                {
                    monthlyRate = Convert.ToDouble(DailyInterestELM) * Convert.ToInt32(TermMonthly) * 30.417 / (100 * Convert.ToDouble(TermMonthly));
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
                int interestonly;
                if (String.IsNullOrEmpty(InterestOnlyELM))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnlyELM);
                #region chveulebriviiiiiiii
                #region start==release
                if (StartDateMonthly.Date.AddDays(1).AddMonths(-1).AddDays(-1) == ReleaseDate.Date.Date)
                {
                    for (int i = 1; i <= Convert.ToDouble(TermMonthly); i++)
                    {
                        if (App.Toggle2 == true)
                        {
                            if (Convert.ToDouble(MonthlyPayment) > Convert.ToDouble(PMTMonthly()))
                            {
                                do
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        while (i <= interestonly)
                                        {
                                            DateTime dateTime11 = StartDateMonthly.AddMonths(i);
                                            double principal11 = 0;
                                            double interest11 = monthlyRate * amount;
                                            balance -= principal11;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                            });
                                            SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            amount -= principal11;
                                            i++;
                                        }
                                    }
                                    DateTime dateTime = ReleaseDate.AddMonths(i);
                                    double principal = Convert.ToDouble(MonthlyPayment) - amount * monthlyRate;
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
                                    SumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                    amount -= principal;
                                    i++;
                                }
                                while ((balance - Convert.ToDouble(MonthlyPayment)) > 0);

                                DateTime dateTime22 = ReleaseDate.AddMonths(i);
                                double principal22 = balance;
                                double interest22 = amount * monthlyRate;
                                balance -= principal22;
                                ItemsMonthly.Add(new GridItem()
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime22.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round((interest22 + amount), 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal22, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest22, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                });
                                i = Convert.ToInt32(TermMonthly);
                                SumP += Math.Round((interest22 + amount), 2, MidpointRounding.AwayFromZero);
                                SumI += Math.Round(interest22, 2, MidpointRounding.AwayFromZero);
                            }
    
                            if (Convert.ToDouble(MonthlyPayment) < Convert.ToDouble(PMTMonthly()))
                            {
                                while (i < Convert.ToInt32(TermMonthly))
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        while (i <= interestonly)
                                        {
                                            DateTime dateTime11 = StartDateMonthly.AddMonths(i);
                                            double principal11 = 0;
                                            double interest11 = monthlyRate * amount;
                                            balance -= principal11;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                            });
                                            amount -= principal11;
                                            i++;
                                            SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                        }
                                    }
                                    DateTime dateTime22 = StartDateMonthly.AddMonths(i);
                                    double principal22 = Convert.ToDouble(MonthlyPayment) - amount * monthlyRate;
                                    double interest22 = amount * monthlyRate;
                                    balance -= principal22;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime22.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(principal22, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest22, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                    });
                                    i++;
                                    SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                    SumI += Math.Round(interest22, 2, MidpointRounding.AwayFromZero);
                                }
                                DateTime dateTime = StartDateMonthly.AddMonths(i);
                                double principal = balance;
                                double interest = amount * monthlyRate;
                                balance -= principal;
                                ItemsMonthly.Add(new GridItem()
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round((interest + amount), 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                });
                                SumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                SumP += Math.Round((interest + amount), 2, MidpointRounding.AwayFromZero);
                            }

                            else
                            {
                                while (i < Convert.ToInt32(TermMonthly))
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        //for (int i = 1; i <= Convert.ToDouble(TermMonthly); i++)
                                        //{
                                        while (i <= interestonly)
                                        {
                                            DateTime dateTime11 = ReleaseDate.AddMonths(i);
                                            double principal11 = 0;
                                            double interest11 = monthlyRate * amount;
                                            balance -= principal11;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                            });
                                            amount -= principal11;
                                            i++;
                                            SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                        }
                                    }
                                    DateTime dateTime = ReleaseDate.AddMonths(i);
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
                                    SumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                    amount -= principal;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(interestonly) > 0)
                            {
                                //for (int i = 1; i <= Convert.ToDouble(TermMonthly); i++)
                                //{
                                while (i <= interestonly)
                                {
                                    DateTime dateTime11 = StartDateMonthly.AddMonths(i);
                                    double principal11 = 0;
                                    double interest11 = monthlyRate * amount;
                                    balance -= principal11;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                    });
                                    amount -= principal11;
                                    i++;
                                    SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);

                                }
                            }
                            DateTime dateTime = StartDateMonthly.AddMonths(i);
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
                            SumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                            SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                            amount -= principal;
                            //}
                        }
                    }
                }
                #endregion
                else
                {
                    int x = CountMonthsEndRelease() + 1;
                    int y = x - 1;
                    double interesetIpayment = CounterForMonthly() * ((Convert.ToDouble(AnnualInterestForMonthlyELM) / 100) / 365) * Convert.ToDouble(LoanAmountELM);
                    #region interesetIpayment >= Convert.ToDouble(PMTMonthly())
                    if (interesetIpayment >= Convert.ToDouble(PMTMonthly()))
                    {

                        if (App.Toggle2 == true)
                        {
                            for (int i = 1; i <= x; i++)
                            {
                                #region (Convert.ToDouble(MonthlyPayment) > Convert.ToDouble(PMTMonthly())
                                if (Convert.ToDouble(MonthlyPayment) > Convert.ToDouble(PMTMonthly()))
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = ReleaseDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                                        //double interest = amount * monthlyRate;
                                        //balance -= principal;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDateMonthly.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = 0.ToString(),
                                            Interest = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        i++;
                                        SumP += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        SumI += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);

                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = "0",
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                ItemsMonthly.Add(new GridItem()
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                                });
                                                amount -= principal11;
                                                i++;
                                                SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                                SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime2 = DT.AddMonths(i - 1);
                                        double principal2 = Convert.ToDouble(MonthlyPayment) - amount * monthlyRate;
                                        double interest2 = amount * monthlyRate;
                                        balance -= principal2;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime2.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = Math.Round(principal2, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Interest = Math.Round(interest2, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        amount -= principal2;
                                        i++;
                                        SumI += Math.Round(interest2, 2, MidpointRounding.AwayFromZero);
                                        SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                    }
                                    while ((amount - Convert.ToDouble(MonthlyPayment)) > 0);

                                    DateTime dateTime3 = DT.AddMonths(i - 1);
                                    double interest3 = amount * monthlyRate;
                                    double principal3 = amount * monthlyRate;

                                    balance -= amount;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(interest3 + amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest3, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                    });
                                    SumI += Math.Round(interest3, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(interest3 + amount, 2, MidpointRounding.AwayFromZero);
                                    amount -= principal3;
                                    i = x;
                                }
                                #endregion


                                #region reggadasaxadi naklebiapeimentze
                                else
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = ReleaseDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                                        //double interest = amount * monthlyRate;
                                        //balance -= principal;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDateMonthly.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = "0",
                                            Interest = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        i++;
                                        SumI += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        SumP += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);

                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = "0",
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                ItemsMonthly.Add(new GridItem()
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                                });
                                                amount -= principal11;
                                                i++;
                                                SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                                SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime3 = DT.AddMonths(i - 1);
                                        double interest3 = amount * monthlyRate;
                                        double principal3 = Convert.ToDouble(MonthlyPayment) - amount * monthlyRate;

                                        balance -= principal3;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = Math.Round(principal3, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Interest = Math.Round(interest3, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        SumI += Math.Round(interest3, 2, MidpointRounding.AwayFromZero);
                                        SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                        amount -= principal3;
                                        i++;
                                    } while (i < CountMonthsEndRelease());
                                    DateTime dateTime4 = DT.AddMonths(i - 1);
                                    double interest4 = amount * monthlyRate;
                                    double principal4 = amount;

                                    balance -= amount;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime4.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(amount + interest4, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest4, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                    });
                                    SumI += Math.Round(interest4, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(amount + interest4, 2, MidpointRounding.AwayFromZero);
                                    amount -= principal4;
                                    i = x;
                                }
                                #endregion
                            }
                        }

                        else
                        {
                            for (int i = 1; i <= x; i++)
                            {
                                #region (Convert.ToDouble(MonthlyPayment) > Convert.ToDouble(PMTMonthly())
                                if (Convert.ToDouble(MonthlyPayment) > Convert.ToDouble(PMTMonthly()))
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = ReleaseDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                                        //double interest = amount * monthlyRate;
                                        //balance -= principal;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDateMonthly.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = 0.ToString(),
                                            Interest = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        i++;
                                        SumI += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        SumP += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = "0",
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                ItemsMonthly.Add(new GridItem()
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                                });
                                                amount -= principal11;
                                                i++;
                                                SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                                SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime2 = DT.AddMonths(i - 1);
                                        double principal2 = Convert.ToDouble(MonthlyPayment) - amount * monthlyRate;
                                        double interest2 = amount * monthlyRate;
                                        balance -= principal2;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime2.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = Math.Round(principal2, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Interest = Math.Round(interest2, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        amount -= principal2;
                                        i++;
                                        SumI += Math.Round(interest2, 2, MidpointRounding.AwayFromZero);
                                        SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);

                                    }
                                    while ((amount - Convert.ToDouble(MonthlyPayment)) > 0);

                                    DateTime dateTime3 = DT.AddMonths(i - 1);
                                    double interest3 = amount * monthlyRate;
                                    double principal3 = amount * monthlyRate;

                                    balance -= amount;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(interest3 + amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest3, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                    });
                                    SumI += Math.Round(interest3, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(interest3 + amount, 2, MidpointRounding.AwayFromZero);
                                    amount -= principal3;
                                    i = x;
                                }
                                #endregion
                                #region reggadasaxadi naklebiapeimentze
                                else
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = ReleaseDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                                        //double interest = amount * monthlyRate;
                                        //balance -= principal;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDateMonthly.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = "0",
                                            Interest = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        i++;
                                        SumP += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        SumI += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = "0",
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                ItemsMonthly.Add(new GridItem()
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                                });
                                                amount -= principal11;
                                                i++;
                                                SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                                SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            ItemsMonthly.Add(new GridItem()
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                                Principal = Math.Round(principal21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                            });
                                            SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime3 = DT.AddMonths(i - 1);
                                        double interest3 = amount * monthlyRate;
                                        double principal3 = Convert.ToDouble(MonthlyPayment) - amount * monthlyRate;

                                        balance -= principal3;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = Math.Round(principal3, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Interest = Math.Round(interest3, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                        });
                                        SumI += Math.Round(interest3, 2, MidpointRounding.AwayFromZero);
                                        SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                        amount -= principal3;
                                        i++;
                                    } while (i < CountMonthsEndRelease());
                                    DateTime dateTime4 = DT.AddMonths(i - 1);
                                    double interest4 = amount * monthlyRate;
                                    double principal4 = amount;

                                    balance -= amount;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime4.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(amount + interest4, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest4, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                    });
                                    SumI += Math.Round(interest4, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(amount + interest4, 2, MidpointRounding.AwayFromZero);
                                    amount -= principal4;
                                    i = x;
                                }
                                #endregion

                            
                            }
                        }
                    }
                    #endregion

                    #region pirveli gadaxda maleveaa
                    else
                    {
                        for (int i = 1; i <= y; i++)
                        {
                            while (i < 3)
                            {
                                DateTime dateTime1 = ReleaseDate.AddMonths(i);
                                double principal0 = Convert.ToDouble(MonthlyPayment) - interesetIpayment;
                                //  double interest0 = amount * monthlyRate;
                                balance -= principal0;
                                ItemsMonthly.Add(new GridItem()
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = StartDateMonthly.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal0, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                });
                                amount -= principal0;
                                i++;
                                SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                SumI += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);

                                if (Convert.ToDouble(interestonly) > 0)
                                {

                                    DateTime dateTime21 = DT.AddMonths(i-1);
                                    int N = (dateTime21 - StartDateMonthly).Days;
                                    double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * N;

                                    double interest21 = amount * rate;
                                    double principal21 = 0;

                                    balance -= principal21;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = "0",
                                        Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                    });
                                    SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                    amount -= principal21;
                                    i++;

                                    while (i <= (interestonly + 1))
                                    {
                                        DateTime dateTime11 = DT.AddMonths(i-1);
                                        double principal11 = 0;
                                        double interest11 = monthlyRate * amount;
                                        balance -= principal11;
                                        ItemsMonthly.Add(new GridItem()
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                            Payment = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                            EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Principal = Math.Round(principal11, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Interest = Math.Round(interest11, 2, MidpointRounding.AwayFromZero).ToString(),
                                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                        });
                                        amount -= principal11;
                                        i++;
                                        SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                        SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                    }
                                }
                                else
                                {
                                    DateTime dateTime21 = DT.AddMonths(i - 1);
                                    int N = (dateTime21 - StartDateMonthly).Days;
                                    double rate = Convert.ToDouble(AnnualInterestForMonthlyELM) / 36500 * N;
                                    double principal21 = Convert.ToDouble(MonthlyPayment) - amount * rate;
                                    double interest21 = amount * rate;
                                    balance -= principal21;
                                    ItemsMonthly.Add(new GridItem()
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(principal21, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest21, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                    });
                                    SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                    amount -= principal21;
                                    i++;
                                }
                            }
                            while (balance - Convert.ToDouble(MonthlyPayment)>0)
                            {
                                DateTime dateTime4 = DT.AddMonths(i-1);
                                double principal4 = Convert.ToDouble(MonthlyPayment) - amount * monthlyRate;
                                double interest4 = amount * monthlyRate;
                                balance -= principal4;
                                ItemsMonthly.Add(new GridItem()
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime4.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal4, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest4, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                                });
                                SumI += Math.Round(interest4, 2, MidpointRounding.AwayFromZero);
                                SumP += Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero);
                                amount -= principal4;
                                i++;
                            } 

                            DateTime dateTime = DT.AddMonths(i-1);
                            double principal = amount;
                            double interest = amount * monthlyRate;
                            balance -= amount;
                            ItemsMonthly.Add(new GridItem()
                            {
                                PaymentNumber = (i).ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round((amount + interest), 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                            });
                            SumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                            SumP += Math.Round((amount + interest), 2, MidpointRounding.AwayFromZero);
                            amount -= principal;
                            i = y;
                        }
                        #endregion

                        #endregion
                    }
                }
                ItemsMonthlySum.Add(new GridItem()
                {
                    InterestSum = Math.Round(SumI, 2, MidpointRounding.AwayFromZero).ToString(),
                    PeymentSum = Math.Round(SumP, 2, MidpointRounding.AwayFromZero).ToString(),
                    sumSum = Math.Round(SumP / SumI, 2, MidpointRounding.AwayFromZero).ToString()
                });
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
        }


        public void GraphFlatPercentageMonthly()
        {
            try
            {
                double SumI = 0;
                double SumP = 0;

                //FlatPercentageItems.Clear();
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
                #region star=rel
                if (StartDateFlat.Date == ReleaseDateFlat.Date.AddDays(1).AddMonths(1).AddDays(-1))
                {
                    for (int i = 1; i <= Convert.ToDouble(TermFlat); i++)
                    {
                        if (App.Toggle22 == true)
                        {
                            if (Convert.ToDouble(MonthlyPaymentFlat) < Convert.ToDouble(FlatMonthly()))
                            {
                                rate = Convert.ToDouble(MonthlyInterestF) / 100;
                                double interest0 = Convert.ToDouble(LoanAmountFM) * rate;
                                do
                                {
                                    DateTime dateTime1 = ReleaseDateFlat.AddMonths(i);
                                    //double total = Convert.ToDouble(LoanAmountFM) * (1 + rate);
                                    principal = Convert.ToDouble(MonthlyPaymentFlat) - interest0;
                                    balance -= principal;
                                    FlatPercentageItems.Add(new GridItem()
                                    {
                                        PaymentNumber = i.ToString(),
                                        Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                        Payment = Math.Round(Convert.ToDouble(MonthlyPaymentFlat), 2, MidpointRounding.AwayFromZero).ToString(),
                                        Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Interest = Math.Round(interest0, 2, MidpointRounding.AwayFromZero).ToString(),
                                        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                                    });
                                    amount -= principal;
                                    i++;
                                    SumI += Math.Round(interest0, 2, MidpointRounding.AwayFromZero);
                                    SumP += Math.Round(Convert.ToDouble(MonthlyPaymentFlat), 2, MidpointRounding.AwayFromZero);
                                } while (Convert.ToDouble(TermFlat) > i);

                                DateTime dateTime = ReleaseDateFlat.AddMonths(i);
                                //double total = Convert.ToDouble(LoanAmountFM) * (1 + rate);
                                double principal1 = Convert.ToDouble(MonthlyPaymentFlat) - interest0;

                                principal = balance;
                                balance -= principal;
                                FlatPercentageItems.Add(new GridItem()
                                {
                                    PaymentNumber = i.ToString(),
                                    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round((amount + interest0), 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest0, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                                });
                                amount -= principal;
                                i++;
                                SumI += Math.Round(interest0, 2, MidpointRounding.AwayFromZero);
                                SumP += Math.Round((amount + interest0), 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                Ex = "მიუთითეთ მხოლოდ ყოველთვიურ გადასახადზე ნაკლები თანხა";
                                FlatPercentageItems.Clear();
                                FlatPercentageItemsSum.Clear();
                            }
                        }
                        else
                        {
                            rate = Convert.ToDouble(MonthlyInterestF) / 100 * Convert.ToDouble(LoanAmountFM);

                            DateTime dateTime = ReleaseDateFlat.AddMonths(i - 1);
                            principal = Convert.ToDouble(LoanAmountFM) / CountMonthsForFlatStartEnd();
                            balance -= principal;
                            FlatPercentageItems.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(rate, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal;
                            SumI += Math.Round(rate, 2, MidpointRounding.AwayFromZero);
                            SumP += Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero);
                        }
                    }
                }
                #endregion
                else
                {
                    for (int i = 1; i <= CountMonthsForFlatStartEnd(); i++)
                    {

                        while (i < 3)
                        {

                            DateTime dateTime1 = StartDateFlat;

                            rate = Convert.ToDouble(AnnualInterestForMonthlyF) / 365 * CounterForFlat() / 100;
                            double principal1 = Convert.ToDouble(LoanAmountFM) / CountMonthsForFlatStartEnd();
                            double interest1 = Convert.ToDouble(LoanAmountFM) * rate;
                            balance -= principal1;
                            if (rate * Convert.ToDouble(LoanAmountFM) > Convert.ToDouble(FlatMonthly()))
                            {
                                principal = 0;
                            }
                            //double peyment = interest1 + principal1;
                            FlatPercentageItems.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = StartDateFlat.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(principal1 + interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal1;
                            i++;
                            SumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            SumP += Math.Round(principal1 + interest1, 2, MidpointRounding.AwayFromZero);

                            DateTime dateTime12 = ReleaseDateFlat.Date.AddMonths(CountMonthsFromStartToReleaseFlat() + 1);
                            int N = (dateTime12 - StartDateFlat).Days;
                            double rate2 = Convert.ToDouble(AnnualInterestForMonthlyF) / 36500 * N;
                            double principal12 = Convert.ToDouble(LoanAmountFM) / CountMonthsForFlatStartEnd();
                            double interest12 = Convert.ToDouble(LoanAmountFM) * rate2;
                            balance -= principal1;
                            //double peyment = interest1 + principal1;
                            FlatPercentageItems.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime12.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(principal12 + interest12, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest12, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal1;
                            i++;
                            SumI += Math.Round(interest12, 2, MidpointRounding.AwayFromZero);
                            SumP += Math.Round(principal12 + interest12, 2, MidpointRounding.AwayFromZero);
                        }
                        if (App.Toggle22 == true)
                        {

                            do
                            {
                                rate = Convert.ToDouble(MonthlyInterestF) / 100;
                                DateTime dateTime111 = ReleaseDateFlat.AddMonths(i - 1);
                                principal = Convert.ToDouble(MonthlyPaymentFlat) - rate * Convert.ToDouble(LoanAmountFM);
                                if (rate * Convert.ToDouble(LoanAmountFM) > Convert.ToDouble(FlatMonthly()))
                                {
                                    principal = 0;
                                }

                                balance -= principal;
                                FlatPercentageItems.Add(new GridItem()
                                {
                                    PaymentNumber = i.ToString(),
                                    Date = dateTime111.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round(Convert.ToDouble(MonthlyPaymentFlat), 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round((Convert.ToDouble(MonthlyPaymentFlat) - principal), 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                                });
                                amount -= principal;
                                i++;
                                SumI += Math.Round(Convert.ToDouble(MonthlyPaymentFlat) - principal);
                                SumP += Math.Round(Convert.ToDouble(MonthlyPaymentFlat), 2, MidpointRounding.AwayFromZero);
                            }
                            while (i < CountMonthsForFlatStartEnd());

                            double Rrate = Convert.ToDouble(MonthlyInterestF) / 100.00;

                            DateTime dateTime = ReleaseDateFlat.AddMonths(i - 1);
                            principal = amount;
                            double interesetii = Rrate * Convert.ToDouble(LoanAmountFM);
                            balance -= principal;
                            FlatPercentageItems.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(interesetii + amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interesetii, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal;
                            i++;
                            SumI += Math.Round(interesetii, 2, MidpointRounding.AwayFromZero);
                            SumP += Math.Round(interesetii + amount, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            rate = Convert.ToDouble(MonthlyInterestF) / 100;

                            DateTime dateTime = ReleaseDateFlat.AddMonths(i - 1);
                            principal = Convert.ToDouble(LoanAmountFM) / CountMonthsForFlatStartEnd();
                            balance -= principal;
                            FlatPercentageItems.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round((Convert.ToDouble(FlatMonthly()) - principal), 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal;
                            SumP += Math.Round(Convert.ToDouble(FlatMonthly()), 2, MidpointRounding.AwayFromZero);
                            SumI += Math.Round((Convert.ToDouble(FlatMonthly()) - principal), 2, MidpointRounding.AwayFromZero);
                        }
                    }
                    if (Convert.ToDouble(MonthlyPaymentFlat) > Convert.ToDouble(FlatMonthly()))
                    {
                        FlatPercentageItems.Clear();
                        FlatPercentageItemsSum.Clear();
                        _ex = "სწორად შეავსეთ ველები";
                    }
                }
                FlatPercentageItemsSum.Add(new GridItem()
                {
                    InterestSum = Math.Round(SumI, 2, MidpointRounding.AwayFromZero).ToString(),
                    PeymentSum = Math.Round(SumP, 2, MidpointRounding.AwayFromZero).ToString(),
                    sumSum = Math.Round(SumP / SumI, 2, MidpointRounding.AwayFromZero).ToString()
                });
           

                    if (App.Toggle22 == true)
                    {
                        if (Convert.ToDouble(MonthlyPaymentFlat) > Convert.ToDouble(FlatMonthly()))
                        {
                            FlatPercentageItems.Clear();
                            FlatPercentageItemsSum.Clear();
                        }
                    }

                
            }
            catch (Exception)
            {
                _ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            OnPropertyChanged(new PropertyChangedEventArgs("FlatPercentageItems"));
        }
      
        public void GraphFlatPercentageDaily()
        {
            try
            {
                double sumI = 0;
                double sump = 0;
                FlatDailyItems.Clear();
                double amount = Convert.ToDouble(LoanAmountF);
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
                    if (App.Toggle11 == true)
                    {
                        if (Convert.ToDouble(DailyPaymentFlat) < Convert.ToDouble(FlatDaily()))
                        {
                            double interest0 = Convert.ToDouble(LoanAmountF) * rate / Convert.ToDouble(TermFlatDaily);
                            do
                            {
                                DateTime dateTime1 = StartDateFlat.AddDays(i);
                                double principal1 = Convert.ToDouble(DailyPaymentFlat) - interest0;
                                // double interest1 = Convert.ToDouble(DailyPaymentFlat) - principal1;
                                balance -= principal1;
                                FlatDailyItems.Add(new GridItem()
                                {
                                    PaymentNumber = i.ToString(),
                                    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                    Payment = Math.Round(Convert.ToDouble(DailyPaymentFlat), 2, MidpointRounding.AwayFromZero).ToString(),
                                    Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Interest = Math.Round(interest0, 2, MidpointRounding.AwayFromZero).ToString(),
                                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                                });
                                amount -= principal1;
                                i++;
                                sumI += Math.Round(interest0, 2, MidpointRounding.AwayFromZero);
                                sump += Math.Round(Convert.ToDouble(DailyPaymentFlat), 2, MidpointRounding.AwayFromZero);

                            } while (i < Convert.ToDouble(TermFlatDaily));

                            DateTime dateTime = StartDateFlat.AddDays(i);
                            double principal = amount;
                            // double interest = Convert.ToDouble(DailyPaymentFlat) - principal;
                            balance -= principal;
                            FlatDailyItems.Add(new GridItem()
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Math.Round(amount + interest0, 2, MidpointRounding.AwayFromZero).ToString(),
                                Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                Interest = Math.Round(interest0, 2, MidpointRounding.AwayFromZero).ToString(),
                                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                            });
                            amount -= principal;
                            i++;
                            sumI += Math.Round(interest0, 2, MidpointRounding.AwayFromZero);
                            sump += Math.Round(amount + interest0, 2, MidpointRounding.AwayFromZero);

                        }
                        else
                        {
                            FlatDailyItems.Clear();
                            FlatDailyItemsSum.Clear();
                        }
                    }
                    else
                    {
                        DateTime dateTime = StartDateFlat.AddDays(i);
                        double principal = Convert.ToDouble(LoanAmountF) / Convert.ToDouble(TermFlatDaily);
                        double interest = Convert.ToDouble(DailyPaymentFlat) - principal;
                        balance -= principal;
                        FlatDailyItems.Add(new GridItem()
                        {
                            PaymentNumber = i.ToString(),
                            Date = dateTime.Date.ToString("dd/MM/yyyy"),
                            Payment = Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero).ToString(),
                            Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                            Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                            EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                        });
                        amount -= principal;
                        sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                        sump += Math.Round(Convert.ToDouble(FlatDaily()), 2, MidpointRounding.AwayFromZero);
                    }
                    OnPropertyChanged(new PropertyChangedEventArgs("FlatDailyItems"));
                }
                FlatDailyItemsSum.Add(new GridItem()
                {
                    InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(),
                    PeymentSum = Math.Round(sump, 2, MidpointRounding.AwayFromZero).ToString(),
                    sumSum = Math.Round(sump / sumI, 2, MidpointRounding.AwayFromZero).ToString()
                });
                if (App.Toggle11 == true)
                {
                    if (Convert.ToDouble(DailyPaymentFlat) > Convert.ToDouble(FlatDaily()))
                    {
                        FlatDailyItems.Clear();
                        FlatDailyItemsSum.Clear();
                    }
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
