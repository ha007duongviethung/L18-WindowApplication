using LiteDB;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQRCode.Models
{
    public class Data : ObservableObject
    {
        public ObjectId Id { get; set; }
    }
}
