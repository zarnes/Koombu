using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Group
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public bool Private { get; set; }
        
        public int OwnerId { get; set; }

        public Group() {}

        public Group(int id, string name, bool @private, int ownerId)
        {
            Id = id;
            Name = name;
            Private = @private;
            OwnerId = ownerId;
        }
    }
}