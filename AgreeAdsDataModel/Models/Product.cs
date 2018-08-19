using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataModel.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string Name
        {
            get;
            set;
        }
        [BsonElement("BasePicture")]
        public string BasePicture
        {
            get;
            set;
        }
        [BsonElement("Description")]
        public string Description
        {
            get;
            set;
        }
        [BsonElement("Rank")]
        public byte Rank
        {
            get;
            set;
        }
        [BsonElement("Rating")]
        public decimal Rating
        {
            get;
            set;
        }
        [BsonElement("PriceRange")]
        public string PriceRange
        {
            get;
            set;
        }

    }
}
