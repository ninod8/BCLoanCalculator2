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
            try
            {
                if (!string.IsNullOrWhiteSpace(DailyPercentTB.Text))
                {
                    Data.DailyInterest = Convert.ToDouble(DailyPercentTB.Text);
                    AnnualPercentTB.Text = Data.AnnualInterest.ToString();
                }
                else
                    DailyPercentTB.Text = string.Empty;
            }
            catch (FormatException) { ErorrTB.Text = "*აკრიფეთ მხოლოდ ციფრები"; }


        }

        public void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(AnnualPercentTB.Text))
                {
                    Data.AnnualInterest = Convert.ToDouble(AnnualPercentTB.Text);
                    DailyPercentTB.Text = Data.DailyInterest.ToString();
                }
                else
                    AnnualPercentTB.Text = string.Empty;
            }
            catch (FormatException) { ErorrTB.Text = "*აკრიფეთ მხოლოდ ციფრები"; }


        }

        public void LoanAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(LoanAmountTB.Text))
                {
                    Data.LoanAmount = Convert.ToDouble(LoanAmountTB.Text);
                }
                else
                    LoanAmountTB.Text = string.Empty;
            }
            catch (FormatException) { ErorrTB.Text = "*აკრიფეთ მხოლოდ ციფრები"; }


        }

        public void DatePicker1_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            Data.StartDate = DatePicker1.Date.Date;
            TermsOfLoanTB.Text = Data.EndDate.ToString();
        }

        public void DatePicker2_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            Data.EndDate = DatePicker2.Date.Date;
            TermsOfLoanTB.Text = Data.StartDate.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TermsOfLoanTB.Text))
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(PMTTB.Text))
                    {

                        TermsOfLoanTB.Text = Data.Nper().ToString();
                    }
                    else
                        TermsOfLoanTB.Text = string.Empty;
                }
                catch (FormatException) { ErorrTB.Text = "*აკრიფეთ მხოლოდ ციფრები"; }
            }
            else
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(TermsOfLoanTB.Text))
                    {

                        PMTTB.Text = Data.PMT().ToString();
                    }
                    else
                        PMTTB.Text = string.Empty;
                }
                catch (FormatException) { ErorrTB.Text = "*აკრიფეთ მხოლოდ ციფრები"; }
            }
        }

        private void TermsOfLoan_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Data.Term = Convert.ToDouble(TermsOfLoanTB.Text);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void PMTTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Data.DailyPayment = Convert.ToDouble(PMTTB.Text);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
