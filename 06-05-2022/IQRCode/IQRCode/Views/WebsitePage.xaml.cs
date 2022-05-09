using IQRCode.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ZXing.Mobile;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IQRCode.Views
{
    public sealed partial class WebsitePage : Page
    {
        public WebsitePage()
        {
            this.InitializeComponent();
        }

        private async void GenerateQR(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(website.Text))
            {
                string err = "Website address not entered";
                ErrorDialog errorDialog = new ErrorDialog(err);
                await errorDialog.ShowAsync();
            } else
            {
                string wb;
                if (website.Text.Contains("http://") || website.Text.Contains("https://"))
                    wb = website.Text;
                else
                    wb = "https://" + website.Text;
                ShowQRCodeDialog showQRCodeDialog = new ShowQRCodeDialog(wb);
                await showQRCodeDialog.ShowAsync();
            }
        }
    }
}
