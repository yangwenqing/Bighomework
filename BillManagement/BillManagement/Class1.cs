using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement
{
    class Bill
    {
        private String BillType;//确定种类
        private DateTime BillTime;//账单时间
        private String InorOut;//确定收支
        private double count;//账单金额
        private String Reference;//备注
        public void setBillType(String Type)
        {
            this.BillType = Type;
        }
        public String getBilltype()
        {
            return this.BillType;
        }
        public void setBillTime(DateTime d)
        {
            d = DateTime.Now;
            this.BillTime = d;
        }
        public DateTime getDataTime()
        {
            return this.BillTime;
        }
        public void setInorOut(String s)
        {
            this.InorOut = s;
        }
        public String getInorOut()
        {
            return this.InorOut;
        }
        public void setcount(double d)
        {
            this.count = d;
        }
        public double getcount()
        {
            return this.count;
        }
        public void setReference(String s)
        {
            this.Reference = s;
        }
        public String getReferenc()
        {
            return this.Reference;
        }
    }
}
