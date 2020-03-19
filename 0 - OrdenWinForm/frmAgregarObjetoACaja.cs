using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenWinForm
{
    public partial class frmAgregarObjetoACaja : Form
    {
        private Caja caja;
        private Objeto objetoActual;

        private frmAgregarObjetoACaja()
        {
            InitializeComponent();
        }

        public frmAgregarObjetoACaja(Caja caja)
        {
            InitializeComponent();
            this.caja = caja;
            lblCaja.Text = "Objetos de caja " + caja.nombre;

            grdObjetos.DataSource = caja.Objeto;
        }

        private void frmAgregarObjetoACaja_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Objeto objetoNuevo = new Objeto();

            objetoNuevo.nombre = txtNombre.Text;
            objetoNuevo.descripcion = txtDescripcion.Text;
        }
    }
}
