using ManageProduct.Models;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProduct.Messenger
{
    public class ProductsMessage : RequestMessage<ObservableCollection<Product>>
    {
    }
}
