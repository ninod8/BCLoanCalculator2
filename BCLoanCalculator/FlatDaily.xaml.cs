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
        }

        private void TermsOfLoanTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                App.TermF = TermsOfLoanTB.Text;
                DatePicker2.Date = DatePicker1.Date.AddDays(Convert.ToInt32(TermsOfLoanTB.Text));
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "შეიყვანეთ მხოლოდ ციფრები";
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
            }
            catch (Exception)
            {

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

            }
        }

        private void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.AnnualInterestF = AnnualPercentTB.Text;
            }
            catch (Exception)
            {

            }
        }

        private void PMTTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.PeymentF = PMTTB.Text;
            }
            catch (Exception)
            {
            }
        }
        int i = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ld = this.DataContext as LoanData;
            ld.GraphFlatPercentageDaily();
            ld.FlatSum();
            myButton.Content = "გრაფიკის გადათვლა -";
            i++;
            if (i % 2 == 1)
            {
                ld.FlatDailyItems.Clear();
                ld.FlatDailyItemsSum.Clear();
                myButton.Content = "გრაფიკის გადათვლა +";
            }
        }
    }
}
