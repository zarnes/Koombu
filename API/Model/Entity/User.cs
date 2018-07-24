using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)][Required]
        public string Password { get; set; }

        [StringLength(100)][Required]
        public string FirstName { get; set; }

        [StringLength(100)][Required]
        public string LastName { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }

        [StringLength(100)][Required]
        public string Company { get; set; }

        [StringLength(100)][Required]
        public string Title { get; set; }

        [StringLength(254)][Required]
        public string Mail { get; set; }

        [NotMapped]
        public List<int> postsId;

        [NotMapped]
        public List<Group> groups;

        [NotMapped]
        public List<int> likesId;

        [NotMapped]
        public List<int> commentsId;

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public User() {}
        
        public User(int id, string firstname, string lastname, DateTime birthdate, string company, string title)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Company = company;
            Title = title;
        }

        internal void Copy(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            BirthDate = user.BirthDate;
            Company = user.Company;
            Title = user.Title;
        }

        internal void GetLinkedInformations()
        {
            GetLinkedComments();
            GetLinkedPosts();
            GetLinkedLikes();
            GetLinkedGroups();
        }

        internal void GetLinkedComments()
        {
            using (var db = new DbAPIContext())
            {
                commentsId = db.Comments.Where(c => c.UserId == Id).Select(c => c.Id ).ToList();
            }
        }

        internal void GetLinkedPosts()
        {
            using (var db = new DbAPIContext())
            {
                postsId = db.Posts.Where(p => p.UserId == Id).Select(p => p.Id).ToList();
            }
        }

        internal void GetLinkedLikes()
        {
            using (var db = new DbAPIContext())
            {
                likesId = db.Likes.Where(l => l.UserId == Id).Select(l => l.Id).ToList();
            }
        }

        internal void GetLinkedGroups()
        {
            using (var db = new DbAPIContext())
            {
                List<int> groupsId = db.User_Groups.Where(ug => ug.UserId == Id).Select(ug => ug.UserId).ToList();
                groups = db.Groups.Where(g => groupsId.Any(gId => gId == g.Id)).ToList();
            }
        }

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                if (String.IsNullOrEmpty(Password) || Password.Length > 30)
                    return false;
                if (String.IsNullOrEmpty(FirstName) || FirstName.Length > 100)
                    return false;
                if (String.IsNullOrEmpty(LastName) || LastName.Length > 100)
                    return false;
                if (BirthDate == null)
                    return false;
                if (String.IsNullOrEmpty(Company) || Company.Length > 100)
                    return false;
                if (String.IsNullOrEmpty(Title) || Title.Length > 100)
                    return false;
                if (String.IsNullOrEmpty(Mail) || Mail.Length > 254)
                    return false;

                return true;
            }
        }
    }
}