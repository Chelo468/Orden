using Modelo;
using Servicios;
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
    public partial class frmNuevaCaja : Form
    {
        private CajaService _cajaService = new CajaService();
        private int id_caja = 0;
        private Caja cajaActual;

        public frmNuevaCaja()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Caja caja = new Caja();

                caja.nombre = txtNombre.Text;
                caja.modulo = txtModulo.Text;
                caja.estante = txtEstante.Text;
                caja.descripcion = txtDescripcion.Text;

                id_caja = _cajaService.create(caja);

                cajaActual = caja;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurri{o un error al crear la caja. " + ex.ToString());
            }
            
        }

        private void mostrarForm(Form formAMostrar)
        {
            this.Hide();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            formAMostrar.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            formAMostrar.StartPosition = FormStartPosition.CenterScreen;
            formAMostrar.MinimumSize = formAMostrar.Size;
            formAMostrar.MaximumSize = formAMostrar.Size;
            formAMostrar.ShowDialog();
            this.Show();
        }

        private void btnAgregarObjetos_Click(object sender, EventArgs e)
        {
            Caja caja = new Caja();
            
            caja = _cajaService.getById(id_caja);

            mostrarForm(new frmAgregarObjetoACaja(caja));
        }
    }
}
