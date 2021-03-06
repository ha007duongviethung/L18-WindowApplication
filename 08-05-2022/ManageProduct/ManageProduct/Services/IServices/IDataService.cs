using ManageProduct.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProduct.Service
{
    public interface IDataService
    {
        ObservableCollection<Product> GetFakeObjects();
        void InsertFakeObject(Product FakeObject);
        void UpdateFakeObject(Product FakeObject);
        void DeleteFakeObject(Product FakeObject);
        void DeleteAllFakeObject();
    }
}
