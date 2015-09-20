using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class OracleHelper
    {
        public static string connectionString() 
        {
            return ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
        }
    }
}
