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
            //EfficientLoan ef = new EfficientLoan();
            //_loanAmount = Convert.ToDouble(ef.LoanAmountValue);
            _startDateDaily = DateTime.Today.Date;
            _endDateDaily = DateTime.Today.Date;
            _endDateMonthly = DateTime.Today.Date;
            _startDateMonthly = DateTime.Today.Date;
            _endDateFlat = DateTime.Today.Date.AddMonths(1);
            _startDateFlat = DateTime.Today.Date.AddMonths(1);
            _startDateFlatDaily = DateTime.Today.Date;
            _endDateFlatDaily = DateTime.Today.Date;
            _releaseDate = DateTime.Today.Date;
            _releaseDateFlat = DateTime.Today.Date;
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
        private string _interestOnly;
        private string _dailyInterest;
        private string _annualInterest;
        private string _loanAmount;
        private DateTime _startDateDaily;
        private DateTime _endDateDaily;
        private string _termDaily;
        private string _dailyPayment;
        private DateTime _releaseDate;
        private DateTime _startDateMonthly;
        private DateTime _endDateMonthly;
        private string _termMonthly;
        private string _monthlyPayment;
        private DateTime _endDateFlat;
        private DateTime _startDateFlat;
        private DateTime _releaseDateFlat;
        private string _termFlat;
        private string _monthlyPaymentFlat;
        private string _dailyPaymentFlat;
        private DateTime _endDateFlatDaily;
        private DateTime _startDateFlatDaily;
        private string _termFlatDaily;
        private string _annualInterestForMonthly;
        private string _monthlyInterest;

        #endregion

        public string MonthlyInterest
        {
            get { return _monthlyInterest; }
            set
            {
                _monthlyInterest = value;
                _annualInterestForMonthly = Math.Round(Convert.ToDouble(value) * 12, 3, MidpointRounding.AwayFromZero).ToString();
                _dailyInterest = (Convert.ToDouble(_annualInterestForMonthly) / 365).ToString();
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterest"));
            }
        }

        public string AnnualInterestForMonthly
        {
            get { return _annualInterestForMonthly; }
            set
            {
                _annualInterestForMonthly = value;
                _monthlyInterest = Math.Round(Convert.ToDouble(value) / 12, 3, MidpointRounding.AwayFromZero).ToString();
                _dailyInterest = (Convert.ToDouble(_annualInterestForMonthly) / 365).ToString();

                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterestForMonthly"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyInterest"));
            }
        }

        public string DailyInterest
        {
            get { return _dailyInterest; }
            set
            {
                _dailyInterest = value;
                _annualInterest = Math.Round(Convert.ToDouble(value) * 365, 3, MidpointRounding.AwayFromZero).ToString();

                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterest"));
                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterest"));
            }
        }

        public string AnnualInterest
        {
            get { return _annualInterest; }
            set
            {
                _annualInterest = value;
                _dailyInterest = Math.Round(Convert.ToDouble(value) / 365, 3, MidpointRounding.AwayFromZero).ToString();

                OnPropertyChanged(new PropertyChangedEventArgs("DailyInterest"));
                OnPropertyChanged(new PropertyChangedEventArgs("AnnualInterest"));
            }
        }

        public string LoanAmount
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
                TermDaily = CountDays().ToString();

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
                TermDaily = CountDays().ToString();

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
                _startDateMonthly = value;
                TermMonthly = CountMonths().ToString();

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

        public DateTime ReleaseDateFlat //add a method
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
                //DateTime today = DateTime.Now;
                // _endDateDaily = today.AddDays(TermDaily);
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
                _termFlat = value;
                _endDateFlat = StartDateFlat.AddMonths(Convert.ToInt32(TermFlat) - 1);
                _monthlyPaymentFlat = FlatMonthly();
                GraphFlatPercentageMonthly();
                OnPropertyChanged(new PropertyChangedEventArgs("TermFlat"));
                OnPropertyChanged(new PropertyChangedEventArgs("MonthlyPaymentFlat"));
            }
        }

        public string TermFlatDaily
        {
            get { return _termFlatDaily; }
            set
            {
                _termFlatDaily = value;
                _dailyPaymentFlat = FlatDaily();
                _endDateFlatDaily = _startDateFlatDaily.AddDays(Convert.ToInt32(TermFlatDaily));
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
                _termDaily = NperDaily();
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
                _termMonthly = NperMonthly();
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
                //_termFlat = NperMonthlyFlat();
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
                _termFlatDaily = NperDailyFlat();
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
            double rate = Convert.ToDouble(DailyInterest) / 100;
            double pmt = Convert.ToDouble(LoanAmount) * Convert.ToDouble(rate) / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermDaily) - Convert.ToDouble(InterestOnly)))));
            return pmt.ToString();
        }

        public string PMTMonthly()
        {
            double rate = Convert.ToDouble(DailyInterest) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
            if (rate == 0)
            {
                rate = Convert.ToDouble(DailyInterest) * Convert.ToDouble(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
            }
            double pmt = Convert.ToDouble(LoanAmount) * rate / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermMonthly) - Convert.ToDouble(InterestOnly)))));
            return pmt.ToString();
        }

        public string FlatMonthly()
        {
            double flatPayment;
            double rate = ((Convert.ToDouble(AnnualInterestForMonthly) / 365) * (CountDaysForFlat()) / 100);
            if (rate == 0)
            {
                rate = (Convert.ToDouble(AnnualInterestForMonthly) / 365) * Convert.ToDouble(TermFlat) * 30 / 100;
            }
            if (CounterForFlat() > 31)
            {
                flatPayment = (Convert.ToDouble(LoanAmount) + (rate * Convert.ToDouble(LoanAmount))) / (Convert.ToDouble(TermFlat) + 1);
            }
            flatPayment = (Convert.ToDouble(LoanAmount) + (rate * Convert.ToDouble(LoanAmount))) / Convert.ToDouble(TermFlat);
            return Math.Round(flatPayment, 2, MidpointRounding.AwayFromZero).ToString();
        }

        public string FlatDaily()
        {
            double rate = Convert.ToDouble(DailyInterest) * CountDaysForFlatDaily() / 100;
            double flatPayment = (Convert.ToDouble(LoanAmount) + (rate * Convert.ToDouble(LoanAmount))) / Convert.ToDouble(TermFlatDaily);
            return flatPayment.ToString();
        }

        public string NperDaily()
        {
            double rate = Convert.ToDouble(DailyInterest) / 100;
            double nper = -Math.Log((1 - rate * Convert.ToDouble(LoanAmount) / Convert.ToDouble(DailyPayment)), Math.E) / Math.Log((1 + rate), Math.E);
            return nper.ToString();
        }

        public string NperMonthly()
        {
            double rate = Convert.ToDouble(DailyInterest) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
            if (rate == 0)
            {
                rate = Convert.ToDouble(DailyInterest) * Convert.ToDouble(TermMonthly) * 30 / (100 * Convert.ToDouble(TermMonthly));
            }
            double nper = -Math.Log((1 - rate * Convert.ToDouble(LoanAmount) / Convert.ToDouble(MonthlyPayment)), Math.E) / Math.Log((1 + rate), Math.E);
            return nper.ToString();
        }

        public string NperMonthlyFlat()
        {
            double rate = Convert.ToDouble(DailyInterest) * CountDaysForFlat() / 100;
            if (rate == 0)
            {
                rate = Convert.ToDouble(DailyInterest) * Convert.ToDouble(TermFlat) * 30 / 100;
            }
            double nper = Convert.ToDouble(LoanAmount) * (rate + 1) / Convert.ToDouble(MonthlyPaymentFlat);
            return nper.ToString();
        }

        public string NperDailyFlat()
        {
            double rate = Convert.ToDouble(DailyInterest) * CountDaysForFlatDaily() / 100;
            double nper = Convert.ToDouble(LoanAmount) * (rate + 1) / Convert.ToDouble(DailyPaymentFlat);
            return nper.ToString();
        }

        public string InterestOnly
        {
            get { return _interestOnly; }
            set
            {
                _interestOnly = value;
            }
        }

        public void SumDaily()
        {
            ItemsSum.Clear();
            double amount = Convert.ToDouble(LoanAmount);
            double balance = Convert.ToDouble(LoanAmount);
            double dailyInterest = Convert.ToDouble(DailyInterest) / 100;
            double sumP = 0;
            double sumI = 0;
            double interest = 0;
            for (int i = 1; i <= Convert.ToDouble(TermDaily); i++)
            {
                if (Convert.ToDouble(InterestOnly) > 0)
                {
                    while (i <= Convert.ToDouble(InterestOnly))
                    {
                        i++;
                        double interest1 = amount * dailyInterest;
                        sumI += interest1;
                        amount = Convert.ToDouble(LoanAmount);
                    }
                }

                interest = amount * dailyInterest;
                double principal = Convert.ToDouble(PMTDaily()) - interest;
                balance -= principal;

                amount -= principal;
                sumI += interest;
                sumP = sumI + Convert.ToDouble(LoanAmount);
                OnPropertyChanged(new PropertyChangedEventArgs("ItemsSum"));
            }
            ItemsSum.Add(new GridItem() { InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(), PeymentSum = Math.Round(sumP, 2, MidpointRounding.AwayFromZero).ToString() });
        }

        public void GraphDaily()
        {
            Items.Clear();
            double amount = Convert.ToDouble(LoanAmount);
            double balance = Convert.ToDouble(LoanAmount);
            double dailyInterest = Convert.ToDouble(DailyInterest) / 100;
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

            for (int i = 1; i <= Convert.ToDouble(TermDaily); i++)
            {
                if (Convert.ToDouble(InterestOnly) > 0)
                {
                    while (i <= Convert.ToDouble(InterestOnly))
                    {
                        i++;
                        DateTime dateTime1 = StartDateDaily.AddDays(i);
                        double interest1 = amount * dailyInterest;
                        double principal1 = 0.00;
                        balance = Convert.ToDouble(LoanAmount);
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
                        amount = Convert.ToDouble(LoanAmount);
                    }
                }

                DateTime dateTime = StartDateDaily.AddDays(i);
                double interest = amount * dailyInterest;
                double principal = Convert.ToDouble(PMTDaily()) - interest;
                balance -= principal;
                Items.Add(new GridItem()
                {
                    PaymentNumber = i.ToString(),
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

        public void SumMonthly()
        {
            ItemsMonthlySum.Clear();
            double amount = Convert.ToDouble(LoanAmount);
            double balance = Convert.ToDouble(LoanAmount);
            double sumP = 0;
            double sumI = 0;
            double monthlyRate = Convert.ToDouble(DailyInterest) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
            if (monthlyRate == 0)
            {
                monthlyRate = Convert.ToDouble(DailyInterest) * Convert.ToInt32(TermFlat) * 30 / (100 * Convert.ToDouble(TermMonthly));
            }
            for (int i = 1; i <= Convert.ToDouble(TermMonthly); i++)
            {
                if (Convert.ToDouble(InterestOnly) > 0)
                {
                    while (i <= Convert.ToDouble(InterestOnly))
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
            sumP = sumI + Convert.ToDouble(LoanAmount);
            ItemsMonthlySum.Add(new GridItem()
            {
                InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(),
                PeymentSum = Math.Round(sumP, 2, MidpointRounding.AwayFromZero).ToString()
            });
        }

        public void GraphMonthly()
        {
            ItemsMonthly.Clear();
            double amount = Convert.ToDouble(LoanAmount);
            double balance = Convert.ToDouble(LoanAmount);
            double monthlyRate = Convert.ToDouble(DailyInterest) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermMonthly));
            if (monthlyRate == 0)
            {
                monthlyRate = Convert.ToDouble(DailyInterest) * Convert.ToInt32(TermFlat) * 30 / (100 * Convert.ToDouble(TermMonthly));
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
                if (Convert.ToDouble(InterestOnly) > 0)
                {
                    while (i <= Convert.ToDouble(InterestOnly))
                    {
                        i++;
                        DateTime dateTime1 = StartDateDaily.AddMonths(i);
                        double interest1 = amount * monthlyRate;
                        double principal1 = 0.00;
                        balance = Convert.ToDouble(LoanAmount);
                        ItemsMonthly.Add(new GridItem()
                        {
                            PaymentNumber = i.ToString(),
                            Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                            Payment = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                            EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                            Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                            Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                            StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                        });
                        amount = Convert.ToDouble(LoanAmount);
                    }
                }
                DateTime dateTime = StartDateMonthly.AddMonths(i);
                double principal = Convert.ToDouble(PMTMonthly()) - amount * monthlyRate;
                double interest = amount * monthlyRate;
                balance -= principal;
                ItemsMonthly.Add(new GridItem()
                {
                    PaymentNumber = i.ToString(),
                    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                    Payment = Math.Round(Convert.ToDouble(MonthlyPayment), 2, MidpointRounding.AwayFromZero).ToString(),
                    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                    Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                    EndingBalance = (Math.Round(balance, 2, MidpointRounding.AwayFromZero)).ToString()
                });
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("ItemsMonthly"));
            }
        }

        public void FlatMonthlySum()
        {
            FlatPercentageItems.Clear();
            double amount = Convert.ToDouble(LoanAmount);
            double balance = Convert.ToDouble(LoanAmount);
            double rate = ((Convert.ToDouble(AnnualInterestForMonthly) / 365) * (CountDaysForFlat()) / 100);
            if (rate == 0)
            {
                rate = Convert.ToDouble(DailyInterest) * Convert.ToDouble(TermFlat) * 30 / 100;
            }
            for (int i = 1; i <= Convert.ToDouble(TermFlat); i++)
            {
                if (CounterForFlat() > 31)
                {
                    while (i < 2)
                    {
                        i++;
                        rate = ((Convert.ToDouble(AnnualInterestForMonthly) / 365) * (CounterForFlat()) / 100);
                        DateTime dateTime1 = StartDateFlat.AddMonths(i);
                        double principal1 = Convert.ToDouble(LoanAmount) / Convert.ToDouble(TermFlat);
                        double interest1 = Convert.ToDouble(LoanAmount) * rate / 100;
                        balance -= principal1;

                        amount -= principal1;
                    }
                }
                DateTime dateTime = StartDateFlat.AddMonths(i);
                double principal = Convert.ToDouble(LoanAmount) / Convert.ToDouble(TermFlat);
                double interest = Convert.ToDouble(LoanAmount) * rate / Convert.ToDouble(TermFlat);
                amount -= principal;
                OnPropertyChanged(new PropertyChangedEventArgs("FlatPercentageItemsSum"));
            }
        }//needs corrections

        public void GraphFlatPercentageMonthly()
        {
            FlatPercentageItems.Clear();
            double amount = Convert.ToDouble(LoanAmount);
            double balance = Convert.ToDouble(LoanAmount);
            double h = CountDaysForFlat();
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

            for (int i = 1; i <= Convert.ToDouble(TermFlat); i++)
            {
                if (CounterForFlat() > 31)
                {
                    while (i < 2)
                    {                
                        rate = ((Convert.ToDouble(AnnualInterestForMonthly) / 365) * CounterForFlat() / 100);
                        DateTime dateTime1 = StartDateFlat.AddMonths(i-1);
                        double principal1 = Convert.ToDouble(LoanAmount) / (Convert.ToDouble(TermFlat)+1);
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
                rate = (Convert.ToDouble(AnnualInterestForMonthly) / 365) * CountDaysForFlat() / 100;
                if (rate == 0)
                {
                    rate = (Convert.ToDouble(AnnualInterestForMonthly) / 365) * Convert.ToDouble(TermFlat) * 30 / 100;
                }
                DateTime dateTime = StartDateFlat.AddMonths(i-1);
                if (CounterForFlat()>31)
                {
                    principal = Convert.ToDouble(LoanAmount) / (Convert.ToDouble(TermFlat)+1);

                }
                else principal = Convert.ToDouble(LoanAmount) / Convert.ToDouble(TermFlat);
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

        public void FlatSum()
        {
            FlatDailyItemsSum.Clear();
            string sumP = Math.Round((Convert.ToDouble(FlatDaily()) * Convert.ToDouble(TermFlatDaily)), 2, MidpointRounding.AwayFromZero).ToString();
            double rate = Convert.ToDouble(DailyInterest) * CountDaysForFlatDaily() / 100;
            string sumI = Math.Round((Convert.ToDouble(DailyPaymentFlat) * rate), 2, MidpointRounding.AwayFromZero).ToString();
            FlatDailyItemsSum.Add(new GridItem()
            {
                InterestSum = sumI,
                PeymentSum = sumP
            });
        }

        public void GraphFlatPercentageDaily()
        {
            FlatDailyItems.Clear();
            double amount = Convert.ToDouble(LoanAmount);
            double sj = CountDaysForFlatDaily();
            double rate = Convert.ToDouble(DailyInterest) * CountDaysForFlatDaily() / 100;
            double balance = Convert.ToDouble(LoanAmount);
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
                double principal = Convert.ToDouble(LoanAmount) / Convert.ToDouble(TermFlatDaily);
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
