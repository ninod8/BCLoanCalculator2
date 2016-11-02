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
        public MainPage()
        {
            this.InitializeComponent();
        //    TitleTextBlock.Text = "ყოველდღიური გადახდა";
            MyFrame.Navigate(typeof(EfficientLoan));
            PMTListBoxItem.IsSelected = true;
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
                TitleTextBlock.Text = "ყოველდღიური გადახდია" ;
            }
            if (PMTMonthlyListBoxItem.IsSelected)
            {
                MyFrame.Navigate(typeof(EfficientLoanMonthly));
                TitleTextBlock.Text = "ყოველთვიური გადახდა";
            }
            if (FlatPercentageListBoxItem.IsSelected)
            {
                MyFrame.Navigate(typeof(FlatPercentage));
                TitleTextBlock.Text = "ბრტყელი პროცნეტი";
            }
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

