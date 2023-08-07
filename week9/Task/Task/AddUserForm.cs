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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUser updated = new MUser(txtUsername.Text, txtPassword.Text, txtRole.Text);
            MUserDL.storeDataInList(updated);
            this.Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
