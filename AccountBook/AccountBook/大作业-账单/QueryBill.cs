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
    public partial class QueryBill : Form
    {
        DBservice db = new DBservice();
        public QueryBill()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Queryfromtype(comboBox1.Text,this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                db.Queryformoutorin("收入",this);
            }
            if (radioButton2.Checked)
            {
                db.Queryformoutorin("支出", this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.Queryfromdata(dateTimePicker1.Value.Date,this);
        }
    }
}
