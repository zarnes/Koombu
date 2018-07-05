using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{ // TODO faire le ménage
    public class Group
    {
        [Key]
        public int Id { get; set; }
        
        [Required][MaxLength(250)]
        public string Name { get; set; }
        
        public bool Private { get; set; }
        
        public int OwnerId { get; set; }
        /*[Required]
        public User Owner { get; set; }*/
        
        public List<User> users;
        
        public List<Post> posts;

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

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                if (String.IsNullOrEmpty(Name) || Name.Length > 250)
                    return false;

                return true;
            }
        }
    }
}