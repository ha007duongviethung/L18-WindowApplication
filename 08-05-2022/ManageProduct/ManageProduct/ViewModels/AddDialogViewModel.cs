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
    public class AddDialogViewModel : ServiceObservableObject
    {
        public AddDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            products = WeakReferenceMessenger.Default.Send<ProductsMessage>().Response;
            ProductDateAdded = DateTimeOffset.Now;
        }

        public ObservableCollection<Product> products { get; set; }
        public string ProductName { get; set; }
        public string ProductQuantity { get; set; }
        public DateTimeOffset ProductDateAdded { get; set; }
        public string ProductSupplier { get; set; }
        public string ProductPrice { get; set; }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(() =>
                    {
                        Product product = new Product()
                        {
                            Name = String.IsNullOrEmpty(ProductName) ? "Name..." : ProductName,
                            Quantity = String.IsNullOrEmpty(ProductQuantity) ? 1 : Int32.Parse(ProductQuantity),
                            DateAdded = ProductDateAdded,
                            Supplier = String.IsNullOrEmpty(ProductSupplier) ? "Supplier..." : ProductSupplier,
                            Price = String.IsNullOrEmpty(ProductPrice) ? 0 : Double.Parse(ProductPrice)
                        };
                        products.Add(product);
                    });
                }
                return _addCommand;
            }
        }
    }
}
