using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string Company { get; set; }
        
        public string Title { get; set; }
        
        public string Mail { get; set; }
        
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