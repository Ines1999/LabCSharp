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
    abstract class AbstractZapyt
    {
        public void TemplateMethod(string sql, Connection c)
        {
            Zapyt(sql, c);
            Method(c);

        }
        public abstract void Method(Connection c);
        public virtual void Zapyt(string sql, Connection c)
        {
            using (SqlConnection connection = new SqlConnection(c.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                    Console.WriteLine("{0} {1} {2}", row[0], row[1], row[2]);
                connection.Close();
            }

        }
    }
}
