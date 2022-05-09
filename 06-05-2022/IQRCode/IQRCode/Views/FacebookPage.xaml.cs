using IQRCode.Views.Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IQRCode.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FacebookPage : Page
    {
        public FacebookPage()
        {
            this.InitializeComponent();
        }

        private async void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tb_facebook.Text))
            {
                string err = "Facebook address not entered";
                ErrorDialog errorDialog = new ErrorDialog(err);
                await errorDialog.ShowAsync();
            } else
            {
                string fb;
                if (tb_facebook.Text.Contains("https://facebook.com/") || tb_facebook.Text.Contains("https://www.facebook.com/"))
                    fb = tb_facebook.Text;
                else
                    fb = "https://facebook.com/" + tb_facebook.Text;
                ShowQRCodeDialog showQRCodeDialog = new ShowQRCodeDialog(fb);
                await showQRCodeDialog.ShowAsync();
            }
        }
    }
}
