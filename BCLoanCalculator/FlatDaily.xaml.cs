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
    public sealed partial class FlatDaily : Page
    {
        public FlatDaily()
        {
            this.InitializeComponent();
            myButton.Content = "გრაფიკის გადათვლა +";
            Grafph.Content = "გრაფიკის გაზიარება";

            MyProgRing.Visibility = Visibility.Collapsed;
            Grafph.Visibility = Visibility.Collapsed;

        }

        private void TermsOfLoanTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.TermF = TermsOfLoanTB.Text;
                DatePicker2.Date = DatePicker1.Date.AddDays(Convert.ToInt32(TermsOfLoanTB.Text));
                Convert.ToInt32(Convert.ToInt32(TermsOfLoanTB.Text));
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "ჩაწერეთ მხოლოდ მთელი რიცხვი";
            }
        }
        #region PrivateVariables
        private string _loanAmountValue;
        private DateTime _datePicker1Value;
        private DateTime _datePicker2Value;
        private string _termsOfLoanValue;
        private string _dailyInterestValue;
        private string _annualInterestValue;
        private string _paymentValue;
        #endregion

        public string LoanAmountValue
        {
            get { return _loanAmountValue; }
            set { _loanAmountValue = LoanAmountTB.Text; }
        }

        public DateTime Datepicker1Value
        {
            get { return _datePicker1Value; }
            set { _datePicker1Value = DatePicker1.Date.DateTime; }
        }

        public DateTime DatePicker2Value
        {
            get { return _datePicker2Value; }
            set { _datePicker2Value = DatePicker2.Date.DateTime; }
        }

        public string TermsOfLoan
        {
            get { return _termsOfLoanValue; }
            set { _termsOfLoanValue = TermsOfLoanTB.Text; }
        }

        public string DailyInterestValue
        {
            get { return _dailyInterestValue; }
            set { _dailyInterestValue = DailyPercentTB.Text; }
        }

        public string AnnualInterestValue
        {
            get { return _annualInterestValue; }
            set { _annualInterestValue = AnnualPercentTB.Text; }
        }

        public string PaymentValue
        {
            get { return _paymentValue; }
            set { _paymentValue = PMTTB.Text; }
        }

        private void LoanAmountTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.LoanAmountF = LoanAmountTB.Text;
                Convert.ToDouble(LoanAmountTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3.14)";

            }
        }

        private void DatePicker1_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.StartDateF = DatePicker1.Date.Date;

            }
            catch (Exception)
            {

            }
        }

        private void DatePicker2_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.EndDateF = DatePicker2.Date.Date;

            }
            catch (Exception)
            {

            }
        }

        private void DailyPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.DailyInterestF = DailyPercentTB.Text;

            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";

            }
        }

        private void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.AnnualInterestF = AnnualPercentTB.Text;
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
                App.PeymentF = PMTTB.Text;
                Convert.ToDouble(PMTTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3.14)";
            }
        }
        int i = 1;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyProgRing.Visibility = Visibility.Visible; // Progress ring name is Waiter.
            });
            await Task.Delay(1000);

            var ld = this.DataContext as LoanData;
            ld.GraphFlatPercentageDaily();
           // ld.FlatSum();
            myButton.Content = "გრაფიკის გადათვლა -";
            i++;
            Grafph.Visibility = Visibility.Visible;

            if (i % 2 == 1)
            {
                Grafph.Visibility = Visibility.Collapsed;
                ld.FlatDailyItems.Clear();
                ld.FlatDailyItemsSum.Clear();
                myButton.Content = "გრაფიკის გადათვლა +";
            }
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyProgRing.Visibility = Visibility.Collapsed;
            });

        }

        private void ToggleSwitch11_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ToggleSwitch11.IsOn)
                {
                    App.Toggle11 = true;
                }
                else { App.Toggle11 = false; }
            }
            catch (Exception)
            {

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
            var data = (this.DataContext as LoanData).FlatDailyItems;

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

    }
}
