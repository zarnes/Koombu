using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }
        /*[Required]
        public Post Post { get; set; }*/
        
        public int UserId { get; set; }
        /*[Required]
        public User User { get; set; }*/
        
        [StringLength(300)]
        public string Content { get; set; }

        public Comment() {}

        public Comment(int id, Post post, User user, string content)
        {
            Id = id;
            //Post = post;
            PostId = post.Id;
            UserId = user.Id;
            Content = content;
        }

        internal void Copy(Comment comment)
        {
            PostId = comment.PostId;
            UserId = comment.UserId;
            Content = comment.Content;
        }
    }
}