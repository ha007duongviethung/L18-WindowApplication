using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using MinhTamShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhTamShop.Messenger
{
    public class OrdersMessenger : RequestMessage<ObservableCollection<Order>>
    {
    }
}
