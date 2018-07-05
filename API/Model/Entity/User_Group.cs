using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User_Group
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int GroupId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public bool IsAdmin { get; set; }

        public User_Group() {}

        public User_Group(int id, int groupId, int userId, bool isAdmin)
        {
            Id = id;
            GroupId = groupId;
            UserId = userId;
            IsAdmin = isAdmin;
        }

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                if (GroupId == 0)
                    return false;
                if (UserId == 0)
                    return false;

                return true;
            }
        }
    }
}