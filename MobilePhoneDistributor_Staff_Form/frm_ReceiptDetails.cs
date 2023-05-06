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
    public partial class frm_ReceiptDetails : Form
    {
        private readonly string ReceiptId;
        private ModelDbContext _context;
        private bool AddOrEdit;
        public frm_ReceiptDetails(string receiptId)
        {
            InitializeComponent();
            ReceiptId = receiptId;
        }

        private void frm_ReceiptDetails_Load(object sender, EventArgs e)
        {
            load_Form();
        }
        private void load_Form()
        {
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;
            textBoxID.Enabled = false;
            textBoxPhone.Enabled = false;
            using (_context = new ModelDbContext())
            {
                List<ReceiptDetail> l = new List<ReceiptDetail>();
                l = _context.ReceiptsDetail.Where(i=>i.ReceiptId==ReceiptId).ToList();
                DataTable dt = new DataTable();
                dt = ReceiptDetail.GetDataTable();

                foreach (ReceiptDetail item in l)
                {
                    dt.Rows.Add(Convert.ToString(item.ReceiptDetailId),item.ReceiptId, item.PhoneModelId, Convert.ToString(item.Quantity), Convert.ToString(item.UnitAmmount) );
                }
                dataGridViewDetailDisplay.DataSource = dt;

                

                dt = PhoneModel.GetDataTable();

                foreach (PhoneModel p in _context.PhoneModels)
                {
                    dt.Rows.Add(p.PhoneId,p.PhoneName,p.PhoneBrand);
                }
                dataGridViewPhone.DataSource = dt;
            };
        }

        private void dataGridViewDetailDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDetailDisplay.Rows.Count > 0)
            {
                using (DataGridViewRow curRow = dataGridViewDetailDisplay.CurrentRow)
                {
                    textBoxID.Text = curRow.Cells[1].Value.ToString();
                    textBoxPhone.Text = curRow.Cells[2].Value.ToString();
                    textBoxQuantity.Text = curRow.Cells[3].Value.ToString();
                    textBoxUnit.Text = curRow.Cells[4].Value.ToString();
                }
                buttonSave.Enabled = true;
                buttonDelete.Enabled = true;
                buttonUpdate.Enabled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddOrEdit = true;
            dataGridViewPhone.Focus();

            textBoxQuantity.Enabled = true;
            textBoxUnit.Enabled = true;

            buttonSave.Enabled = true;
            buttonDelete.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (AddOrEdit)
            {
                using (_context = new ModelDbContext())
                {
                    ReceiptDetail goodImportReceiptDetail = new ReceiptDetail()
                    {
                        PhoneModelId = textBoxPhone.Text,
                        ReceiptId = this.ReceiptId,
                        Quantity = Convert.ToInt32(textBoxQuantity.Text),
                        UnitAmmount =Convert.ToDouble(textBoxUnit.Text) ,
                    };
                    _context.ReceiptsDetail.Add(goodImportReceiptDetail);
                    _context.SaveChanges();
                }
            }
            else
            {
                using (_context = new ModelDbContext())
                {
                    if (dataGridViewDetailDisplay.Rows.Count > 0)
                    {
                        int id;
                        using (DataGridViewRow curRow = dataGridViewDetailDisplay.CurrentRow)
                        {
                            id = Convert.ToInt32(curRow.Cells[0].Value);
                        }
                        ReceiptDetail updateDetails = _context.ReceiptsDetail.Where(i => i.ReceiptDetailId == id).FirstOrDefault();
                        updateDetails.Quantity = Convert.ToInt32(textBoxQuantity.Text);
                        updateDetails.UnitAmmount = Convert.ToDouble(textBoxUnit.Text);
                        _context.SaveChanges();
                    }
                }
            }
            load_Form();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            load_Form();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this Detail ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int deleteReceipt =Int32.Parse(dataGridViewDetailDisplay.CurrentRow.Cells[0].Value.ToString());
                using (_context = new ModelDbContext())
                {
                    ReceiptDetail deletedReceipt = (from i in _context.ReceiptsDetail where (i.ReceiptDetailId == deleteReceipt) select i).FirstOrDefault();
                    _context.ReceiptsDetail.Remove(deletedReceipt);
                    _context.SaveChanges();
                }
                load_Form();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AddOrEdit = false;


            buttonSave.Enabled = true;
            buttonDelete.Enabled = false;
        }

        private void textBoxFindOnProduct_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = ReceiptDetail.GetDataTable();
                string value = textBoxFindOnProduct.Text;
                using (_context = new ModelDbContext())
                {
                    List<ReceiptDetail> list = new List<ReceiptDetail>();
                    list = (from i in _context.ReceiptsDetail where (i.PhoneModelId.Contains(value)) select i).ToList();
                    foreach (ReceiptDetail detail in list)
                    {
                        dt.Rows.Add(detail.ReceiptDetailId,detail.ReceiptId, detail.PhoneModelId, Convert.ToString(detail.Quantity), detail.UnitAmmount);
                    }
                }
                dataGridViewDetailDisplay.DataSource = dt;
            }
        }

        private void dataGridViewPhone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewPhone.Rows.Count > 0)
            {
                buttonAdd.Enabled = true;
                using (DataGridViewRow curRow = dataGridViewPhone.CurrentRow)
                {
                    
                    textBoxPhone.Text = curRow.Cells[0].Value.ToString();
                }
                buttonSave.Enabled = true;
                buttonDelete.Enabled = true;
                buttonUpdate.Enabled = true;
            }
        }
    }
}
