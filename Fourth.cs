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
    class Fourth: AbstractZapyt
    {
        public override void Method(Connection c)
        {
            Console.Write("Інформація про користувачів, які не отримували повідомлень із заданою темою\n");
            Console.Write("Введите название темы: \n");
            string theme1 = Console.ReadLine();
            string sql5 = "Select Name, Surname, Birthday From Person Join Letter on Letter.ReceiverId = Person.Id WHERE Theme <> '" + theme1 + "'Group by Name, Surname, Birthday";
            Zapyt(sql5, c);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
