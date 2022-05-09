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
using ZXing.QrCode;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IQRCode.Views.Dialogs
{
    public sealed partial class ShowQRCodeDialog : ContentDialog
    {
        public ShowQRCodeDialog(Object qr)
        {
            this.InitializeComponent();
            Style buttonStyle = new Style(typeof(Button));
            buttonStyle.Setters.Add(new Setter(Control.CornerRadiusProperty, new CornerRadius(4)));
            PrimaryButtonStyle = buttonStyle;


            BarcodeWriter write = new BarcodeWriter();
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 300,
                Height = 300
            };
            write.Format = ZXing.BarcodeFormat.QR_CODE;
            write.Options = options;
            if (qr != null)
            {
                var wb = write.Write(qr.ToString());
                QRCode.Source = wb;
                string abc = QRCode.Source.ToString();
            }
        }
    }
}
