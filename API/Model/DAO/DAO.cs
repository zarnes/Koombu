using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models.DAO
{
    public class DAO
    {
        public static DAO Instance = null;

        public AccessDao accessDao;
        public CommentDAO commentDao;

        public DAO()
        {
            if (Instance != null)
                return;

            Instance = this;

            /*string path = HttpContext.Current.Server.MapPath("db.db");
            SQLitePlatformWin32 platfom = new SQLitePlatformWin32();
            SQLiteConnection connection = new SQLiteConnection(platfom, path);

            connection.CreateTable<Post>();*/

            /*string connectionInitiator = "Database=" + "koombu" + "; ";
            connectionInitiator += "Data Source=" + "localhost" + "; ";

            connectionInitiator += "User Id=" + "koombuUser" + "; ";
            connectionInitiator += "Password=" + "kqvkb5WTv7OlmbmbORN7" + "; ";

            connectionInitiator += "SslMode=" + "none" + "; ";
            Connection = new MySqlConnection(connectionInitiator);
            Connection.Open();*/

        }
    }
}