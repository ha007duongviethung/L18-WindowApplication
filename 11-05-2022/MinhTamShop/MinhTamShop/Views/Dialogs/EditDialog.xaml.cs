using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MinhTamShop.Views.Dialogs
{
    public sealed partial class EditDialog : ContentDialog
    {
        public EditDialog()
        {
            this.InitializeComponent();
            var buttonStyle = new Style(typeof(Button));
            buttonStyle.Setters.Add(new Setter(Control.BackgroundProperty, Color.FromArgb(255, 47, 107, 153)));
            buttonStyle.Setters.Add(new Setter(Control.ForegroundProperty, Colors.White));
            buttonStyle.Setters.Add(new Setter(Control.CornerRadiusProperty, new CornerRadius(4)));
            PrimaryButtonStyle = buttonStyle;
            var btn = new Style(typeof(Button));
            btn.Setters.Add(new Setter(Control.CornerRadiusProperty, new CornerRadius(4)));
            SecondaryButtonStyle = btn;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            List<String> list = new List<string>()
            {
                "New Order",
                "Waiting Shipping",
                "Being Transported",
                "Done",
                "Cancelled",
                "Reporting"
            };
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }
    }
}
