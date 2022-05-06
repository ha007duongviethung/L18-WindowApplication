using IQRCode.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace IQRCode.Service
{
    public class LiteDBService : IDataService
    {
        string path;
        LiteDatabase dB;
        ILiteCollection<Data> liteCollection;
        public LiteDBService()
        {
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Data.db");
            dB = new LiteDatabase(path);
            liteCollection = dB.GetCollection<Data>();
        }

        public void DeleteFakeObject(Data FakeObject)
        {
            liteCollection.Delete(FakeObject.Id);
        }

        public ObservableCollection<Data> GetFakeObjects()
        {
            if(liteCollection == null)
            {
                return new ObservableCollection<Data>();
            }
            return new ObservableCollection<Data>(liteCollection.Query().Select(x=>x).ToList());
        }

        public void InsertFakeObject(Data FakeObject)
        {
            liteCollection.Insert(FakeObject);
        }

        public void UpdateFakeObject(Data FakeObject)
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
