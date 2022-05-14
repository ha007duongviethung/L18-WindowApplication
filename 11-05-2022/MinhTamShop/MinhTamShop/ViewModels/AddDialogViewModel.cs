using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MinhTamShop.Helper;
using MinhTamShop.Messenger;
using MinhTamShop.Models;
using MinhTamShop.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhTamShop.ViewModels
{
    public class AddDialogViewModel : ServiceObservableObject
    {
        public AddDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            orders = WeakReferenceMessenger.Default.Send<OrdersMessenger>().Response;
            this.ListStatus = new List<String>()
            {
                "New Order",
                "Waiting Shipping",
                "Being Transported",
                "Done",
                "Cancelled",
                "Reporting"
            };
        }

        public ObservableCollection<Order> orders { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }
        public string IdOrder { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Amount { get; set; }
        public string Total { get; set; }
        public List<String> ListStatus
        {
            get; set;
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(() =>
                    {
                        Order order = new Order()
                        {
                            Image = String.IsNullOrEmpty(Image) ? "ms-appx:///Assets/Default.png" : Image,
                            NameProduct = String.IsNullOrEmpty(Name) ? "NameProduct..." : Name,
                            IdOrder = String.IsNullOrEmpty(IdOrder) ? "IdOrder..." : IdOrder,
                            CustomerAddress = String.IsNullOrEmpty(Address) ? "CustomerAddress..." : Address,
                            PhoneNumber = String.IsNullOrEmpty(Phone) ? "PhoneNumber..." : Phone,
                            OrderStatus = String.IsNullOrEmpty(Status) ? "New Order" : Status,
                            Note = String.IsNullOrEmpty(Note) ? "" : Note,
                            Amount = String.IsNullOrEmpty(Amount) ? 1 : Int32.Parse(Amount),
                            Total = String.IsNullOrEmpty(Total) ? 0 : double.Parse(Total),
                            Created = DateTimeOffset.Now,
                        };
                        orders.Add(order);
                    });
                }
                return _addCommand;
            }
        }
    }
}
