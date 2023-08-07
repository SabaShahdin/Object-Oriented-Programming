using SignUP.BL;
using SignUP.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignUP
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void ClearDataFromForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSign_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            User user = new User(username, password);
            User valid = UserDL.signIn(user);
            if (valid != null)
            {
                MessageBox.Show("User is valid");
            }
            else
            {
                MessageBox.Show("Invaalid");
            }
            ClearDataFromForm();
        }
    }
}
