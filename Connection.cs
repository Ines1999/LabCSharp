using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zalik1 
{
    class Connection
    {
        public Singleton OS { get; set; }
        public string connectionString = ConfigurationManager.ConnectionStrings["Zalik"].ConnectionString;
        public void ConnectToBD()
        {
            OS = Singleton.getInstance(connectionString);
        }
    }

    class Singleton
    {
        private static Singleton instance;
        public string Name { get; private set; }
        protected Singleton(string name)
        {
            this.Name = name;
        }

        public static Singleton getInstance(string name)
        {
            if (instance == null)
                instance = new Singleton(name);
            return instance;
        }
    }

}