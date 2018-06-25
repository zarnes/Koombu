using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models.DAO
{
    public class Dao
    {

        public Dao()
        {
            if (Instance != null)
                return;

            Instance = this;

            string connectionInitiator = "Database=" + "supfile" + "; ";
            connectionInitiator += "Data Source=" + "localhost" + "; ";

            connectionInitiator += "User Id=" + "supfileUser" + "; ";
            connectionInitiator += "Password=" + "ogdTdolLxsFDrrNwI3JB" + "; ";

            connectionInitiator += "SslMode=" + "none" + "; ";
            Connection = new MySqlConnection(connectionInitiator);
            Connection.Open();
        }
    }
}