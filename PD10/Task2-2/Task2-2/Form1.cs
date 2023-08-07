using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = MuserDL.search(txtName.Text);
            if(flag == true)
            {
                MessageBox.Show("User exist");
            }           
            else
            {
                MessageBox.Show("User does not exist");

            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
