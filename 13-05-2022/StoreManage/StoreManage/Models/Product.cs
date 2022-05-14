using LiteDB;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManage.Models
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
        private Double _price;
        public Double Price { get { return _price; } set { SetProperty(ref _price, value); } }
        public Product()
        {
            this.Name = "ProductName...";
            this.Price = 0;
        }
    }
}
