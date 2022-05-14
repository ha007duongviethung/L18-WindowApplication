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
    public class Order : ObservableObject
    {
        public ObjectId Id { get; set; }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
        private DateTimeOffset _start;
        public DateTimeOffset Start { get { return _start; } set { SetProperty(ref _start, value); } }
        private DateTimeOffset _end;
        public DateTimeOffset End { get { return _end; } set { SetProperty(ref _end, value); } }
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }
        public Order()
        {
            this.Amount = 0;
            this.Start = DateTimeOffset.Now;
            this.End = DateTimeOffset.Now;
            this.Products = new ObservableCollection<Product>();
        }
    }
}
