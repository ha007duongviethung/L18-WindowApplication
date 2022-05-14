using Microsoft.Toolkit.Mvvm.Messaging;
using MinhTamShop.Messenger;
using MinhTamShop.Models;
using MinhTamShop.Service;
using MinhTamShop.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MinhTamShop.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var titlebar = ApplicationView.GetForCurrentView().TitleBar;
            Color primaryColor = Color.FromArgb(255, 47, 107, 153);
            titlebar.BackgroundColor = primaryColor;
            titlebar.ButtonBackgroundColor = primaryColor;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            List<string> list = new List<string>()
            {
                "All status",
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

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                Order order = item.Tag as Order;
                if (order != null)
                {
                    ObservableCollection<Order> orders = ListViewOrder.ItemsSource as ObservableCollection<Order>;
                    WeakReferenceMessenger.Default.Register<OrdersMessenger>(this, (r, m) =>
                    {
                        m.Reply(orders);
                    });
                    WeakReferenceMessenger.Default.Register<OrderMessenger>(this, (r, m) =>
                    {
                        m.Reply(order);
                    });
                    DeleteDialog deleteDialog = new DeleteDialog();
                    await deleteDialog.ShowAsync();
                    WeakReferenceMessenger.Default.Unregister<OrdersMessenger>(this);
                    WeakReferenceMessenger.Default.Unregister<OrderMessenger>(this);
                }
            }
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                Order order = item.Tag as Order;
                if (order != null)
                {
                    WeakReferenceMessenger.Default.Register<OrderMessenger>(this, (r, m) =>
                    {
                        m.Reply(order);
                    });
                    EditDialog editDialog = new EditDialog();
                    await editDialog.ShowAsync();
                    WeakReferenceMessenger.Default.Unregister<OrderMessenger>(this);
                }
            }
        }

        private async void Status_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
            {
                Order order = button.Tag as Order;
                if(order != null)
                {
                    WeakReferenceMessenger.Default.Register<OrderMessenger>(this, (r, m) =>
                    {
                        m.Reply(order);
                    });
                    StatusDialog statusDialog = new StatusDialog();
                    await statusDialog.ShowAsync();
                    WeakReferenceMessenger.Default.Unregister<OrderMessenger>(this);
                }
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Order order = args.SelectedItem as Order;
            ListViewOrder.SelectedItem = order;
            sender.Text = order.NameProduct;
        }
    }
}
