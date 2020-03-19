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
    public partial class Form1 : Form
    {
        private CajaService _cajaService = new CajaService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nroCaja = txtNroCaja.Text;

            List<Caja> cajas = new List<Caja>();

            if(string.IsNullOrEmpty(nroCaja))
            {
                cajas = _cajaService.getAll();
            }
            else
            {
                int id_caja = 0;
                if(int.TryParse(nroCaja, out id_caja))
                {
                    Caja caja = _cajaService.getById(id_caja);
                    
                    if(caja != null)
                    {
                        cajas.Add(caja);
                    }
                }
            }

            if(cajas.Count > 0)
            {
                grdCajas.DataSource = cajas;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            mostrarForm(new frmNuevaCaja());
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
    }
}
