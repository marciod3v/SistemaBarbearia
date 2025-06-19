using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Barbearia.Configurations
{
	public class Configurations
	{
        public static string GetConnString()
        {
            return GetConnString("BarbeariaDB");
        }

        public static string GetConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}