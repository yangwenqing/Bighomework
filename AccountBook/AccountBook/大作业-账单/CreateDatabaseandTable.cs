using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BillManagementGUI
{
    class CreateDatabaseandTable
    {
        public static void CreateMysqlDB()
        {
            string connection = "server = 127.0.0.1; port = 3306;user = root; password = 123457692fsmlw;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE bill;", conn);
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("建立数据库成功");
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("建立数据库失败，已存在了");
            }
        }
        public static void CreateMysqlT()
        {
            string connection = "server = 127.0.0.1; port = 3306;user = root; password = 123457692fsmlw; database = bill;Charset=utf8";
            string createStatement = "CREATE TABLE ledgers(订单号 INT NOT NULL AUTO_INCREMENT,收支方式 TEXT，消费类型 TEXT,金额 INT,时间 DATETIME,备注 TEXT,,金额 INT,PRIMARY KEY(订单号))";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(createStatement, conn))
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Console.WriteLine("建立数据表成功");
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                    Console.WriteLine("建立数据表失败，已存在了");
                }
            }
        }
    }
}
