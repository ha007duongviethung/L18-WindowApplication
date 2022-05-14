using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MinhTamShop.Helper;
using MinhTamShop.Messenger;
using MinhTamShop.Models;
using MinhTamShop.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhTamShop.ViewModels
{
    public class EditDialogViewModel : ServiceObservableObject
    {
        public EditDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            order = WeakReferenceMessenger.Default.Send<OrderMessenger>().Response;
            Image = order.Image;
            Name = order.NameProduct;
            IdOrder = order.IdOrder;
            Address = order.CustomerAddress;
            Phone = order.PhoneNumber;
            Status = order.OrderStatus;
            Note = order.Note;
            Amount = order.Amount.ToString();
            Total = order.Total.ToString();
        }
        
        public Order order { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }
        public string IdOrder { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Amount { get; set; }
        public string Total { get; set; }

        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get =>
                _editCommand ?? (_editCommand = new RelayCommand(() => {
                    order.Image = String.IsNullOrEmpty(Image) ? "ms-appx:///Assets/Default.png" : Image;
                    order.NameProduct = String.IsNullOrEmpty(Name) ? "NameProduct..." : Name;
                    order.IdOrder = String.IsNullOrEmpty(IdOrder) ? "IdOrder..." : IdOrder;
                    order.CustomerAddress = String.IsNullOrEmpty(Address) ? "CustomerAddress..." : Address;
                    order.PhoneNumber = String.IsNullOrEmpty(Phone) ? "PhoneNumber..." : Phone;
                    order.OrderStatus = String.IsNullOrEmpty(Status) ? "New Order" : Status;
                    order.Note = String.IsNullOrEmpty(Note) ? "" : Note;
                    order.Amount = String.IsNullOrEmpty(Amount) ? 1 : Int32.Parse(Amount);
                    order.Total = String.IsNullOrEmpty(Total) ? 0 : double.Parse(Total);
                    dataService.UpdateFakeObject(order);
                }));
        }
    }
}
