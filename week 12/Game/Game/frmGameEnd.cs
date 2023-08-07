using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class frmGameEnd : Form
    {
        public frmGameEnd(Image backGroundScreen)
        {
            InitializeComponent();
            this.BackgroundImage = backGroundScreen;
        }
       
        private void frmGameEnd_Load(object sender, EventArgs e)
        {

        }
    }
}
