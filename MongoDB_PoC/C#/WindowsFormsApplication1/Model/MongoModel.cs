using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
namespace WindowsFormsApplication1.Model
{
    //public abstract class MongoModel
    public  class MongoModel
    { 
        public ObjectId id { get; set; }
        public BsonDateTime created_at { get; set; }
        public BsonDateTime updated_at { get; set; }
        
    }
}
