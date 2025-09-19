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
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
            clsConexion clsConexionBD = new clsConexion();
            clsConexionBD.ConectarBD();
            clsConexionBD.AgregaraTabla(dgvAgenda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmActividades frm = new frmActividades();
            frm.ShowDialog();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            clsConexion clsConexionBD = new clsConexion();
            clsConexionBD.ConectarBD();
            
        }
    }
}
