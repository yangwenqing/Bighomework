using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BillManagementGUI
{
    public partial class MonthReport : Form
    {
        DBservice db = new DBservice();
        public MonthReport()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text=="")
            {
                DialogResult result = MessageBox.Show("记录不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else
            {

                

                int year = int.Parse(textBox1.Text);
                int month = int.Parse(textBox2.Text);
                DateTime d1 = new DateTime(year, month, 1);
                DateTime d2 = d1.AddMonths(1).AddDays(-1);

                int food = 0, go=0,clo=0,fun=0,edu=0,other=0;
                string[] n=new string[6]; 

                using (MySqlConnection connection = Getconnection.GetConnection())
                {
                    MySqlDataAdapter ada = new MySqlDataAdapter("select * from event", connection);
                    DataSet da = new DataSet();
                    ada.Fill(da, "event");

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM event where 时间 between +'" + d1 + "'and '" + d2 + "' AND 收支方式='支出'", connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    n[i] = reader.GetString(i);
                                    if (i == 5 && n[2] == "餐饮") food += int.Parse(n[i]);
                                    if (i == 5 && n[2] == "出行") go += int.Parse(n[i]);
                                    if (i == 5 && n[2] == "服饰") clo += int.Parse(n[i]);
                                    if (i == 5 && n[2] == "娱乐") fun += int.Parse(n[i]);
                                    if (i == 5 && n[2] == "教育") edu += int.Parse(n[i]);
                                    if (i == 5 && n[2] == "其他") other += int.Parse(n[i]);
                                }

                            }
                        }
                    }

                    string type = null;
                    int t = 0;
                    int[] a = { food, go, clo, fun, edu, other };
                    int sum = a[0];
                    int max = a[0];
                    for (int i = 0; i < 5; i++)
                    {
                        sum += a[i + 1];
                        if (max < a[i + 1])
                        {
                            max = a[i + 1];
                            t = i + 1;
                        }
                    }
                    switch (t)
                    {
                        case 0: type = "餐饮"; break;
                        case 1: type = "出行"; break;
                        case 2: type = "服饰"; break;
                        case 3: type = "娱乐"; break;
                        case 4: type = "教育"; break;
                        case 5: type = "其他"; break;
                    }

                    List<string> xData = new List<string>() { "餐饮", "出行", "服饰", "娱乐", "教育", "其他" };
                    for(int i=0;i<6;i++)
                    {
                        if(a[i]==0)
                        {
                            xData[i] = "";
                        }
                    }
                    List<int> yData = new List<int>() { 100*food/sum, 100*go / sum,
                                                100*clo/sum, 100*fun/sum, 100*edu/sum, 100*other/sum };
                    chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧 
                    chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。 
                    chart1.Series[0].Points.DataBindXY(xData, yData);

                    string sss = null;
                    sss = "您一个月内在" + type + "上消费最多，占比约" + (float)max * (float)100.0 / (float)sum + "%";

                    string ss = "餐饮消费：" + food.ToString() + '\n' + "出行消费：" + go.ToString() + '\n' +
                                 "服饰消费：" + clo.ToString() + '\n' + "娱乐消费：" + fun.ToString() + '\n' +
                                 "教育消费：" + edu.ToString() + '\n' + "其他消费：" + other.ToString() + "\n\n";
                    if (sum > 0)
                    {
                        ss += sss;
                    }
                    label3.Text = ss;

                }



            }

        }

    }
}

