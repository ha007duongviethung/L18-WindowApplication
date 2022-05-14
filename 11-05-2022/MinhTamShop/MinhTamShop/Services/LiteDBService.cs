using LiteDB;
using MinhTamShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MinhTamShop.Service
{
    public class LiteDBService : IDataService
    {
        string path;
        LiteDatabase dB;
        ILiteCollection<Order> liteCollection;
        public LiteDBService()
        {
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Data.db");
            dB = new LiteDatabase(path);
            liteCollection = dB.GetCollection<Order>();
        }

        public void DeleteFakeObject(Order FakeObject)
        {
            liteCollection.Delete(FakeObject.Id);
        }

        public ObservableCollection<Order> GetFakeObjects()
        {
            if(liteCollection == null)
            {
                return new ObservableCollection<Order>();
            }
            return new ObservableCollection<Order>(liteCollection.Query().Select(x=>x).ToList());
        }

        public void InsertFakeObject(Order FakeObject)
        {
            liteCollection.Insert(FakeObject);
        }

        public void UpdateFakeObject(Order FakeObject)
        {
            liteCollection.Update(FakeObject);
        }

        private void RegisterDateTimeType()
        {
            BsonMapper.Global.RegisterType<DateTimeOffset>
            (
                serialize: obj =>
                {
                    var doc = new BsonDocument();
                    doc["DateTime"] = obj.DateTime.Ticks;
                    doc["Offset"] = obj.Offset.Ticks;
                    return doc;
                },
                deserialize: doc => new DateTimeOffset(doc["DateTime"].AsInt64, new TimeSpan(doc["Offset"].AsInt64))
            );
        }
        
    }
}
