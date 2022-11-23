using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClub.Entidades.Entidades;
using VideoClub.Servicios.Servicios;
using VideoClub.Servicios.Servicios.Facades;
using VideoClub.Windows.Helpers;

namespace VideoClub.Windows
{
    public partial class frmPeliculas : Form
    {
        public frmPeliculas()
        {
            InitializeComponent();
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private IServicioPeliculas servicio;
        private List<Pelicula> lista;

        private void frmPeliculas_Load(object sender, EventArgs e)
        {
            servicio = new ServicioPeliculas();
            try
            {
                lista = servicio.GetLista(null,null, null, null);
                HelperForm.MostrarDatosEnGrilla(DatosDataGridView, lista);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            frmPeliculasAE frm = new frmPeliculasAE { Text = "Nueva Pelicula" };
            DialogResult dr = frm.ShowDialog(this);
            
        }
    }
}
