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
            if (i % 2 == 1)
            {
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

        private void TermsOfLoanTB_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            try
            {
                App.TermELM = TermsOfLoanTB.Text;
                DatePicker12.Date = DatePicker11.Date.AddMonths(Convert.ToInt32(TermsOfLoanTB.Text));
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
                App.LoanAmountELM = LoanAmountTB.Text;
            }
            catch (Exception)
            {
                
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
            }
            catch (Exception)
            {

            }
        }

        private void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.AnnualInterestELM = AnnualPercentTB.Text;
            }
            catch (Exception)
            {

            }
        }

        private void PMTTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.PeymentELM = PMTTB.Text;

            }
            catch (Exception)
            {

            }
        }

        private void InterestOnly_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.InterestOnlyELM = InterestOnly.Text;

            }
            catch (Exception)
            {

            }
        }
    }
}
