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
using System.Threading;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BCLoanCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public Dictionary<Type, Frame> FramesHistory { get; set; }

        //LoanData Data = new LoanData();
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    LoanData s = (LoanData)e.Parameter;
        //}
        //private static void SaveFrameNavigationState(Frame frame)
        //{
        //    var frameState = SessionStateForFrame(frame);
        //    frameState["Navigation"] = frame.GetNavigationState();
        //}

        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(EfficientLoan));
            PMTListBoxItem.IsSelected = true;
            // TitleTextBlock.Text = "ყოველდღიური გადახდა";
        }

        //private void MyFrame_Navigated(object sender, NavigationEventArgs e)
        //{
        //    var frame = sender as Frame;
        //    frame.Content = FramesHistory[frame.CurrentSourcePageType];

        //    if (FramesHistory.ContainsKey(frame.CurrentSourcePageType))
        //        FramesHistory.Remove(frame.CurrentSourcePageType);

        //    FramesHistory.Add(frame.CurrentSourcePageType, frame);
        //}

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
            if (PMTListBoxItem.IsSelected || MyFrame.Navigate(typeof(EfficientLoan)) == true)
            {
                try
                {                    
                    App.LoanAmountEL = String.Empty;
                    App.DailyInterestEL = String.Empty;
                    App.InterestOnlyEL = String.Empty;
                    App.AnnualInterestEL = String.Empty;
                    App.TermEL = String.Empty;
                    App.PeymentEL = String.Empty;
                    App.StartDateEL = DateTime.Today.Date;
                    App.EndDateEL = DateTime.Today.Date;
                    EfficientLoan el = new EfficientLoan();
                    MyFrame.Navigate(typeof(EfficientLoan), el);
                    el.LoanAmountValue = String.Empty;
                    el.DatePickerValue = DateTime.Now;
                    el.DateTimePicker2Value = DateTime.Now;
                    el.TermValue = String.Empty;
                    el.DailyInterestValue = String.Empty;
                    el.AnnualInterest = String.Empty;
                    el.PMTValue = String.Empty;
                    MyFrame.Navigate(typeof(EfficientLoan));
                }
                catch (Exception)
                {
                }
            }
            if (PMTMonthlyListBoxItem.IsSelected)
            {
                try
                {
                    App.LoanAmountELM = String.Empty;
                    App.MonthlyInterestELM = String.Empty;
                    App.InterestOnlyELM = String.Empty;
                    App.AnnualInterestELM = String.Empty;
                    App.TermELM = String.Empty;
                    App.PeymentELM = String.Empty;
                    App.StartDateELM = DateTime.Today.Date.AddMonths(1);
                    App.EndDateELM = DateTime.Today.Date.AddMonths(1);
                    App.ReleaseDateELM = DateTime.Today.Date;
                    EfficientLoanMonthly elm = new EfficientLoanMonthly();
                    MyFrame.Navigate(typeof(EfficientLoanMonthly), elm);
                    elm.LoanAmountVlaue = String.Empty;
                    elm.DatePicker1Value = DateTime.Today.Date;
                    elm.DatePicker2Value = DateTime.Today.Date;
                    elm.TermsOfLoan = String.Empty;
                    elm.MonthlyInterestValue = String.Empty;
                    elm.AnnualInterestVlaue = String.Empty;
                    elm.PaymentValue = String.Empty;
                    MyFrame.Navigate(typeof(EfficientLoanMonthly));
                }
                catch (Exception)
                {
                }

            }
            if (FlatDailyListBoxItem.IsSelected)
            {
                try
                {
                    App.DailyInterestF = String.Empty;
                    App.LoanAmountF = String.Empty;
                    App.AnnualInterestF = String.Empty;
                    App.StartDateF = DateTime.Today.Date;
                    App.TermF = String.Empty;
                    App.EndDateF = DateTime.Today.Date;
                    App.PeymentF = String.Empty;
                    FlatDaily fd = new FlatDaily();
                    MyFrame.Navigate(typeof(FlatDaily), fd);
                    fd.LoanAmountValue = String.Empty;
                    fd.Datepicker1Value = DateTime.Today.Date;
                    fd.DatePicker2Value = DateTime.Today.Date;
                    fd.TermsOfLoan = String.Empty;
                    fd.DailyInterestValue = String.Empty;
                    fd.AnnualInterestValue = String.Empty;
                    fd.PaymentValue = String.Empty;
                    MyFrame.Navigate(typeof(FlatDaily));
                }
                catch (Exception)
                {

                }

            }
            if (FlatPercentageListBoxItem.IsSelected)
            {
                try
                {         
                    App.LoanAmountFM = String.Empty;
                    App.EndDateFM = DateTime.Today.Date.AddMonths(1);
                    App.ReleaseDateFM = DateTime.Today.Date;
                    App.MonthlyInterestFM = String.Empty;
                    App.AnnualInterestFM = String.Empty;
                    App.TermFM = String.Empty;
                    App.PeymentFM = String.Empty;
                    App.StartDateFM = DateTime.Today.Date.AddMonths(1);
                    FlatDaily fm = new FlatDaily();
                    MyFrame.Navigate(typeof(FlatDaily), fm);
                    fm.LoanAmountValue = String.Empty;
                    fm.Datepicker1Value = DateTime.Today.Date;
                    fm.DatePicker2Value = DateTime.Today.Date;
                    fm.TermsOfLoan = String.Empty;
                    fm.DailyInterestValue = String.Empty;
                    fm.AnnualInterestValue = String.Empty;
                    fm.PaymentValue = String.Empty;
                    MyFrame.Navigate(typeof(FlatPercentage));
                }
                catch (Exception)
                {

                }

            }
        }

        private void ListBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (MySplitView.IsPaneOpen)
            {
                MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            }
        }
    }
}
