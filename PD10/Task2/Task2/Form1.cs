using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBind();
            MuserDL.Add();
            dataGrid1.DataSource = MuserDL.user;
        }
        private void DataBind()
        {
            this.Refresh();
        }

        private void dataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                Muser users = (Muser)dataGrid1.CurrentRow.DataBoundItem;
                MuserDL.deleteUserFromlist(users);
                dataGrid1.DataSource = null;
            dataGrid1.DataSource = MuserDL.user;
            dataGrid1.Refresh();
        }

        private void btnClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          

        }
    }
}
