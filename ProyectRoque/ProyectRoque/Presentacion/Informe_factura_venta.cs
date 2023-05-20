using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectRoque.Presentacion
{
    public partial class Informe_factura_venta : Form
    {
        public Informe_factura_venta()
        {
            InitializeComponent();
        }
        public DataSet nuevo;
       

        private void Informe_factura_venta_Load(object sender, EventArgs e)
        {
            Negocios.CrystalReport1 Imprimir = new Negocios.CrystalReport1();//se crea un objeto 
            Imprimir.SetDataSource(nuevo);           
            crystalReportViewer1.ReportSource = Imprimir;


        }
    }
}
