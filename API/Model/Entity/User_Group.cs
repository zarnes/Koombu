using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class User_Group
    {
        public int Id { get; set; }
        
        public int GroupId { get; set; }
        
        public int UserId { get; set; }
        
        public bool IsAdmin { get; set; }

        public User_Group() {}

        public User_Group(int id, int groupId, int userId, bool isAdmin)
        {
            Id = id;
            GroupId = groupId;
            UserId = userId;
            IsAdmin = isAdmin;
        }
    }
}