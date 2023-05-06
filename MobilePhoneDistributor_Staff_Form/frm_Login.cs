using MobilePhoneDistributor_Web.Models;
using MobilePhoneDistributor_Web.Controllers;
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
    public partial class frm_Login : Form
    {
        private ModelDbContext _context;
        public frm_Login()
        {
            _context = new ModelDbContext();
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
        public string id { get; private set; }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username= textBoxUsername.Text;
            string password = textBoxPassword.Text;
            Staff staff = _context.Staffs.Where(i=>i.Username==username).FirstOrDefault();
            if(staff != null)
            {
                if (PasswordHasher.ValidatePassword(password, staff.Password, staff.PasswordSalt))
                {
                    this.id = staff.StaffId;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            
            }
            else
            {
                MessageBox.Show("Invalid username");
            }
            
        }
    }
}
