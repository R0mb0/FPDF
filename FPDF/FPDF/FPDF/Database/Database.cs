using sun.tools.tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPDF.Database
{
    static class Database
    {
        /*Fields*/
        private static string userDatabaseConnectionString = "connectionString ";
        private static string datesDatabaseConnectionString = "connectionString ";

        public static string GetUserDatabaseConnectionString()
        { 
            return userDatabaseConnectionString; 
        }

        public static string GetDatesDatabaseConnectionString() 
        { 
            return datesDatabaseConnectionString; 
        }
    }
}
