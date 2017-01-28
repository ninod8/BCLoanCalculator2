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
using Windows.Globalization;
using Microsoft.VisualBasic;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.Graphics.Printing;
using Windows.UI.Xaml.Printing;
using Windows.Graphics.Printing.OptionDetails;
using System.Xml;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.ApplicationModel.DataTransfer;
using System.Reflection;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BCLoanCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EfficientLoan : Page
    {
        //private string _tBValue;
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    LoanData data = e.Parameter as LoanData;
        //    LoanData s = new LoanData() { LoanAmount = Convert.ToDouble(LoanAmountTB.Text)};
        //    this.Frame.Navigate(typeof(MainPage), s);
        //    LoanAmountTB.Text = data.LoanAmount.ToString();
        //}

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //    string id = e.Parameter.ToString();
        //}
        //void registerForPrinting()
        //{
        //    PrintManager PrintManager = PrintManager.GetForCurrentView();
        //    PrintManager.PrintTaskRequested +=
        //        PrintManager_PrintTaskRequested;

        //    this.Document = new PrintDocument();
        //    this.Document.Paginate += Paginate;
        //    this.Document.GetPreviewPage += GetPreviewPage;

        //}
        //void GetPreviewPage(object sender, GetPreviewPageEventArgs e)
        //{
        //    int zeroBasedPageNumber = e.PageNumber - 1;
        //    this.Document.SetPreviewPage(e.PageNumber, this.Pages[zeroBasedPageNumber].Image as UIElement);
        //}
        //void Paginate(object sender, PaginateEventArgs e)
        //{
        //    this.Document.SetPreviewPageCount(this.Page.Count, PreviewPageCountType.Final);
        //}
        // void PrintManager_PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        //{
        //    PrintTask printTask = args.Request.CreatePrintTask("PrintJobTitle", PrintTaskSourceRequested);
        //    printTask.Completed += PrintTaskCompleted;
        //    configurePrintTaskOptionDetails(printTask);
        //}

        //private void PrintTaskSourceRequested(PrintTaskSourceRequestedArgs args)
        //{
        //    args.SetSource(this.Document.DocumetSource);
        //}
        //void details_OptionChanged(PrintTaskOptionDetails sender, PrintTaskOptionChangedEventArgs args)
        //{
        //    if (args.OptionId != null && args.OptionId.ToString()=="Fit")
        //    {
        //        IPrintCustomOptionDetails fit = sender.Options[args.OptionId.ToString()];
        //        switch(fit.Value.ToString())
        //        {

        //        }
        //    }
        //}
        //async void AddPages(object sender, AddPagesEventArgs e)
        //{
        //    for (int pageNum = 0; pageNum < this.AddPages.Count; pageNum++)
        //    {
        //        var pageDesc = e.PrintTaskOptions.GetPageDescription((uint)pageNum);
        //        var currentPage = this.Pages[pageNum];
        //        this.Document.AddPage(await
        //            currentPage.GetPageInTargetResolutioin(
        //            (pageDesc.ImageableRect.Width * DpiX) / 96), 
        //            (pageDesc.ImageableRect.Height * DpiY) / 96);
        //    }
        //this.Document.AddPagesComplete();
        //}
        //void PrintTaskCompleted(PrintTask sender, PrintTaskCompletedEventArgs args)
        //{
        //    if (args.Completion == PrintTaskCompletion.Failed)
        //    {
        //        Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog("Priting failed.");
        //        md.ShowAsync();
        //    }
        //}

        //void configurePrintTaskOptionDetails(PrintTask printTask)
        //{
        //    PrintTaskOptionDetails details = PrintTaskOptionDetails.GetFromPrintTaskOptions(printTask.Options);
        //    IList<string> dispayedOptions = details.DisplayedOptions;
        //    PrintCustomItemListOptionDetails fit = details.CreateItemListOption("Fit", "Fit to Page");
        //    fit.AddItem("Scale", "Scale to Fit");
        //    fit.AddItem("Crop", "Crop to Fit");
        //    dispayedOptions.Add("Fit");
        //    details.OptionChanged += details_OptionChanged;
        //}

        public EfficientLoan()
        {
            this.InitializeComponent();
            Graph.Content = "გრაფიკის გადათვლა +";
            Grafph.Content = "გრაფიკის გაზიარება";
            Grafph.Visibility = Visibility.Collapsed;  
            //EfficientLoan elfo = new EfficientLoan();
            //this.Frame.Navigate(typeof(EfficientLoanMonthly), elfo.LoanAmountTB);
            MyProgRing.Visibility = Visibility.Collapsed;
        }
        private string _loanAmountValue;

        public string LoanAmountValue
        {
            get { return _loanAmountValue; }
            set
            { _loanAmountValue = LoanAmountTB.Text; }
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

        int i = 1;
        public async void Graph_Click(object sender, RoutedEventArgs e)
        {         
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyProgRing.Visibility = Visibility.Visible; // Progress ring name is Waiter.
            });
            await Task.Delay(1000);

            var ld = this.DataContext as LoanData;
            ld.GraphDaily();
            //   ld.SumDaily();
            i++;
            Graph.Content = "გრაფიკის გადათვლა -";
            Grafph.Visibility = Visibility.Visible;
            if (i % 2 == 1)
            {
                ld.Items.Clear();
                ld.ItemsSum.Clear();
                Graph.Content = "გრაფიკის გადათვლა +";
                Grafph.Visibility = Visibility.Collapsed;
            }
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MyProgRing.Visibility = Visibility.Collapsed;
            });
        }

        private void DatePicker1_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.StartDateEL = DatePicker1.Date.Date;
            }
            catch (Exception)
            {
                ErrorTB.Text = "შეიყვანეთ მხოლოდ ციფრები";
            }
        }

        private void DatePicker2_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            try
            {
                App.EndDateEL = DatePicker2.Date.Date;

            }
            catch (Exception)
            {
                ErrorTB.Text = "შეიყვანეთ მხოლოდ ციფრები";

            }
        }

        private void DailyPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.DailyInterestEL = DailyPercentTB.Text;
            }
            catch (Exception)
            {
                ErrorTB.Text = "შეიყვანეთ მხოლოდ ციფრები";
            }
        }

        private void AnnualPercentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.AnnualInterestEL = AnnualPercentTB.Text;
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
                App.PeymentEL = PMTTB.Text;
                Convert.ToDouble(PMTTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";
            }
        }

        private void InterestOnly_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.InterestOnlyEL = InterestOnly.Text;
                Convert.ToDouble(InterestOnly.Text);
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
                App.LoanAmountEL = LoanAmountTB.Text;
                Convert.ToDouble(LoanAmountTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";
            }
        }

        private void TermsOfLoanTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DatePicker2.Date = DatePicker1.Date.AddDays(Convert.ToDouble(TermsOfLoanTB.Text));
                // ErrorTB.Text = String.Empty;
                App.TermEL = TermsOfLoanTB.Text;
                Convert.ToDouble(TermsOfLoanTB.Text);
                ErrorTB.Text = String.Empty;
            }
            catch (Exception)
            {
                ErrorTB.Text = "სწორად შეავსეთ ველები. მაგ: (3,14)";
            }
        }

        private void ToggleSwitch1_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ToggleSwitch1.IsOn)
                {
                    App.Toggle1 = true;
                }
                else { App.Toggle1 = false; }
            }
            catch (Exception)
            {
            }
        }

        private void Grafph_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager d = DataTransferManager.GetForCurrentView();
            d.DataRequested += D_DataRequested;
            DataTransferManager.ShowShareUI();

        }

        private void D_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string html = @"<table>";



            DataRequest req = args.Request;
            var data = (this.DataContext as LoanData).Items;

            var type = data.FirstOrDefault().GetType();

            var first = true;

            foreach (var d in data)
            {
                if (first)
                {
                    html += "<tr>";

                    foreach (var prop in type.GetProperties())
                    {
                        html += $"<th>{ prop.GetValue(d) }</th>";
                    }

                    html += "</tr>";

                    first = false;
                }
                else
                {

                    html += "<tr>";

                    foreach (var prop in type.GetProperties())
                    {
                        if (true)
                        {

                        }

                        html += $"<th>{ prop.GetValue(d) }</th>";
                    }

                    html += "</tr>";
                }
            }


            html += "</table>";

            var datadef = req.GetDeferral();

            req.Data.SetHtmlFormat(HtmlFormatHelper.CreateHtmlFormat(html));
            req.Data.Properties.Title = "გრაფიკი";
            datadef.Complete();
        }
    }
}
