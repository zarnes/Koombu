using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        public int PostId { get; set; }
        
        public int UserId { get; set; }
        
        public string Content { get; set; }

        public Comment() {}

        public Comment(int id, int postId, int userId, string content)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            Content = content;
        }
    }
}