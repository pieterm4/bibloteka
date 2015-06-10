﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connStr =  ConfigurationManager.ConnectionStrings["AWConnection"].ToString();
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);
                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;
                return sb.ToString();
            }
        }
        /// <summary>
        /// Returns the Open connection to the cellar
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
        /// <summary>
        /// Overrides the connection timeout
        /// </summary>
        public static int ConnectionTimeout { get; set; }
        /// <summary>
        /// Property used to override the aplication name
        /// </summary>
        public static string ApplicationName { get; set; }
    }
}
