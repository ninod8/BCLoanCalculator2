using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.VisualBasic;
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
    public sealed partial class efficientloan : Page
    {
        public LoanData Data { get; set; }

        public efficientloan()
        {
            this.InitializeComponent();
            Data = new LoanData();
        }
        private void DailyPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Data.DailyInterest = Convert.ToDouble(DailyPercentTB.Text);
          
            Data.AnnualInterest = Data.DailyInterest * 365;
            AnnualPercentTB.Text = Data.AnnualInterest.ToString();
        }

        public void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Data.AnnualInterest = Convert.ToDouble(AnnualPercentTB.Text);

            Data.DailyInterest = Data.AnnualInterest / 365;
            DailyPercentTB.Text = Data.DailyInterest.ToString();

        }

        public void LoanAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Data.LoanAmount = Convert.ToDouble(LoanAmount.Text);
        }

        public void DatePicker1_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            Data.StartDate = DatePicker1.Date.Date;
            TermsOfLoanTB.Text = Data.CountDays().ToString();
        }

        public void DatePicker2_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            Data.EndDate = DatePicker2.Date.Date;
            TermsOfLoanTB.Text = Data.CountDays().ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TermsOfLoan_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TermsOfLoanTB.Text))
            {
                Data.Term = Convert.ToDouble(TermsOfLoanTB.Text);
                PMTTB.Text = Data.PMT().ToString();
            }
            else
                PMTTB.Text = string.Empty;
        }

        private void PMTTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PMTTB.Text))
            {
                Data.DailyPayment = Convert.ToDouble(PMTTB.Text);
                TermsOfLoanTB.Text = Data.Nper().ToString();
            }
            else
                TermsOfLoanTB.Text = string.Empty;
        }
    }
}
