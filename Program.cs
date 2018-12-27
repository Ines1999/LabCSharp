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
            Console.Write("Користувач, довжина листiв якого найменша: \n");
            string sql1 = "Select Name, Surname, Len(Letter.Text) as len From Person Join Letter on Letter.SenderId = Person.Id WHERE Len(Letter.Text) = (SELECT MIN(Len(Text)) FROM Letter)";
            Task2(sql1, c);
            Console.ReadKey();
            Console.WriteLine();
            Console.Write("Iнформацiя про користувачів, а також кількості отриманих листів: \n");
            
            string sql2 = "SELECT Name, Surname, COUNT(*) receive From Person Join Letter on Letter.ReceiverId = Person.Id Group by Name, Surname";
            Task2(sql2, c);
            Console.ReadKey();
            Console.WriteLine();
            Console.Write("Iнформацiя про користувачів, а також кількості відправлених листів: \n");
            
            string sql3 = "SELECT Name, Surname, COUNT(*) send From Person Join Letter on Letter.SenderId = Person.Id Group by Name, Surname";
            Task2(sql3, c);  
            Console.ReadKey();
            Console.WriteLine();
            Console.Write("Інформація про користувачів, які отримали хоча б одне повідомлення із заданою темою\n");
            Console.Write("Введите название темы: \n");
            string theme = Console.ReadLine();
            string sql4 = "Select Name, Surname, Birthday From Person Join Letter on Letter.ReceiverId = Person.Id WHERE Theme = '" + theme + "'Group by Name, Surname, Birthday";
            Task2(sql4, c);
            Console.ReadKey();
            Console.WriteLine();
            Console.Write("Інформація про користувачів, які не отримували повідомлень із заданою темою\n");
            Console.Write("Введите название темы: \n");
            theme = Console.ReadLine();
            string sql5 = "Select Name, Surname, Birthday From Person Join Letter on Letter.ReceiverId = Person.Id WHERE Theme <> '" + theme + "'Group by Name, Surname, Birthday";
            Task2(sql5, c);
            Console.ReadKey();
            Console.WriteLine();
        }


        static void Show(SqlDataReader reader)
        {
            Console.Write("No.  ");
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write(reader.GetName(i) + "           ");
            Console.WriteLine();
            if (reader.HasRows)
            {
                int index = 0;
                while (reader.Read())
                {
                    index++;
                    Console.Write(index + ".");
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write("  " + reader.GetValue(i));
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Table is empty");
        }



        static void Task2(string sql, Connection c)
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