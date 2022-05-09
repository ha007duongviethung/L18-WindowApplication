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

namespace ManageProduct.Views.Dialogs
{
    public sealed partial class AddDialog : ContentDialog
    {
        public AddDialog()
        {
            this.InitializeComponent();
            var buttonPrimaryStyle = new Style(typeof(Button));
            var buttonSecondaryStyle = new Style(typeof(Button));

            Color primaryColor = Color.FromArgb(255, 3, 131, 135);
            buttonPrimaryStyle.Setters.Add(new Setter(Control.CornerRadiusProperty, "4"));
            buttonSecondaryStyle.Setters.Add(new Setter(Control.CornerRadiusProperty, "4"));
            buttonPrimaryStyle.Setters.Add(new Setter(Control.BackgroundProperty, primaryColor));
            buttonPrimaryStyle.Setters.Add(new Setter(Control.ForegroundProperty, Colors.White));
            AddProductDialog.PrimaryButtonStyle = buttonPrimaryStyle;
            AddProductDialog.SecondaryButtonStyle = buttonSecondaryStyle;
        }
    }
}
