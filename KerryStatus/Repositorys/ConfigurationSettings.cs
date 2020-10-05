using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KerryStatus.Repositorys
{
    public class ConfigurationSettings
    {
        private static string _connectionString;
        public static string ConnectionStringSQL
        {
            get
            {
                bool flag = string.IsNullOrEmpty(_connectionString);
                if (flag)
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
                }
                return _connectionString;
            }
        }
    }
}