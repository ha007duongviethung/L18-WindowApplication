using IQRCode.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class SMSPage : Page
    {
        public SMSPage()
        {
            this.InitializeComponent();
        }

        private async void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            string ph = tb_phone.Text;
            string sms;
            reb_sms.Document.GetText(Windows.UI.Text.TextGetOptions.NoHidden, out sms);
            if (String.IsNullOrEmpty(ph) || String.IsNullOrEmpty(sms))
            {
                string err = "";
                if (String.IsNullOrEmpty(ph))
                    err = "You did not enter a phone number";
                else
                    err = "You have not entered SMS";
                ErrorDialog errorDialog = new ErrorDialog(err);
                await errorDialog.ShowAsync();
            } else
            {
                if(IsNumber(ph))
                {
                    string sms_text = "sms:" + ph + ":" + sms;
                    ShowQRCodeDialog showQRCodeDialog = new ShowQRCodeDialog(sms_text);
                    await showQRCodeDialog.ShowAsync();
                } else
                {
                    string err = "You are not entering a phone number";
                    ErrorDialog errorDialog = new ErrorDialog(err);
                    await errorDialog.ShowAsync();
                }
            }
        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }
    }
}
