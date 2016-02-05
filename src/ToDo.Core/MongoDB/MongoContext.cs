using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using ToDo.Core.Models;
using MongoDB.Bson;

namespace ToDo.Core.MondoDB
{
    public class MongoContext
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<ToDoItem> _collection;
        public MongoContext()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("Jeevan");
            _collection= _db.GetCollection<ToDoItem>("TODO");
        }

        internal void Add(ToDoItem item)
        {
            _collection.InsertOne(item);
        }

        internal ToDoItem FindById(Guid id)
        {
            return _collection.Find<ToDoItem>(c => c.Id == id).FirstOrDefault();
        }

        internal void Remove(ToDoItem match)
        {
            if(match!=null)
            {
                _collection.DeleteOne(c => c.Id == match.Id);
            }
          
        }

        internal IEnumerable<ToDoItem> GetAll()
        {
            return _collection.Find<ToDoItem>(new BsonDocument()).ToList<ToDoItem>();
        }

        internal IEnumerable<ToDoItem> GetCompleted()
        {
            return _collection.Find<ToDoItem>(c => c.IsComplete == true).ToList<ToDoItem>();
        }

        internal void Update(ToDoItem item)
        {
            var update = Builders<ToDoItem>.Update.Set(nameof(item.Title), item.Title)
                                                   .Set(nameof(item.Description), item.Description)
                                                   .Set(nameof(item.IsComplete), item.IsComplete)
                                                   .Set(nameof(item.UpdatedBy), item.UpdatedBy)
                                                   .Set(nameof(item.UpdatedDate), item.UpdatedDate);
            _collection.UpdateOne<ToDoItem>(c => c.Id == item.Id, update);
        }

        internal IEnumerable<ToDoItem> GetActive()
        {
            return _collection.Find<ToDoItem>(c=> c.IsComplete==false).ToList<ToDoItem>();
        }
    }
}
