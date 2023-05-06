using MobilePhoneDistributor_Web.Controllers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MobilePhoneDistributor_Staff_Form
{
    public partial class frm_Main : Form
    {
        
        public frm_Main()
        {
            InitializeComponent();
        }
        private ModelDbContext _context;
        private string _id;
        private void Form1_Load(object sender, EventArgs e)
        {
            frm_Login login_Frm = new frm_Login();
            login_Frm.ShowDialog();
            _id = login_Frm.id;
            load_MainForm();
        }
        private void load_MainForm()
        {
            buttonSave.Enabled = false;
            textBoxID.Enabled = false;
            buttonDelete.Enabled = false;
            buttonDetail.Enabled = false;
            dateTimePickerDate.Enabled = false;
            DataTable dt = new DataTable();
            dt = Receipt.GetDataTable();
            Receipt receipt = new Receipt();
            using (_context = new ModelDbContext())
            {
                foreach (var i in _context.Receipts)
                {
                    dt.Rows.Add(i.ReceiptId, i.ReceiptDate, i.StaffId);
                }
            }

            dataGridViewReceipt.DataSource = dt;
        }
        private bool AddOrEdit;
       
       
       
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AddOrEdit = false;
            textBoxStaff.Clear();
            textBoxStaff.Focus();
            buttonSave.Enabled = true;
        }
        private void dateTimePickerFind_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedValue = dateTimePickerFind.Value;
            DataTable dt = new DataTable();
            dt = Receipt.GetDataTable();
            using (_context = new ModelDbContext())
            {
                List<Receipt> list = new List<Receipt>();
                list = (from i in _context.Receipts.ToList() where (i.ReceiptDate.Date == selectedValue.Date) select i).ToList();
                foreach (Receipt i in list)
                {
                    dt.Rows.Add(i.ReceiptId, i.ReceiptDate, i.StaffId);
                }
            }
            dataGridViewReceipt.DataSource = dt;
        }

        private void buttonReload_Click_1(object sender, EventArgs e)
        {
            load_MainForm();
        }

        private void dataGridViewReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewReceipt.Rows.Count > 0)
            {
                using (DataGridViewRow currRow = dataGridViewReceipt.CurrentRow)
                {
                    textBoxID.Text = currRow.Cells[0].Value.ToString().Trim();
                    dateTimePickerDate.Text = currRow.Cells[1].Value.ToString();
                    textBoxStaff.Text = currRow.Cells[2].Value.ToString().Trim();
                }
                buttonDelete.Enabled = true;
                buttonDetail.Enabled = true;
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            textBoxStaff.Focus();
            buttonSave.Enabled = true;
            AddOrEdit = true;
            textBoxID.Clear();
            textBoxStaff.Clear();
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this Receipt ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteReceipt = textBoxID.Text;
                using (_context = new ModelDbContext())
                {
                    Receipt deletedReceipt = (from i in _context.Receipts where (i.ReceiptId == deleteReceipt) select i).FirstOrDefault();
                    _context.Receipts.Remove(deletedReceipt);
                    _context.SaveChanges();
                }
                load_MainForm();
            }
        }

        private void textBoxFind_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Receipt.GetDataTable();
            if (e.KeyCode == Keys.Enter)
            {
                string value = textBoxFind.Text;
                using (_context = new ModelDbContext())
                {
                    List<Receipt> list = new List<Receipt>();
                    list = (from i in _context.Receipts where (i.StaffId.Contains(value)) select i).ToList();
                    foreach (Receipt i in list)
                    {
                        dt.Rows.Add(i.ReceiptId, i.ReceiptDate, i.StaffId);
                    }
                }
            }
            dataGridViewReceipt.DataSource = dt;
        }

       

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (AddOrEdit)
            {
                using (_context = new ModelDbContext())
                {
                    Receipt latestReceipt = (from i in _context.Receipts orderby i.ReceiptId descending select i)?.FirstOrDefault();
                    Receipt addedReceipt = new Receipt()
                    {
                        ReceiptId = General.GenerateReceiptId(latestReceipt),
                        ReceiptDate = DateTime.Now,
                        StaffId = this._id,
                    };

                    _context.Receipts.Add(addedReceipt);
                    _context.SaveChanges();
                };
            }
           
            load_MainForm();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            using (DataGridViewRow curRow = dataGridViewReceipt.CurrentRow)
            {
                frm_ReceiptDetails formDetail = new frm_ReceiptDetails(curRow.Cells[0].Value.ToString());
                formDetail.Show();
            };
        }

        private void deliveryNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DeliveryNotes frm_DeliveryNotes = new Frm_DeliveryNotes();
            frm_DeliveryNotes.Show();
        }
    }
}
