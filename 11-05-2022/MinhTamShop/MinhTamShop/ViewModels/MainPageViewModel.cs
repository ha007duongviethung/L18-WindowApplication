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
    public class MainPageViewModel : ServiceObservableObject
    {
        public MainPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            orders = dataService.GetFakeObjects();
            orders.CollectionChanged += Orders_CollectionChanged;
            SearchedContacts = new ObservableCollection<Order>();
        }

        private void Orders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.InsertFakeObject(e.NewItems[0] as Order);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                dataService.DeleteFakeObject(e.OldItems[0] as Order);
            }
            OnPropertyChanged(nameof(orderCount));
        }

        public ObservableCollection<Order> orders { get; set; }
        public int orderCount { get => orders.Count; }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }
        private ObservableCollection<Order> _searchedContacts;
        public ObservableCollection<Order> SearchedContacts
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
                        WeakReferenceMessenger.Default.Register<OrdersMessenger>(this, (r, m) =>
                        {
                            m.Reply(orders);
                        });
                        dialogService.showAsync(typeof(AddDialogViewModel));
                        WeakReferenceMessenger.Default.Unregister<OrdersMessenger>(this);
                    });
                }
                return _addCommand;
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
                        foreach (Order order in orders)
                        {
                            if (order.NameProduct.Contains(SearchText))
                            {
                                SearchedContacts.Add(order);
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
