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
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            LoanData Data = new LoanData();
            
            Data.GraphMonthly();
        }

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

        private void TermsOfLoanTB_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            int i = Convert.ToInt32(TermsOfLoanTB.Text);
            try
            {
                DatePicker12.Date = DatePicker11.Date.AddMonths(i-1);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "შეიყვანეთ მხოლოდ ციფრები";
                throw;
            }
        }
    }
}
