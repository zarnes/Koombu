using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models.DAO
{
    public class AccessDao
    {

        public int Access(string userMail, string psw)
        {
            string sql = "SELECT user_id  FROM `access` WHERE `email` = " + iuserMail +" and psw ="+ psw;
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

            return reader.GetInt32("user_id");
        }
    }

}