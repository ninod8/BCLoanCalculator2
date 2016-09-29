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
            
            MyFrame.Navigate(typeof(efficientloan));
            TitleTextBlock.Text = "ეფექტური საპროცენტო განაკვეთის კალკულატორი";
            PMTListBoxItem.IsSelected = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MyFrame.CanGoBack)
        //    {
        //        MyFrame.GoBack();
        //        Financial.IsSelected = true;
        //    }
        //}

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PMTListBoxItem.IsSelected)
            {
                
                Frame.Navigate(typeof(efficientloan));
                TitleTextBlock.Text = "ყოველდღიური გადახდის კალკულატორი" ;
            }
            if (NperListBoxItem.IsSelected)
            {
                Frame.Navigate(typeof(Nper));
                TitleTextBlock.Text = "პერიოდის კალკულატორი";
            }
            if (PVListBoxItem.IsSelected)                
            {
                Frame.Navigate(typeof(PV));
                TitleTextBlock.Text = "სესხის რაოდენობის კალკულატორი";
            }
            else if (RateListBoxItem.IsSelected)
            {
                Frame.Navigate(typeof(Rate));
                TitleTextBlock.Text = "საპროცენტო განაკვეთის კალკულატორი";
            }
        }
    }
}

