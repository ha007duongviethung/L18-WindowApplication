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
    public sealed partial class PhonePage : Page
    {
        public PhonePage()
        {
            this.InitializeComponent();
        }

        private async void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            string ph = tb_phone.Text;
            if (String.IsNullOrEmpty(ph))
            {
                string err = "Phone not entered";
                ErrorDialog errorDialog = new ErrorDialog(err);
                await errorDialog.ShowAsync();
            }
            else
            {
                if (IsNumber(ph))
                {
                    ShowQRCodeDialog showQRCodeDialog = new ShowQRCodeDialog(ph);
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
