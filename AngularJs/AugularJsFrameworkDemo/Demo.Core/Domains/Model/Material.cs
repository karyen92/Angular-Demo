using System;
using Demo.Framework.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo.Core.Domains.Model
{
    [CollectionName(Name = "material")]
    [BsonIgnoreExtraElements]
    public class Material
    {
        public ObjectId Id { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("dropdownId")]
        public ObjectId DropdownId { get; set; }
    }

    [CollectionName(Name = "dropdown")]
    [BsonIgnoreExtraElements]
    public class Dropdown
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
