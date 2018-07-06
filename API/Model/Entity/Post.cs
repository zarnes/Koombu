using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)][Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public string Attachment { get; set; }

        [NotMapped]
        public List<Comment> comments;

        [NotMapped]
        public List<Like> likes;

        public Post() { }

        public Post(int id, string title, string content, string picture, User user, Group group, string attachment)
        {
            Id = id;
            Title = title;
            Content = content;
            Picture = picture;
            UserId = user.Id;
            GroupId = group.Id;
            Attachment = attachment;
        }

        internal void Copy(Post post)
        {
            Title = post.Title;
            Content = post.Content;
            Picture = post.Picture;
            UserId = post.UserId;
            GroupId = post.GroupId;
            Attachment = post.Attachment;
        }

        internal void GetLinkedInformations()
        {
            GetLinkedComments();
            GetLinkedLikes();
        }

        internal void GetLinkedComments()
        {
            using (var db = new DbAPIContext())
            {
                comments = db.Comments.Where(c => c.PostId == Id).ToList();
            }
        }

        internal void GetLinkedLikes()
        {
            using (var db = new DbAPIContext())
            {
                likes = db.Likes.Where(l => l.PostId == Id).ToList();
            }
        }

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                if (String.IsNullOrEmpty(Title) || Title.Length > 100)
                    return false;
                if (UserId == 0)
                    return false;
                if (GroupId == 0)
                    return false;
                if (CreationDate == null)
                    return false;

                return true;
            }
        }
    }
}