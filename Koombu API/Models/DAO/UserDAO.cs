using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models.DAO
{
    public class UserDAO
    {
        public UserDAO()
        {
            
        }

        public User GetUser(int id)
        {
            string sql = "SELECT `id`, `firstname`, `lastname`, `birthdate`,`mail`, `company`, `title` FROM `user` WHERE `id` = " + id;
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

            return new User(
                reader.GetInt32("id"),
                reader.GetString("firstname"),
                reader.GetString("lastname"),
                reader.GetDate("birthdate"),
                reader.GetString("mail"),
                reader.GetString("company"),
                reader.GetString("title")
                );
        }

        public void createUser(User user)
        {
            string sql = "Insert Into `user` (`id`, `firstname`, `lastname` ,`birthdate`,`mail`,`company`,`title`) values (null, @firstname, @lastname, @birthdate,@mail,@company,@title)";
            MySqlCommand cmd = Database.Instance.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@firstname", user.FirstName);
            cmd.Parameters.AddWithValue("@lastname", user.LastName);
            cmd.Parameters.AddWithValue("@birthdate", user.BirthDate);
            cmd.Parameters.AddWithValue("@company", user.Company);
            cmd.Parameters.AddWithValue("@title", user.Title);
            cmd.Parameters.AddWithValue("@mail", user.Mail);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }

    }
}