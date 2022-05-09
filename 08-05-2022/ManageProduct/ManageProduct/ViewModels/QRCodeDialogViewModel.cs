using ManageProduct.Helper;
using ManageProduct.Messenger;
using ManageProduct.Models;
using ManageProduct.Service;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using ZXing.Mobile;
using ZXing.QrCode;

namespace ManageProduct.ViewModels
{
    public class QRCodeDialogViewModel : ServiceObservableObject
    {
        public QRCodeDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            product = WeakReferenceMessenger.Default.Send<ProductMessage>().Response;

            Object ob = new
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Date = product.DateAdded,
                Supplier = product.Supplier,
                Price = product.Price,
            };

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
            writeableBitmap = write.Write(ob.ToString());
        }

        public Product product { get; set; }
        public WriteableBitmap writeableBitmap { get; set; }
    }
}
