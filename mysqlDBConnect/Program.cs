using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysqlDBConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queries q=new Queries();
            q.dbSelect();

            int id;
            Console.WriteLine("Szeretne törölni(I/N)?");
            string delete=Console.ReadLine();
            if (delete=="I")
            {
                Console.Write("Kérem az azonosított amit törölni szeretne: ");
                id = int.Parse(Console.ReadLine());
                q.dbDelete(id);
            }else if (delete == "N")
            {
                Console.Write("Szeretne új rekorodot felvinni?(I/N) ");
                string insert=Console.ReadLine();
                if (insert=="I")
                {
                    Console.WriteLine("Kérem a felhasználó nevét? ");
                    string uname=Console.ReadLine();
                    Console.WriteLine("Kérem a felhasználó email címét? ");
                    string email=Console.ReadLine();
                    q.dbInsert(uname,email);
                }
            }
            Console.WriteLine("Szeretne fríssiteni valamin?(I/N)");
            string update=Console.ReadLine();
            if (update=="I")
            {
                Console.WriteLine("Kérem az id-t: ");
                int id2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kérem a felhasználó nevét? ");
                string uname = Console.ReadLine();
                Console.WriteLine("Kérem a felhasználó email címét? ");
                string email = Console.ReadLine();
                q.dbUpdate(uname, email, id2);
            }
            
        }
    }
}
