using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        
        public int PostId { get; set; }
        /*[Required]
        public Post Post { get; set; }*/

        public int UserId { get; set; }
        /*[Required]
        public User User { get; set; }*/

        public Like() {}

        public Like(int id, Post post, User user)
        {
            Id = id;
            PostId = post.Id;
            UserId = user.Id;
        }

        internal void Copy(Like like)
        {
            PostId = like.PostId;
            UserId = like.UserId;
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

                return true;
            }
        }
    }
}