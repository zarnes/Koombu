using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models
{
    public class Post
    {
        //[PrimaryKey]
        public int Id { get; set; }

        //[MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public string Attachment { get; set; }

        /*public Post() { }

        public Post(int id, string title, string content, string picture, int userId, int groupId, string attachment)
        {
            Id = id;
            Title = title;
            Content = content;
            Picture = picture;
            UserId = userId;
            GroupId = groupId;
            Attachment = attachment;
        }*/

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