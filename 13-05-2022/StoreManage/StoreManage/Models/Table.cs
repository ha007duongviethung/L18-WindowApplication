using LiteDB;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManage.Models
{
    public class Table : ObservableObject
    {
        public ObjectId Id { get; set; }
        private string _tableName;
        public string TableName
        {
            get { return _tableName; }
            set { SetProperty(ref _tableName, value); }
        }
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set { SetProperty(ref _orders, value); }
        }

        public Table()
        {
            this.TableName = "TableName...";
            this.Orders = new ObservableCollection<Order>();
        }
    }
}
