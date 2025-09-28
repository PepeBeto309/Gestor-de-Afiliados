using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Gestor_de_Afiliados
{
    public partial class frmGesorAfiliados : Form
    {
        List<string> encabezadoColumnas;

        public frmGesorAfiliados()
        {
            InitializeComponent();
            encabezadoColumnas = new List<string>();
            encabezadoColumnas.Add("ID");
            encabezadoColumnas.Add("Entidad");
            encabezadoColumnas.Add("Ciudad");
            encabezadoColumnas.Add("Nombre");
            encabezadoColumnas.Add("Fecha de Afiliacion");
            encabezadoColumnas.Add("Estatus");
        }

    }

}
