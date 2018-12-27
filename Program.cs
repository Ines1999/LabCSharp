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
    class Program
    {

        static void Main(string[] args)
        {
            
            Connection c = new Connection();
            First f1 = new First();
            f1.Method(c);
            Second f2 = new Second();
            f2.Method(c);
            Third f3 = new Third();
            f3.Method(c);
            Fourth f4 = new Fourth();
            f4.Method(c);
            Fifth f5 = new Fifth();
            f5.Method(c);



        }


       
        static void Zapyt(string sql, Connection c)
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
        static void ZapytWithoutOutput(string sql, Connection c)
        {
            using (SqlConnection connection = new SqlConnection(c.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
            }

        }
    }
}