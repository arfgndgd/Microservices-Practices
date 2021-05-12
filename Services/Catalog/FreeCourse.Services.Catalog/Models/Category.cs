using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Models
{
    public class Category
    {
        [BsonId] //MongoDb tarafında tanıması için
        [BsonRepresentation(BsonType.ObjectId)]

        //id'yi string verdik çünkü mongodb her şeyi object olarak tutuyor BsonType ile düzenler.
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
