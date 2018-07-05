using Newtonsoft.Json;
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

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                if (PostId == 0)
                    return false;
                if (UserId == 0)
                    return false;
                if (String.IsNullOrEmpty(Content) || Content.Length > 300)
                    return false;

                return true;
            }
        }
    }
}