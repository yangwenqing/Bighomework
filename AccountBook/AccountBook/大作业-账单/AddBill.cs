using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillManagementGUI
{
    public partial class AddBill : Form
    {
        Form1 form1;
        DBservice db = new DBservice();
        public AddBill()
        {
            InitializeComponent();
            label1.Text = "请选择收入类型：";
        }
        public AddBill(Form1 form1)
        {
            InitializeComponent();
            label1.Text = "请选择收入类型：";
            this.form1 = form1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "请选择消费类型：";
            comboBox2.Visible = true;
            comboBox1.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "请选择收入类型：";
            comboBox1.Visible = true;
            comboBox2.Visible = false;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBill_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                DialogResult result = MessageBox.Show("记录不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string s;
                DateTime time = DateTime.Now.Date;
                if (radioButton1.Checked)
                {
                    s = "收入";
                    db.AddBill(s, comboBox1.Text, textBox2.Text, textBox1.Text, time, form1);

                }
                if (radioButton2.Checked)
                {
                    s = "支出";
                    db.AddBill(s, comboBox2.Text, textBox2.Text, textBox1.Text, time, form1);
                }

                this.DialogResult = DialogResult.OK;
                MessageBox.Show("添加成功");
                this.Close();
            }

        }
    }
}
