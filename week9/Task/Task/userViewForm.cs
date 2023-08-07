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
    public partial class userViewForm : Form
    {
        private string path =  "data.txt";
        public userViewForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MUser user = (MUser)dataGridView1.CurrentRow.DataBoundItem;
            if(dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                MUserDL.deleteUserFromList(user);
                MUserDL.storeDataInFile(path , user);
                dataBind();
            }
            else if (dataGridView1.Columns["Edit"].Index == e.ColumnIndex)
            {
                EditUserForm edit = new EditUserForm();
                edit.ShowDialog();
                MUserDL.storeDataInFile(path, user);
                dataBind();
            }
        }

        private void userViewForm_Load(object sender, EventArgs e)
        {
            MUserDL.readData(path);
            dataGridView1.DataSource = MUserDL.Users;
        }
        public void dataBind()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MUserDL.Users;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUser user = new MUser();
            AddUserForm myForm = new AddUserForm();
            myForm.ShowDialog();
            MUserDL.storeDataInFile(path , user);
            dataBind();
        }
    }
}
