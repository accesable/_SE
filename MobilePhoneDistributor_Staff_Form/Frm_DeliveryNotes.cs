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
using System.Windows.Forms.VisualStyles;

namespace MobilePhoneDistributor_Staff_Form
{
    public partial class Frm_DeliveryNotes : Form
    {
        private ModelDbContext _context;
        public Frm_DeliveryNotes()
        {
            InitializeComponent();
        }

        private void Frm_DeliveryNotes_Load(object sender, EventArgs e)
        {
            loadForm();
        }
        private void loadForm()
        {
            buttonAdd.Enabled = false;
            textBoxID.Enabled = false;
            buttonDelete.Enabled = false;
            buttonDetail.Enabled = false;
            dateTimePickerDate.Enabled = false;
            DataTable dt;
            dt = Order.GetDataTable();
            DataTable dt2 = DeliveryNote.GetDataTable();
            using (_context = new ModelDbContext())
            {
                foreach (var i in _context.Orders)
                {
                    dt.Rows.Add(i.OrderId, i.OrderDate, i.AgentId,i.OrderStatus,i.PaymentMethod,i.PaymentStatus);
                }
                foreach (var i in _context.DeliveryNotes)
                {
                    dt2.Rows.Add(i.DeliveryNoteId,i.DeliveryDate,i.OrderId);
                }
            }
            

            dataGridViewOrder.DataSource = dt;
            dataGridView1.DataSource = dt2;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string Order = textBoxID.Text.Trim();
            using (_context = new ModelDbContext())
            {
                Order order= _context.Orders.Where(i=>i.OrderId==Order).FirstOrDefault();
                if(order.OrderStatus == "On Delivering")
                {
                    MessageBox.Show($"Delivery Note Of Order ID {Order} Already exist");
                }
                else
                {
                    
                    order.OrderStatus = "On Delivering";
                    DeliveryNote note = new DeliveryNote()
                    {
                        DeliveryNoteId = Order.Substring(0, 6) + "DN" + Order.Substring(7),
                        DeliveryDate = DateTime.Now,
                        OrderId = Order
                    };
                    _context.DeliveryNotes.Add(note);
                    _context.SaveChanges();
                }

            }
            loadForm();
        }

        private void dataGridViewOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewOrder.Rows.Count > 0)
            {
                using (DataGridViewRow currRow = dataGridViewOrder.CurrentRow)
                {
                    textBoxID.Text = currRow.Cells[0].Value.ToString().Trim();
                    dateTimePickerDate.Text = currRow.Cells[1].Value.ToString();
                    textBoxAgent.Text = currRow.Cells[2].Value.ToString().Trim();
                }
                buttonDelete.Enabled = true;
                buttonDetail.Enabled = true;
                buttonAdd.Enabled = true;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>0)
            {
                string note = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                string order = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                if (MessageBox.Show($"Do you want to delete this Note {note}?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (_context = new ModelDbContext())
                    {
                        Order order1 = _context.Orders.Where(i=>i.OrderId == order).FirstOrDefault();
                        order1.OrderStatus = "On Processing";
                        DeliveryNote note1 = _context.DeliveryNotes.Where(i=>i.DeliveryNoteId == note).FirstOrDefault();
                        _context.DeliveryNotes.Remove(note1);
                        _context.SaveChanges();
                    }
                    loadForm();
                }
            }
            
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            string order = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            frm_DetailOrder frm_DetailOrder = new frm_DetailOrder(order);
            frm_DetailOrder.ShowDialog();
            frm_DetailOrder.Dispose();
        }

        private void dateTimePickerFind_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedValue = dateTimePickerFind.Value;
            DataTable dt = new DataTable();
            dt = Order.GetDataTable();
            using (_context = new ModelDbContext())
            {
                List<Order> list = new List<Order>();
                list = (from i in _context.Orders.ToList() where (i.OrderDate.Date == selectedValue.Date) select i).ToList();
                foreach (Order i in list)
                {
                    dt.Rows.Add(i.OrderId, i.OrderDate, i.AgentId, i.OrderStatus, i.PaymentMethod, i.PaymentStatus);
                }
            }
            dataGridViewOrder.DataSource = dt;
        }


        private void textBoxFind_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Order.GetDataTable();
            if (e.KeyCode == Keys.Enter)
            {
                string value = textBoxFind.Text;
                using (_context = new ModelDbContext())
                {
                    List<Order> list = new List<Order>();
                    list = (from i in _context.Orders where (i.AgentId.Contains(value)) select i).ToList();
                    foreach (Order i in list)
                    {
                        dt.Rows.Add(i.OrderId, i.OrderDate, i.AgentId, i.OrderStatus, i.PaymentMethod, i.PaymentStatus);
                    }
                }
            }
            dataGridViewOrder.DataSource = dt;
        }
    }
}
