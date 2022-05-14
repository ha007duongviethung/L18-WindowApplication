using MinhTamShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhTamShop.Service
{
    public interface IDataService
    {
        ObservableCollection<Order> GetFakeObjects();
        void InsertFakeObject(Order FakeObject);
        void UpdateFakeObject(Order FakeObject);
        void DeleteFakeObject(Order FakeObject);
    }
}
