using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysqlDBConnect
{
    internal class Queries
    {
        public void dbSelect()
        {
            Connect c = new Connect();
            string query = "SELECT `id`,`uname`,`email` FROM `users`;";

            MySqlCommand cmd = new MySqlCommand(query, c.connect);

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            do
            {
                Console.WriteLine(reader.GetValue(0) + "-" + reader.GetValue(1) + "-" + reader.GetValue(2));

            } while (reader.Read());
            reader.Close();
        }

        public void dbDelete(int identity)
        {
            Connect c = new Connect();
            string query = "DELETE FROM `users` WHERE `id`=" + identity + ";";
            MySqlCommand cmd = new MySqlCommand(query, c.connect);
            MySqlDataReader delete = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            dbSelect();
        }

        public void dbInsert(string uname, string email)
        {
            Connect c = new Connect();
            string query = "INSERT INTO `users`(`uname`, `email`) VALUES('" + uname + "','" + email + "');";
            MySqlCommand cmd = new MySqlCommand(query, c.connect);
            //MySqlDataReader insert = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            dbSelect();
        }

        public void dbUpdate(string uname, string email, int identity)
        {
            Connect c = new Connect();
            string query = "UPDATE `users` SET `uname`='"+uname+"',`email`='"+email+"' WHERE `id`="+identity+";";
            MySqlCommand cmd = new MySqlCommand(query, c.connect);
            //MySqlDataReader insert = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            dbSelect();
        }
    }
}
