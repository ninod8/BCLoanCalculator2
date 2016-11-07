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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BCLoanCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        LoanData Data = new LoanData();
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(EfficientLoan));
            PMTListBoxItem.IsSelected = true;
            TitleTextBlock.Text = "ყოველდღიური გადახდა";
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PMTListBoxItem.IsSelected)
            {

                MyFrame.Navigate(typeof(EfficientLoan));
                TitleTextBlock.Text = "ყოველდღიური გადახდა";
            }
            if (PMTMonthlyListBoxItem.IsSelected)
            {
                MyFrame.Navigate(typeof(EfficientLoanMonthly));
                TitleTextBlock.Text = "ყოველთვიური გადახდა";
            }
            if (FlatPercentageListBoxItem.IsSelected)
            {
                MyFrame.Navigate(typeof(FlatPercentage));
                TitleTextBlock.Text = "ყოველთვიური ბრტყელი პროცნეტი";
            }
            if (FlatDailyListBoxItem.IsSelected)
            {
                MyFrame.Navigate(typeof(FlatDaily));
                TitleTextBlock.Text = "ყოველდღიური ბრტყელი პროცნეტი";
            }

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (PMTListBoxItem.IsSelected)
            {
                EfficientLoan el = new EfficientLoan();
                MyFrame.Navigate(typeof(EfficientLoan), el);
                el.LoanAmountValue = String.Empty;
                el.DatePickerValue = DateTime.Now;
                el.DateTimePicker2Value = DateTime.Now;
                el.TermValue = String.Empty;
                el.DailyInterestValue = String.Empty;
                el.AnnualInterest = String.Empty;
                el.PMTValue = String.Empty;
            }
            if (PMTMonthlyListBoxItem.IsSelected)
            {
                EfficientLoanMonthly elm = new EfficientLoanMonthly();
                MyFrame.Navigate(typeof(EfficientLoanMonthly), elm);
                elm.LoanAmountVlaue = String.Empty;
                elm.DatePicker1Value = DateTime.Today.Date;
                elm.DatePicker2Value = DateTime.Today.Date;
                elm.TermsOfLoan = String.Empty;
                elm.MonthlyInterestValue = String.Empty;
                elm.AnnualInterestVlaue = String.Empty;
                elm.PaymentValue = String.Empty;
            }
            if (FlatDailyListBoxItem.IsSelected)
            {
                FlatDaily fd = new FlatDaily();
                MyFrame.Navigate(typeof(FlatDaily), fd);
                fd.LoanAmountValue = String.Empty;
                fd.Datepicker1Value = DateTime.Today.Date;
                fd.DatePicker2Value = DateTime.Today.Date;
                fd.TermsOfLoan = String.Empty;
                fd.DailyInterestValue = String.Empty;
                fd.AnnualInterestValue = String.Empty;
                fd.PaymentValue = String.Empty;
            }
            if (FlatPercentageListBoxItem.IsSelected)
            {
                FlatDaily fm = new FlatDaily();
                MyFrame.Navigate(typeof(FlatDaily), fm);
                fm.LoanAmountValue = String.Empty;
                fm.Datepicker1Value = DateTime.Today.Date;
                fm.DatePicker2Value = DateTime.Today.Date;
                fm.TermsOfLoan = String.Empty;
                fm.DailyInterestValue = String.Empty;
                fm.AnnualInterestValue = String.Empty;
                fm.PaymentValue = String.Empty;
            }
        }
    }
}
