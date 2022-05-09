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
    public sealed partial class EmailPage : Page
    {
        public EmailPage()
        {
            this.InitializeComponent();
        }

        private async void GenerateQR(object sender, RoutedEventArgs e)
        {
            string _email = tb_email.Text;
            string _title, _content;
            reb_title.Document.GetText(Windows.UI.Text.TextGetOptions.NoHidden, out _title);
            red_content.Document.GetText(Windows.UI.Text.TextGetOptions.NoHidden, out _content);
            if(String.IsNullOrEmpty(_email) && String.IsNullOrEmpty(_title) && String.IsNullOrEmpty(_content))
            {
                string err = "You have not entered information";
                ErrorDialog errorDialog = new ErrorDialog(err);
                await errorDialog.ShowAsync();
            } else
            {
                Object ob = new
                {
                    Email = _email,
                    Title = _title,
                    Content = _content
                };
                ShowQRCodeDialog showQRCodeDialog = new ShowQRCodeDialog(ob);
                await showQRCodeDialog.ShowAsync();
            }
        }
    }
}
