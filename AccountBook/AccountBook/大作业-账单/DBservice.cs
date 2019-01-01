using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BillManagementGUI
{
    class DBservice
    {
        public void AddBill(string outorin,string type, string events, string money, DateTime time1,Form1 form1)
        {
            using (MySqlConnection connection = Getconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("Insert into event(收支方式,消费类型,金额,备注,时间)VALUES('"+outorin+"','" + type + "','" + money + "','" + events + "','"+time1+"')" , connection))
                {
                    cmd.ExecuteNonQuery();
                }
               
                    MySqlDataAdapter ada = new MySqlDataAdapter("select * from event", connection);
                    DataSet da = new DataSet();
                    ada.Fill(da, "event");
                    form1.dataGridView1.DataSource = da;
                    form1.dataGridView1.DataMember = "event";
                
            }
        }
        public void  DeleteBill(int BillId,Form1 form1)
        {
            using (MySqlConnection connection = Getconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM event where 订单号="+BillId, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                MySqlDataAdapter ada = new MySqlDataAdapter("select * from event", connection);
                DataSet da = new DataSet();
                ada.Fill(da, "event");
                form1.dataGridView1.DataSource = da;
                form1.dataGridView1.DataMember = "event";
            }
        }
        public void Queryfromdata(DateTime time,QueryBill query)
        {
            using (MySqlConnection connection = Getconnection.GetConnection())
            {
                MySqlDataAdapter ada = new MySqlDataAdapter("select * from event where 时间="+"'"+time+"'", connection);
                DataSet da = new DataSet();
                ada.Fill(da, "event");
                query.dataGridView1.DataSource = da;
                query.dataGridView1.DataMember = "event";
            }
        }
        public void Queryfromtype(string type, QueryBill query)
        {
            using (MySqlConnection connection = Getconnection.GetConnection())
            {
                MySqlDataAdapter ada = new MySqlDataAdapter("select * from event where 消费类型=" +"'"+ type+"'", connection);
                DataSet da = new DataSet();
                ada.Fill(da, "event");
                query.dataGridView1.DataSource = da;
                query.dataGridView1.DataMember = "event";
            }
        }
        public void Queryformoutorin(string outorin,QueryBill query)
        {
            using (MySqlConnection connection = Getconnection.GetConnection())
            {
                MySqlDataAdapter ada = new MySqlDataAdapter("select * from event where 收支方式=" + "'" + outorin + "'", connection);
                DataSet da = new DataSet();
                ada.Fill(da, "event");
                query.dataGridView1.DataSource = da;
                query.dataGridView1.DataMember = "event";
            }
        }
        public  string[] ReviseBill1(string ID)
        {
            int id = Int32.Parse(ID);
            string[] n = new string[6];
            using (MySqlConnection connection = Getconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand
                    ("select * from event where 订单号 = '" + id + "'", connection))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    for (int i = 0; i < 6; i++)
                    {
                        n[i] = reader.GetString(i );
                    }
                }
            }
            return n;
        }
        public void ReviseBill2(string ID, String M, string ps, Form1 form1)
        {
            int m = Int32.Parse(M);
            int id = Int32.Parse(ID);
            using (MySqlConnection connection = Getconnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand
                    ("update event set 金额='" + m + "',备注='" + ps + "'where 订单号 = '" + id + "'", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd2 = new MySqlCommand("select * from event", connection))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter(cmd2);
                    DataSet da = new DataSet();
                    mda.Fill(da, "event");
                    form1.dataGridView1.DataSource = da;
                    form1.dataGridView1.DataMember = "event";
                }
            }
        }
    }
} 
    

