using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MinhTamShop.Helper;
using MinhTamShop.Messenger;
using MinhTamShop.Models;
using MinhTamShop.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhTamShop.ViewModels
{
    public class DeleteDialogViewModel : ServiceObservableObject
    {
        public DeleteDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            orders = WeakReferenceMessenger.Default.Send<OrdersMessenger>().Response;
            order = WeakReferenceMessenger.Default.Send<OrderMessenger>().Response;
        }

        public ObservableCollection<Order> orders { get; set; }
        public Order order { get; set; }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get =>
                _deleteCommand ?? (_deleteCommand = new RelayCommand(() => {
                    orders.Remove(order);
                }));
        }
    }
}
