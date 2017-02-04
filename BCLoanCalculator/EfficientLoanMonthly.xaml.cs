using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Globalization;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.ApplicationModel.DataTransfer;
using System.Reflection;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BCLoanCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EfficientLoanMonthly : Page
    {

        public EfficientLoanMonthly()
        {
            this.InitializeComponent();
            myButton.Content = "გრაფიკის გადათვლა +";
            Grafph.Content = "გრაფიკის გაზიარება";
            Grafph.Visibility = Visibility.Collapsed;

            MyProgRing.Visibility = Visibility.Collapsed;
            DatePicker11.Date = DatePicker0.Date.AddMonths(1);
            DatePicker12.Date = DatePicker0.Date.AddMonths(1);
        }
        int i = 1;

        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyProgRing.Visibility = Visibility.Visible; // Progress ring name is Waiter.
            });
            await Task.Delay(1000);

            var ld = this.DataContext as LoanData;
            ld.GraphMonthly();
            myButton.Content = "გრაფიკის გადათვლა -";
            i++;
            Grafph.Visibility = Visibility.Visible;

            if (i % 2 == 1)
            {
                Grafph.Visibility = Visibility.Collapsed;

                myButton.Content = "გრაფიკის გადათვლა +";
                ld.ItemsMonthly.Clear();
                ld.ItemsMonthlySum.Clear();
            }
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyProgRing.Visibility = Visibility.Collapsed;
            });

        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    if (e.Parameter is string)
        //    {
        //        LoanAmountTB.Text = e.Parameter.ToString();
        //    }
        //    else
        //    {
        //        LoanAmountTB.Text = "Hi ";
        //    }
        //}
        #region PrivateVariables
        private string _loanAmountValue;
        private DateTime _datePicker1Value;
        private DateTime _datePicker2Value;
        private string _termsOfLoan;
        private string _monthlyInterestVlaue;
        private string _annualInterestValue;
        private string _paymentValue;
        #endregion

        public string LoanAmountVlaue
        {
            get { return _loanAmountValue; }
            set { _loanAmountValue = LoanAmountTB.Text; }
        }

        public DateTime DatePicker1Value
        {
            get { return _datePicker1Value; }
            set { _datePicker1Value = DatePicker11.Date.DateTime; }
        }

        public DateTime DatePicker2Value
        {
            get { return _datePicker2Value; }
            set { _datePicker2Value = DatePicker12.Date.DateTime; }
        }

        public string TermsOfLoan
        {
            get { return _termsOfLoan; }
            set { _termsOfLoan = TermsOfLoanTB.Text; }
        }

        public string MonthlyInterestValue
        {
            get { return _monthlyInterestVlaue; }
            set { _monthlyInterestVlaue = DailyPercentTB.Text; }
        }

        public string AnnualInterestVlaue
        {
            get { return _annualInterestValue; }
            set { _annualInterestValue = AnnualPercentTB.Text; }
        }

        public string PaymentValue
        {
            get { return _paymentValue; }
            set { _paymentValue = PMTTB.Text; }
        }

        private void TermsOfLoanTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.TermELM = TermsOfLoanTB.Text;

                //if (Convert.ToInt32(TermsOfLoanTB.Text)>0)
                //{
                DatePicker12.Date = DatePicker0.Date.AddMonths(Convert.ToInt32(TermsOfLoanTB.Text));
                //}
                Convert.ToDouble(TermsOfLoanTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "ჩაწერეთ მხოლოდ მთელი რიცხვი";
            }
        }
        private void LoanAmountTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.LoanAmountELM = LoanAmountTB.Text;
                Convert.ToDouble(LoanAmountTB.Text);
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3.14)";

            }
        }

        private void DatePicker0_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.ReleaseDateELM = DatePicker0.Date.Date;
            }
            catch (Exception)
            {

            }
        }

        private void DatePicker11_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.StartDateELM = DatePicker11.Date.Date;
            }
            catch (Exception)
            { }
        }

        private void DatePicker12_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.EndDateELM = DatePicker12.Date.Date;
            }
            catch (Exception)
            {

            }
        }

        private void DailyPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.MonthlyInterestELM = DailyPercentTB.Text;
                Convert.ToDouble(DailyPercentTB.Text);
                ErrorTB.Text = String.Empty;
                //  EffectiveTB.Text = (Math.Pow((1 + Convert.ToDouble(AnnualPercentTB) / 365), 365) - 1).ToString();
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3.14)";
            }
        }

        private void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.AnnualInterestELM = AnnualPercentTB.Text;
                //EffectiveTB.Text = (Math.Pow((1 + Convert.ToDouble(AnnualPercentTB) / 365), 365) - 1).ToString();
                Convert.ToDouble(AnnualPercentTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3.14)";
            }
        }

        private void PMTTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.PeymentELM = PMTTB.Text;
                Convert.ToDouble(PMTTB.Text);
                DatePicker12.Date = DatePicker0.Date.AddMonths(Convert.ToInt32(TermsOfLoanTB.Text));
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3.14)";
            }
        }

        private void InterestOnly_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.InterestOnlyELM = InterestOnly.Text;
                Convert.ToDouble(InterestOnly.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3.14)";
            }
        }


        private void Grafph_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager d = DataTransferManager.GetForCurrentView();
            d.DataRequested += D_DataRequested;
            DataTransferManager.ShowShareUI();
        }
        private void D_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string html = @"<table>";



            DataRequest req = args.Request;
            var data = (this.DataContext as LoanData).ItemsMonthly;

            var type = data.FirstOrDefault().GetType();

            var first = true;

            foreach (var d in data)
            {
                if (first)
                {
                    html += "<tr>";

                    foreach (var prop in type.GetProperties())
                    {
                        html += $"<th>{ prop.GetValue(d) }</th>";
                    }

                    html += "</tr>";

                    first = false;
                }
                else
                {

                    html += "<tr>";

                    foreach (var prop in type.GetProperties())
                    {
                        if (true)
                        {

                        }

                        html += $"<th>{ prop.GetValue(d) }</th>";
                    }

                    html += "</tr>";
                }
            }


            html += "</table>";

            var datadef = req.GetDeferral();

            req.Data.SetHtmlFormat(HtmlFormatHelper.CreateHtmlFormat(html));
            req.Data.Properties.Title = "გრაფიკი";
            datadef.Complete();
        }

        private void CheckB_Unchecked(object sender, RoutedEventArgs e)
        {
            App.Toggle2 = false;
        }
        private void CheckB_Checked(object sender, RoutedEventArgs e)
        {
            App.Toggle2 = true;
        }

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{

        //}
        //private void EffectiveTB_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //  //  EffectiveTB.Text= (Math.Pow((1 + Convert.ToDouble(AnnualPercentTB) / 365), 365) - 1).ToString();
        //}
    }
}
