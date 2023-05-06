using MobilePhoneDistributor_Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilePhoneDistributor_Staff_Form
{
    public partial class frm_DetailOrder : Form
    {
        private string orderid;
        public frm_DetailOrder(string _orderid)
        {
            InitializeComponent();
            this.orderid = _orderid;
        }

        private void frm_DetailOrder_Load(object sender, EventArgs e)
        {
            using (ModelDbContext db = new ModelDbContext())
            {
                DataTable dt = OrderDetail.GetDataTable();
                var details = db.OrdersDetail.Where(i=>i.OrderId==this.orderid).ToList();
                foreach (var i in details)
                {
                    i.PhoneModel = db.PhoneModels.Where(p=>p.PhoneId==i.PhoneModelId).FirstOrDefault();
                }
                foreach (var i in details)
                {
                    dt.Rows.Add(i.OrderDetailId,i.OrderId,i.PhoneModelId,i.PhoneModel.PhoneName,i.Quantity.ToString());
                }
                dataGridView1.DataSource = dt;
            };
            

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
