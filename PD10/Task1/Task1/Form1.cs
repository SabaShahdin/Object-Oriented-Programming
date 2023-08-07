using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public List<string> property = new List<string>();
        public Form1()
        {
            InitializeComponent();
            property.Add("heelo");
            property.Add("ji");
            property.Add("hi");
        }

        private void cmbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cmbData.SelectedItem.ToString();
            txtBox.Text = selectedValue;
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbData.DataSource = property;
        }
    }
}
