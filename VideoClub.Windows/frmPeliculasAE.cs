using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoClub.Windows
{
    public partial class frmPeliculasAE : Form
    {
        public frmPeliculasAE()
        {
            InitializeComponent();
        }



        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPeliculasAE_Load(object sender, EventArgs e)
        {

        }
    }
}
