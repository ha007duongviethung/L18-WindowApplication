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
    public class StatusDialogViewModel : ServiceObject
    {
        public StatusDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            order = WeakReferenceMessenger.Default.Send<OrderMessenger>().Response;
            Debug.WriteLine("HAHA: " + order.OrderStatus);
        }

        public Order order { get; set; }

        private RelayCommand _newOrderCommand;
        public RelayCommand NewOrderCommand
        {
            get
            {
                if (_newOrderCommand == null)
                {
                    _newOrderCommand = new RelayCommand(() =>
                    {
                        order.OrderStatus = "New Order";
                        order.Color = "btn_new";
                        dataService.UpdateFakeObject(order);
                    });
                }
                return _newOrderCommand;
            }
        }

        private RelayCommand _waitingShippingCommand;
        public RelayCommand WaitingShippingCommand
        {
            get
            {
                if (_waitingShippingCommand == null)
                {
                    _waitingShippingCommand = new RelayCommand(() =>
                    {
                        order.OrderStatus = "Waiting Shipping";
                        order.Color = "btn_approved";
                        dataService.UpdateFakeObject(order);
                    });
                }
                return _waitingShippingCommand;
            }
        }

        private RelayCommand _beingTransportedCommand;
        public RelayCommand BeingTransportedCommand
        {
            get
            {
                if (_beingTransportedCommand == null)
                {
                    _beingTransportedCommand = new RelayCommand(() =>
                    {
                        order.OrderStatus = "Being Transported";
                        order.Color = "btn_sent";
                        dataService.UpdateFakeObject(order);
                    });
                }
                return _beingTransportedCommand;
            }
        }

        private RelayCommand _doneCommand;
        public RelayCommand DoneCommand
        {
            get
            {
                if (_doneCommand == null)
                {
                    _doneCommand = new RelayCommand(() =>
                    {
                        order.OrderStatus = "Done";
                        order.Color = "btn_done";
                        dataService.UpdateFakeObject(order);
                    });
                }
                return _doneCommand;
            }
        }

        private RelayCommand _reportingCommand;
        public RelayCommand ReportingCommand
        {
            get
            {
                if (_reportingCommand == null)
                {
                    _reportingCommand = new RelayCommand(() =>
                    {
                        order.OrderStatus = "Reporting";
                        order.Color = "btn_reported";
                        dataService.UpdateFakeObject(order);
                    });
                }
                return _reportingCommand;
            }
        }

        private RelayCommand _cancelledCommand;
        public RelayCommand CancelledCommand
        {
            get
            {
                if (_cancelledCommand == null)
                {
                    _cancelledCommand = new RelayCommand(() =>
                    {
                        order.OrderStatus = "Cancelled";
                        order.Color = "btn_cancel";
                        dataService.UpdateFakeObject(order);
                    });
                }
                return _cancelledCommand;
            }
        }
    }
}
