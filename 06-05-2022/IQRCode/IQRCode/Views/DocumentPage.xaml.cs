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
    public sealed partial class DocumentPage : Page
    {
        public DocumentPage()
        {
            this.InitializeComponent();
        }

        private async void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            string wb;
            rec_document.Document.GetText(Windows.UI.Text.TextGetOptions.NoHidden, out wb);
            if(string.IsNullOrEmpty(wb))
            {
                string err = "You have not entered information";
                ErrorDialog errorDialog = new ErrorDialog(err);
                await errorDialog.ShowAsync();
            } else
            {
                ShowQRCodeDialog showQRCodeDialog = new ShowQRCodeDialog(wb);
                await showQRCodeDialog.ShowAsync();
            }
        }
    }
}
