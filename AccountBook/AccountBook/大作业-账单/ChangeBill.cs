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
    public partial class ChangeBill : Form
    {
        DBservice db = new DBservice();
        Form1 form1;
        public ChangeBill()
        {
            InitializeComponent();
        }
        public ChangeBill(Form1 form1):this()
        {
            this.form1 = form1;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ChangeBill_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("记录不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string[] n = db.ReviseBill1(textBox1.Text);
                label4.Text = n[3];
                label6.Text = n[2];
                textBox2.Text = n[5];
                textBox3.Text = n[4];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            db.ReviseBill2(textBox1.Text, textBox2.Text, textBox3.Text, form1);

            this.DialogResult = DialogResult.OK;
            MessageBox.Show("修改成功");
            this.Close();
        }
    }
}
