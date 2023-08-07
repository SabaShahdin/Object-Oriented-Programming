using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> student = new List<Student>();
            student.Add(new Student() { Id = 89, Name = "Saba", Registration = "89" });
            student.Add(new Student() { Id = 87, Name = "Sana", Registration = "67" });
            student.Add(new Student() { Id = 98, Name = "Sara", Registration = "9" });
            dataGridView1.DataSource= student;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       
    }
}
