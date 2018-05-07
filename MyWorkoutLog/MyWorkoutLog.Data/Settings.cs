using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.UI
{
    public class Settings
    {
        private static string _connectionString;

        private static string _repositoryType;

        

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
#if DEBUG
                _connectionString = ConfigurationManager.ConnectionStrings["DebugConnection"].ConnectionString;
#else
                _connectionString = ConfigurationManager.ConnectionStrings["ReleaseConnection"].ConnectionString;
#endif
            }


            return _connectionString;
        }

        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repositoryType))
                _repositoryType = ConfigurationManager.AppSettings["RepositoryType"].ToString();
            return _repositoryType;
        }
    }
}
