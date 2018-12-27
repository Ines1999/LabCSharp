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
    class Third: AbstractZapyt
    {
        public override void Method(Connection c)
        {
            Console.Write("Інформація про користувачів, які отримали хоча б одне повідомлення із заданою темою\n");
            Console.Write("Введите название темы: \n");
            string theme = Console.ReadLine();
            string sql4 = "Select Name, Surname, Birthday From Person Join Letter on Letter.ReceiverId = Person.Id WHERE Theme = '" + theme + "'Group by Name, Surname, Birthday";
            Zapyt(sql4, c);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
