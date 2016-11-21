using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
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
using System.Collections.ObjectModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BCLoanCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EfficientLoan : Page
    {
        //private string _tBValue;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoanData data = e.Parameter as LoanData;
           // LoanData s = new LoanData() { LoanAmount = Convert.ToDouble(LoanAmountTB.Text)};
            //this.Frame.Navigate(typeof(MainPage), s);
           // LoanAmountTB.Text = data.LoanAmount.ToString();
        }
        

        public EfficientLoan()
        {
            this.InitializeComponent();
        }        
        private string _loanAmountValue;

        public string LoanAmountValue
        {
            get { return _loanAmountValue; }
            set { _loanAmountValue = LoanAmountTB.Text; }
        }
        private DateTime _datePickerValue;

        public DateTime DatePickerValue
        {
            get { return _datePickerValue; }
            set { _datePickerValue = DatePicker1.Date.DateTime; }
        }
        private DateTime _dateTimePicker2Value;

        public DateTime DateTimePicker2Value
        {
            get { return _dateTimePicker2Value; }
            set { _dateTimePicker2Value = DatePicker2.Date.DateTime; }
        }
        private string _termValue;

        public string TermValue
        {
            get { return _termValue; }
            set { _termValue = TermsOfLoanTB.Text; }
        }
        private string _dailyInterestValue;

        public string DailyInterestValue
        {
            get { return _dailyInterestValue; }
            set { _dailyInterestValue = DailyPercentTB.Text; }
        }
        private string _annualInterestValue;

        public string AnnualInterest
        {
            get { return _annualInterestValue; }
            set { _annualInterestValue = AnnualPercentTB.Text; }
        }
        private string _pMTValue;

        public string PMTValue
        {
            get { return _pMTValue; }
            set { _pMTValue = value; }
        }

        private void TermsOfLoanTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DatePicker2.Date = DatePicker1.Date.AddDays(Convert.ToDouble(TermsOfLoanTB.Text));
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "შეიყვანეთ მხოლოდ ციფრები";
            }            
        }
        //LoanData eflo = new LoanData();
        
        public void Graph_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
