using IQRCode.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQRCode.Service
{
    public interface IDataService
    {
        ObservableCollection<Data> GetFakeObjects();
        void InsertFakeObject(Data FakeObject);
        void UpdateFakeObject(Data FakeObject);
        void DeleteFakeObject(Data FakeObject);
    }
}
