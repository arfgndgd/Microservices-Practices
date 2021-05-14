using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Models
{
    public class Course
    {
        [BsonId] //MongoDb tarafında tanıması için

        //id'yi string verdik çünkü mongodb string verileri object olarak tutuyor BsonType ile düzenler.
        //ister isek aslında int olarakta tutabiliriz ama bu dahaa uygun mongo için
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
  
        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonIgnore]//veritabanında bi karşılığı olmadığı için böyle işaretliyoruz
        public Category Category { get; set; }

    }
}
