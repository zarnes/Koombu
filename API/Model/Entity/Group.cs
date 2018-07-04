using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public bool Private { get; set; }
        
        public int OwnerId { get; set; }
        /*[Required]
        public User Owner { get; set; }*/

        public Group() {}

        public Group(int id, string name, bool @private, User owner)
        {
            Id = id;
            Name = name;
            Private = @private;
            OwnerId = owner.Id;
        }

        internal void Copy(Group group)
        {
            Name = group.Name;
            Private = group.Private;
            OwnerId = group.OwnerId;
        }
    }
}