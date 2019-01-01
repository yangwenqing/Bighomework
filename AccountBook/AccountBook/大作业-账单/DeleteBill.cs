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
    public partial class DeleteBill : Form
    {
        Form1 form1;
        DBservice db = new DBservice();
        public DeleteBill(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
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
                int a = Int32.Parse(textBox1.Text);
                db.DeleteBill(a, form1);

                this.DialogResult = DialogResult.OK;
                MessageBox.Show("删除成功");
                this.Close();
            }
         }
    }
}
