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
using System.Threading.Tasks;
using Windows.UI.Core;

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
            myButton.Content = "გარფიკის გადათვლა +";
            MyProgRing.Visibility = Visibility.Collapsed;

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
                Convert.ToDouble(TermsOfLoanTB.Text);
                DatePicker2.Date = DatePicker0.Date.AddMonths(Convert.ToInt32(TermsOfLoanTB.Text));
                ErrorTB.Text = String.Empty; 

            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";
            }
        }

        private void LoanAmountTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.LoanAmountFM = LoanAmountTB.Text;
                Convert.ToDouble(LoanAmountTB.Text); ErrorTB.Text = String.Empty;


            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";

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
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";



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
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";

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
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";
            }

        }

        private void DailyPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.MonthlyInterestFM = DailyPercentTB.Text;
                Convert.ToDouble(DailyPercentTB.Text);
                ErrorTB.Text = String.Empty;

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
                App.AnnualInterestFM = AnnualPercentTB.Text;
                Convert.ToDouble(AnnualPercentTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";

            }
        }

        private void PMTTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.PeymentFM = PMTTB.Text; Convert.ToDouble(PMTTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";

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

            myButton.Content = "გრაფიკის გადათვლა -";
            var ld = this.DataContext as LoanData;
            ld.GraphFlatPercentageMonthly();
            i++;
            if (i % 2 == 1)
            {
                myButton.Content = "გარფიკის გადათვლა +";
                ld.FlatPercentageItemsSum.Clear();
                ld.FlatPercentageItems.Clear();
            }
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyProgRing.Visibility = Visibility.Collapsed;
            });

        }

        private void ToggleSwitch22_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ToggleSwitch22.IsOn)
                {
                    App.Toggle22 = true;
                }
                else { App.Toggle22 = false; }
            }
            catch (Exception)
            {

            }
        }
    }

}
