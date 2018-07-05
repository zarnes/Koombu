using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
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

        [NotMapped]
        public List<User> users;

        [NotMapped]
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

        public void GetLinkedInformations()
        {
            GetLinkedUsers();
            GetLinkedPosts();
        }

        public void GetLinkedUsers()
        {
            using (var db = new DbAPIContext())
            {
                List<int> userIds = db.User_Groups.Where(ug => ug.GroupId == Id).Select(ug => ug.Id).ToList();
                users = db.Users.Where(u => userIds.Contains(u.Id)).ToList();
            }
        }

        public void GetLinkedPosts()
        {
            using (var db = new DbAPIContext())
            {
                 posts = db.Posts.Where(p => p.GroupId == Id).ToList();
                foreach (Post post in posts)
                {
                    post.GetLinkedInformations();
                }
            }  
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