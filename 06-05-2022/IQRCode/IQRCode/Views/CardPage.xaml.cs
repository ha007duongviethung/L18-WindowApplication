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
    public sealed partial class CardPage : Page
    {
        public CardPage()
        {
            this.InitializeComponent();
        }

        private async void QRCode(object sender, RoutedEventArgs e)
        {
            Object _personal = null;
            if (!String.IsNullOrEmpty(tb_name.Text) || !String.IsNullOrEmpty(tb_subname.Text)
                || !String.IsNullOrEmpty(tb_phone.Text) || !String.IsNullOrEmpty(tb_email.Text))
            {
                _personal = new
                {
                    Name = tb_name.Text,
                    Phone = tb_phone.Text,
                    Email = tb_email.Text,
                };
            }

            Object _company = null;
            if (!String.IsNullOrEmpty(tb_company.Text) || !String.IsNullOrEmpty(tb_positioncompany.Text)
                || !String.IsNullOrEmpty(tb_phonecompany1.Text) || !String.IsNullOrEmpty(tb_phonecompany2.Text)
                || !String.IsNullOrEmpty(tb_emailcompany.Text) || !String.IsNullOrEmpty(tb_websitecompany.Text))
            {
                _company = new
                {
                    Company = tb_company.Text,
                    Position = tb_positioncompany.Text,
                    Phone1 = tb_phonecompany1.Text,
                    Phone2 = tb_phonecompany2.Text,
                    Email = tb_emailcompany.Text,
                    Website = tb_websitecompany.Text
                };
            }

            Object _address = null;
            if (!String.IsNullOrEmpty(tb_street.Text) || !String.IsNullOrEmpty(tb_district.Text)
                || !String.IsNullOrEmpty(tb_province.Text) || !String.IsNullOrEmpty(tb_nation.Text)
                || !String.IsNullOrEmpty(tb_zipcode.Text))
            {
                _address = new
                {
                    Street = tb_street.Text,
                    District = tb_district.Text,
                    Province = tb_province.Text,
                    Nation = tb_nation.Text,
                    Zipcode = tb_zipcode.Text
                };
            }

            if(_personal == null && _company == null && _address == null)
            {
                string err = "You have not entered information";
                ErrorDialog errorDialog = new ErrorDialog(err);
                await errorDialog.ShowAsync();
            } else
            {
                Object ob = new
                {
                    Personal = _personal,
                    Company = _company,
                    Address = _address
                };
                ShowQRCodeDialog showQRCodeDialog = new ShowQRCodeDialog(ob);
                await showQRCodeDialog.ShowAsync();
            }
        }
    }
}
