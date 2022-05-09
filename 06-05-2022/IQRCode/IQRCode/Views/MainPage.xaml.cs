using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IQRCode.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Color.FromArgb(255, 167, 191, 213);
            titleBar.ButtonBackgroundColor = Color.FromArgb(255, 167, 191, 213);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(EmptyPage));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem navigationViewItem = args.SelectedItem as NavigationViewItem;
            switch(navigationViewItem.Tag.ToString())
            {
                case "website":
                    MyFrame.Navigate(typeof(WebsitePage));
                    break;
                case "card":
                    MyFrame.Navigate(typeof(CardPage));
                    break;
                case "document":
                    MyFrame.Navigate(typeof(DocumentPage));
                    break;
                case "email":
                    MyFrame.Navigate(typeof(EmailPage));
                    break;
                case "facebook":
                    MyFrame.Navigate(typeof(FacebookPage));
                    break;
                case "wifi":
                    MyFrame.Navigate(typeof(WifiPage));
                    break;
                case "phone":
                    MyFrame.Navigate(typeof(PhonePage));
                    break;
                case "sms":
                    MyFrame.Navigate(typeof(SMSPage));
                    break;
            }
        }
    }
}
