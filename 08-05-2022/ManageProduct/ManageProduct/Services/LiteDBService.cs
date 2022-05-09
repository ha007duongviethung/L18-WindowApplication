using LiteDB;
using ManageProduct.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ManageProduct.Service
{
    public class LiteDBService : IDataService
    {
        string path;
        LiteDatabase dB;
        ILiteCollection<Product> liteCollection;
        public LiteDBService()
        {
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Data.db");
            dB = new LiteDatabase(path);
            liteCollection = dB.GetCollection<Product>();
        }

        public void DeleteFakeObject(Product FakeObject)
        {
            liteCollection.Delete(FakeObject.Id);
        }

        public void DeleteAllFakeObject()
        {
            liteCollection.DeleteAll();
        }

        public ObservableCollection<Product> GetFakeObjects()
        {
            if(liteCollection == null)
            {
                return new ObservableCollection<Product>();
            }
            return new ObservableCollection<Product>(liteCollection.Query().Select(x=>x).ToList());
        }

        public void InsertFakeObject(Product FakeObject)
        {
            liteCollection.Insert(FakeObject);
        }

        public void UpdateFakeObject(Product FakeObject)
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
