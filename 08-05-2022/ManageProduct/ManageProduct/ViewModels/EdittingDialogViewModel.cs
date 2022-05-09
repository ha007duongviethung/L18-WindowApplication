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
    public class EdittingDialogViewModel : ServiceObservableObject
    {
        public EdittingDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            product = WeakReferenceMessenger.Default.Send<ProductMessage>().Response;
            ProductName = product.Name;
            ProductQuantity = product.Quantity.ToString();
            ProductDateAdded = product.DateAdded;
            ProductSupplier = product.Supplier;
            ProductPrice = product.Price.ToString();
        }

        public Product product { get; set; }
        public string ProductName { get; set; }
        public string ProductQuantity { get; set; }
        public DateTimeOffset ProductDateAdded { get; set; }
        public string ProductSupplier { get; set; }
        public string ProductPrice { get; set; }

        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get =>
                _editCommand ?? (_editCommand = new RelayCommand(() => {
                    product.Name = String.IsNullOrEmpty(ProductName) ? "Name..." : ProductName;
                    product.Quantity = String.IsNullOrEmpty(ProductQuantity) ? 1 : Int32.Parse(ProductQuantity);
                    product.DateAdded = ProductDateAdded;
                    product.Supplier = String.IsNullOrEmpty(ProductSupplier) ? "Supplier..." : ProductSupplier;
                    product.Price = String.IsNullOrEmpty(ProductPrice) ? 0 : Double.Parse(ProductPrice);
                    dataService.UpdateFakeObject(product);
                }));
        } 
    }
}
