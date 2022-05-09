using ManageProduct.Messenger;
using ManageProduct.Models;
using ManageProduct.Service;
using ManageProduct.ViewModels;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace ManageProduct.Views
{
    public sealed partial class ProductPage : Page
    {

        DialogService dialogService = new DialogService();

        public ProductPage()
        {
            this.InitializeComponent();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                Product product = item.Tag as Product;
                if (product != null)
                {
                    WeakReferenceMessenger.Default.Register<ProductMessage>(this, (r, m) =>
                    {
                        m.Reply(product);
                    });
                    await dialogService.showEditItemDialog();
                    WeakReferenceMessenger.Default.Unregister<ProductMessage>(this);
                }
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                Product product = item.Tag as Product;
                if (product != null)
                {
                    ObservableCollection<Product> products = ListViewProduct.ItemsSource as ObservableCollection<Product>;
                    WeakReferenceMessenger.Default.Register<ProductsMessage>(this, (r, m) =>
                    {
                        m.Reply(products);
                    });
                    WeakReferenceMessenger.Default.Register<ProductMessage>(this, (r, m) =>
                    {
                        m.Reply(product);
                    });
                    await dialogService.showDeleteDialog();
                    WeakReferenceMessenger.Default.Unregister<ProductsMessage>(this);
                    WeakReferenceMessenger.Default.Unregister<ProductMessage>(this);
                }
            }
        }

        private async void QRCode_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                Product product = item.Tag as Product;
                if (product != null)
                {
                    WeakReferenceMessenger.Default.Register<ProductMessage>(this, (r, m) =>
                    {
                        m.Reply(product);
                    });
                    await dialogService.showQRCodeDialog();
                    WeakReferenceMessenger.Default.Unregister<ProductMessage>(this);
                }
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Product product = args.SelectedItem as Product;
            ListViewProduct.SelectedItem = product;
            sender.Text = product.Name;
        }
    }
}
