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
    class First: AbstractZapyt
    {
        public override void Method(Connection c)
        {
            Console.Write("Користувач, довжина листiв якого найменша: \n");
            string sql1 = "Select Name, Surname, Len(Letter.Text) as len From Person Join Letter on Letter.SenderId = Person.Id WHERE Len(Letter.Text) = (SELECT MIN(Len(Text)) FROM Letter)";
            Zapyt(sql1, c);
            Console.ReadKey();
            Console.WriteLine();
            
        }
    }
}
