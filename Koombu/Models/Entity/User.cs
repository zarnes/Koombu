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
            // TODO if some value from the new user are null
            FirstName = user.FirstName;
            LastName = user.LastName;
            BirthDate = user.BirthDate;
            Company = user.Company;
            Title = user.Title;
            Mail = user.Mail;
            Password = user.Password;
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