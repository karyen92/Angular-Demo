using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Demo.Core.Database.Model
{
    public class Character
    {
        public ObjectId Id { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
    }

    
}
