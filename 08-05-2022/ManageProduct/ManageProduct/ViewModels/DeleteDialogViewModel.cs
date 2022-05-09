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
    public class DeleteDialogViewModel : ServiceObject
    {
        public DeleteDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            products = WeakReferenceMessenger.Default.Send<ProductsMessage>().Response;
            product = WeakReferenceMessenger.Default.Send<ProductMessage>().Response;
        }

        public ObservableCollection<Product> products { get; set; }
        public Product product { get; set; }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get =>
                _deleteCommand ?? (_deleteCommand = new RelayCommand(() => {
                    products.Remove(product);
                }));
        }
    }

}
