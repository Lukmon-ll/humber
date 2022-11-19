using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using MySql.Data.MySqlClient;

namespace Cummulative1.Models
{
    public class SchoolDbContext
    {/// <summary>
    /// 
    /// </summary>

        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Server { get { return "localhost"; } }
        private static string Database { get { return "school"; } }
        private static string Port { get { return "3306"; } }


        protected static string ConnectionString
        {
            get
            {
                return "user = " + User + ";" + "password = " + Password + ";" + "server = " + Server + ";" + "database = " + Database + ";" + "port = " + Port;

            }
        }

        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }

    }

    
    
}