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
    class Second: AbstractZapyt
    {
        public override void Method(Connection c)
        {
            Console.Write("Iнформацiя про користувачів, а також кількості отриманих листів: \n");

            string sql2 = "SELECT Name, Surname, COUNT(*) receive From Person Join Letter on Letter.ReceiverId = Person.Id Group by Name, Surname";
            Zapyt(sql2, c);
            Console.ReadKey();
            Console.WriteLine();
            Console.Write("Iнформацiя про користувачів, а також кількості відправлених листів: \n");

            string sql3 = "SELECT Name, Surname, COUNT(*) send From Person Join Letter on Letter.SenderId = Person.Id Group by Name, Surname";
            Zapyt(sql3, c);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
