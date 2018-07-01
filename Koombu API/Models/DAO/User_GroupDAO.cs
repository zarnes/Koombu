using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models.DAO
{
    public class User_GroupDAO

    {

        public void addUserToGroup(int userId, int groupId, bool isAdmin)
        {
            string sql = "Insert Into `user_group` (`id`, `group_id`, `user_id` ,`is_admin`) values (null, @group_id, @user_id,@is_admin)";
            MySqlCommand cmd = Database.Instance.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@group_id", groupId);
            cmd.Parameters.AddWithValue("@user_id", userId);
            cmd.Parameters.AddWithValue("@is_admin", isAdmin);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void deleteUserFromGroup(int userId, int groupId)
        {
            string sql = "DELETE * from `user_group` where user_id = @user_id and group_id = @group_id";
            MySqlCommand cmd = Database.Instance.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@group_id", groupId);
            cmd.Parameters.AddWithValue("@user_id", userId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    
        
    }
}