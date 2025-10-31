using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCasagrandeAgendadeActividades
{
    public partial class frmActividades : Form
    {
        public frmActividades()
        {
            InitializeComponent();
        }
        private void frmActividades_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsConexion clsConexionBD = new clsConexion();
            clsConexionBD.ConectarBD();
            clsConexionBD.AgregarABase(txtActividad.Text, Convert.ToDateTime( dtpFecha.Text) , txtObservacion.Text);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtActividad.Text = "";
            txtObservacion.Text = "";

        }
    }
}
