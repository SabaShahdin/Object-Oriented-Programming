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
    public partial class SignInSignUpApplication : Form
    {
        public SignInSignUpApplication()
        {
            InitializeComponent();
            string path = "User.txt";
            if(UserDL.readData(path))
            {
                MessageBox.Show("Data loaded");
            }
            else
            {
                MessageBox.Show("Data not loaded");
            }
        }

        private void txtSign_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnNext(object sender, EventArgs e)
        {
        }

        private void SignIn(object sender, EventArgs e)
        {

        }

        private void SignUp(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Form moreForm = new SignIn();
                moreForm.Show();
                checkBox1.Checked = false;

            }
            if (checkBox2.Checked)
            {
                Form moreForm = new SignUp();
                moreForm.Show();
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
