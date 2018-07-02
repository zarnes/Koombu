using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Like
    {
        public int Id { get; set; }
        
        public int PostId { get; set; }
        
        public int UserId { get; set; }

        public Like() {}

        public Like(int id, int postId, int userId)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
        }
    }
}