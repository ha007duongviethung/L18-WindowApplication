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
    public sealed partial class StatusDialog : ContentDialog
    {
        public StatusDialog()
        {
            this.InitializeComponent();
            var buttonStyle = new Style(typeof(Button));
            buttonStyle.Setters.Add(new Setter(Control.CornerRadiusProperty, new CornerRadius(4)));
            PrimaryButtonStyle = buttonStyle;
        }
    }
}
