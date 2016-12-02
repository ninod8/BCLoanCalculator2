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
using System.Windows;
using Windows.Storage;
using MyToolkit.Resources;
using Microsoft.VisualBasic;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BCLoanCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlatPercentage : Page
    {
        public FlatPercentage()
        {
            this.InitializeComponent();
            myButton.Content = "გარფიკი +";
        }

        #region PrivateVariables
        private string _loanAmountValue;
        private DateTime _datePicker1Value;
        private DateTime _datePicker2Value;
        private string _termsOfLoanValue;
        private string _monthlyInterestValue;
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

        public string MonthlyInterestValue
        {
            get { return _monthlyInterestValue; }
            set { _monthlyInterestValue = DailyPercentTB.Text; }
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

        private void TermsOfLoanTB_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            try
            {
                App.TermFM = TermsOfLoanTB.Text;
               // DatePicker1.Date = DatePicker0.Date.AddMonths(Convert.ToInt32(TermsOfLoanTB.Text));
                DatePicker2.Date = DatePicker1.Date.AddMonths(Convert.ToInt32(TermsOfLoanTB.Text));
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "შეიყვანეთ მხოლოდ ციფრები";
            }
        }

        private void LoanAmountTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.LoanAmountFM = LoanAmountTB.Text;

            }
            catch (Exception)
            {

            }
        }

        private void DatePicker0_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.ReleaseDateFM = DatePicker0.Date.Date;

            }
            catch (Exception)
            {

            }
        }

        private void DatePicker1_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.StartDateFM = DatePicker1.Date.Date;

            }
            catch (Exception)
            {

            }
        }

        private void DatePicker2_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.EndDateFM = DatePicker2.Date.Date;

            }
            catch (Exception)
            {

            }
        }

        private void DailyPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.MonthlyInterestFM = DailyPercentTB.Text;

            }
            catch (Exception)
            {

            }
        }

        private void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.AnnualInterestFM = AnnualPercentTB.Text;
            }
            catch (Exception)
            {

            }
        }

        private void PMTTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.PeymentFM = PMTTB.Text;
            }
            catch (Exception)
            {

            }
        }
        int i = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "გრაფიკი -";
            var ld = this.DataContext as LoanData;
            ld.GraphFlatPercentageMonthly();
            ld.FlatMonthlySum();
            i++;
            if (i % 2 == 1)
            {
                myButton.Content = "გარფიკი +";
                ld.FlatPercentageItemsSum.Clear();
                ld.FlatPercentageItems.Clear();
            }
        }
    }

}
