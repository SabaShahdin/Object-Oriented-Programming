using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task.BL;

namespace Task
{
    public partial class EditUserForm : Form
    {
        private MUser previous;
        public EditUserForm(MUser previous )
        {
            InitializeComponent();
            this.previous = previous;
        }

        public EditUserForm()
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = previous.Name;
            txtPassword.Text = previous.Password;
            txtRole.Text = previous.Role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUser updated = new MUser(txtUsername.Text, txtPassword.Text, txtRole.Text);
            MUserDL.EditUserFromList(previous, updated);
            this.Close();
        }
    }
}
