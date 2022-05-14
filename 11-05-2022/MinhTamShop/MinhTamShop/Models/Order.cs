using LiteDB;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhTamShop.Models
{
    public class Order : ObservableObject
    {
        public ObjectId Id { get; set; }
        private string _image;
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        private string _nameProduct;
        public string NameProduct
        {
            get { return _nameProduct; }
            set { SetProperty(ref _nameProduct, value); }
        }
        private string _idOrder;
        public string IdOrder
        {
            get { return _idOrder; }
            set { SetProperty(ref _idOrder, value); }
        }
        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }
        private string _customerAddress;
        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { SetProperty(ref _customerAddress, value); }
        }
        private string _orderStatus;
        public string OrderStatus
        {
            get { return _orderStatus; }
            set { SetProperty(ref _orderStatus, value); }
        }
        private string _note;
        public string Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
        private double _total;
        public double Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }
        private string _color;
        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }
        private DateTimeOffset _created;
        public DateTimeOffset Created
        {
            get { return _created; }
            set { SetProperty(ref _created, value); }
        }

        public Order()
        {
            this.Image = "ms-appx:///Assets/Default.png";
            this.NameProduct = "NameProduct...";
            this.IdOrder = "IdOrder...";
            this.CustomerAddress = "CustomerAddress...";
            this.PhoneNumber = "PhoneNumber...";
            this.OrderStatus = "New Order";
            this.Note = "";
            this.Amount = 1;
            this.Total = 0;
            this._color = "btn_new";
            this.Created = DateTimeOffset.Now;
        }
    }
}
