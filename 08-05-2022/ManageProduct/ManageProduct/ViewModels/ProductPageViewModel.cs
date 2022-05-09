using ManageProduct.Helper;
using ManageProduct.Messenger;
using ManageProduct.Models;
using ManageProduct.Service;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProduct.ViewModels
{
    public class ProductPageViewModel : ServiceObservableObject
    {
        public ProductPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            products = dataService.GetFakeObjects();
            products.CollectionChanged += Products_CollectionChanged;
            SearchedContacts = new ObservableCollection<Product>();
        }

        private void Products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.InsertFakeObject(e.NewItems[0] as Product);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                dataService.DeleteFakeObject(e.OldItems[0] as Product);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                dataService.DeleteAllFakeObject();
            }
            OnPropertyChanged(nameof(productCount));
        }

        public ObservableCollection<Product> products { get; set; }
        public int productCount { get => products.Count; }
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }
        private ObservableCollection<Product> _searchedContacts;
        public ObservableCollection<Product> SearchedContacts
        {
            get { return _searchedContacts; }
            set { _searchedContacts = value; }
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
                        WeakReferenceMessenger.Default.Register<ProductsMessage>(this, (r, m) =>
                        {
                            m.Reply(products);
                        });
                        dialogService.showAsync(typeof(AddDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<ProductsMessage>(this);
                    });
                }
                return _addCommand;
            }
        }

        private RelayCommand _deleteAllCommand;
        public RelayCommand DeleteAllCommand
        {
            get
            {
                if (_deleteAllCommand == null)
                {
                    _deleteAllCommand = new RelayCommand(() =>
                    {
                        WeakReferenceMessenger.Default.Register<ProductsMessage>(this, (r, m) =>
                        {
                            m.Reply(products);
                        });
                        dialogService.showAsync(typeof(DeleteAllDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<ProductsMessage>(this);
                    });
                }
                return _deleteAllCommand;
            }
        }

        private RelayCommand _searchContactCommand;
        public RelayCommand SearchContactCommand
        {
            get
            {
                if (_searchContactCommand == null)
                {
                    return _searchContactCommand = new RelayCommand(() =>
                    {
                        SearchedContacts.Clear();
                        foreach (Product product in products)
                        {
                            if (product.Name.Contains(SearchText))
                            {
                                SearchedContacts.Add(product);
                            }
                        }
                    });
                }
                return _searchContactCommand;
            }
        }
        private RelayCommand _suggestionChosenCommand;
        public RelayCommand SuggestionChosenCommand
        {
            get
            {
                if (_suggestionChosenCommand == null)
                {
                    _suggestionChosenCommand = new RelayCommand(() =>
                    {

                    });
                }
                return _suggestionChosenCommand;
            }
        }

    }
}
