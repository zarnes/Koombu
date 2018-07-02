using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
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
        
        /*public ICollection<Comment> Comments { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Like> Likes { get; set; }

        public ICollection<Group> Groups { get; set; }*/
        
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
    }
}