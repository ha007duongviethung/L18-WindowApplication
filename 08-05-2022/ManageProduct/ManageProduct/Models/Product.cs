using LiteDB;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProduct.Models
{
    public class Product : ObservableObject
    {
        public ObjectId Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private int _quantity;
        public int Quantity { get { return _quantity; } set { SetProperty(ref _quantity, value); } }
        private DateTimeOffset dateAdded;
        public DateTimeOffset DateAdded { get { return dateAdded; } set { SetProperty(ref dateAdded, value); } }
        private string _supplier;
        public string Supplier { get { return _supplier; } set { SetProperty(ref _supplier, value); } }
        private double _price;
        public double Price { get { return _price; } set { SetProperty(ref _price, value); } }

        public Product()
        {
            this.Name = "Name...";
            this.Quantity = 1;
            this.DateAdded = DateTimeOffset.Now;
            this.Supplier = "Supplier...";
            this.Price = 0;
        }
    }
}
