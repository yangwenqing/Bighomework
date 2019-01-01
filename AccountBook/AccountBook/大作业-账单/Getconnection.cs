using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementGUI
{
    class Getconnection
    {
        public static MySqlConnection GetConnection()
        {
            string connection = "datasource = localhost; username = root; " + "password = 123457692fsmlw" +"; database = jizhangsystem; charset = utf8";
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立链接");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return conn;
        }
    }
}
