using ManageProduct.Helper;
using ManageProduct.Messenger;
using ManageProduct.Models;
using ManageProduct.Service;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProduct.ViewModels
{
    public class DeleteAllDialogViewModel : ServiceObservableObject
    {
        public DeleteAllDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            products = WeakReferenceMessenger.Default.Send<ProductsMessage>().Response;
        }

        public ObservableCollection<Product> products { get; set; }
        private RelayCommand _deleteAllCommand;
        public RelayCommand DeleteAllCommand
        {
            get =>
                _deleteAllCommand ?? (_deleteAllCommand = new RelayCommand(() => {
                    products.Clear();
                }));
        }
    }
}
