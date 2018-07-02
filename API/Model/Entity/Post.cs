using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public int UserId { get; set; }
        /*[Required]
        public User User { get; set; }*/

        public int GroupId { get; set; }
        /*[Required]
        public Group Group { get; set; }*/

        [Required]
        public DateTime CreationDate { get; set; }

        public string Attachment { get; set; }

        public Post() { }

        public Post(int id, string title, string content, string picture, User user, Group group, string attachment)
        {
            Id = id;
            Title = title;
            Content = content;
            Picture = picture;
            //User = user;
            UserId = user.Id;
            //Group = group;
            GroupId = group.Id;
            Attachment = attachment;
        }

        /*public static GetPost(int id)
        {
            string sql = "SELECT * FROM `post` WHERE `id` = @id;";
            MySqlCommand cmd = Database.Instance.Connection.CreateCommand();
            cmd.CommandText = sql;
            
            MySqlDataReader reader = cmd.ExecuteReader();

            bool result = reader.Read();
            if (!result)
            {
                reader.Close();
                cmd.Dispose();
                return null;
            }
        }*/
    }
}