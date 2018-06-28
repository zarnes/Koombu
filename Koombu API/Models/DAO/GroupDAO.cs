using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models.DAO
{
    public class GroupDAO
    {
        public GroupDAO()
        {

        }

        public Group GetGroup(int id)
        {
            string sql = "SELECT `id`, `name`, `private`, `ownerid`, FROM `group` WHERE `id` = " + id;
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

            return new Group(
                reader.GetInt32("id"),
                reader.GetString("name"),
                reader.GetInt32("private"),
                reader.GetInt32("ownerid")
                );

        }

        public void createGroup(Group group)
        {
            string sql = "Insert Into `group` (`id`, `name`, `private` ,`ownerid`) values (null, @name, @private,@ownerid)";
            MySqlCommand cmd = Database.Instance.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@name", group.Name);
            cmd.Parameters.AddWithValue("@lastname", group.Private);
            cmd.Parameters.AddWithValue("@birthdate", group.OwnerId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }

        public void deleteGroup(int userId, int groupId)
        {
            string sql = "DELETE * from `group` where id = @group_id";
            MySqlCommand cmd = Database.Instance.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@group_id", groupId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

    }
}