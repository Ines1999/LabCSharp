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
    class Fifth: AbstractZapyt
    {
        public override void Method(Connection c)
        {
            Console.Write("Направити лист заданої людини із заданою темою всім адресатам\n");
            Console.Write("Введіть Id заданої людини: \n");
            string id = Console.ReadLine();
            Console.Write("Введіть тему: \n");
            string theme2 = Console.ReadLine();
            Console.Write("Введіть текс: \n");
            string text = Console.ReadLine();
            Console.Write("Введіть дату: \n");
            string date = Console.ReadLine();
            string sql6 = "INSERT INTO LETTER ( SenderId, ReceiverId, Theme, Text, DateLetter) SELECT " + id + ", Person.Id,  '" + theme2 + "' , '" + text + "', '" + date + "' FROM Person";
            Zapyt(sql6, c);
            Console.ReadKey();
            Console.WriteLine();
        }
        public override void Zapyt(string sql, Connection c)
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
