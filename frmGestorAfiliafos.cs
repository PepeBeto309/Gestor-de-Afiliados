using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Gestor_de_Afiliados
{
    public partial class frmGesorAfiliados : Form
    {
            // Elementos necesarios para la lógica del programa
        private List<string> encabezadoColumnas;
        private Dictionary<string, string> mapaArchivos = new Dictionary<string, string>();
        private const string nombreProgramador = "Jose Alberto Carrillo Torres";
        private DataTable _datosCargados;
        
        private readonly object _lockTabla = new object();
        private Thread _hiloDeCarga;
        private delegate void DelegadoActualizarProgreso(int porcentaje, int registrosActuales, DataTable dtLote);
        private delegate void DelegadoFinalizarCarga(Exception ex);

        private int[] anchosColumnas = { 60, 140, 160, 257, 100, 100 };
        private const int TOTAL_COLUMNAS_REQUERIDAS = 6;

        // Constructor del formulario
        public frmGesorAfiliados()
        {
            InitializeComponent();

            encabezadoColumnas = new List<string>();
            encabezadoColumnas.Add("ID de Afiliacion");
            encabezadoColumnas.Add("Entidad");
            encabezadoColumnas.Add("Municipio");
            encabezadoColumnas.Add("Nombre");
            encabezadoColumnas.Add("Fecha de Afiliacion");
            encabezadoColumnas.Add("Estatus");

            dgvTablaAfiliados.AutoGenerateColumns = true;
        }

        // Eventos de UI/Componentes
            // Cerrar el formulario
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_hiloDeCarga != null && _hiloDeCarga.IsAlive)
            {
                try { _hiloDeCarga.Abort(); } catch { }
            }
            this.Close();
        }

            // Importar carpeta de archivos
        private void importarArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapaArchivos.Clear();
            cbbMunicipio.Items.Clear();

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione la carpeta que contiene los archivos de afiliados";
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string rutafolder = fbd.SelectedPath;
                    CargarEstadosComboBox(rutafolder);
                }
            }
        }

            // Botón Cargar Archivo
        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            if (cbbEstado.SelectedIndex <= 0 || cbbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un archivo de estado válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_hiloDeCarga != null && _hiloDeCarga.IsAlive)
            {
                MessageBox.Show("El proceso de carga ya está en curso.", "Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombreSeleccionadoSinExtension = cbbEstado.SelectedItem.ToString();
            string rutaArchivo;

            string claveCompleta = mapaArchivos.Keys
                                             .FirstOrDefault(k => Path.GetFileNameWithoutExtension(k) == nombreSeleccionadoSinExtension);

            if (claveCompleta != null && mapaArchivos.TryGetValue(claveCompleta, out rutaArchivo))
            {
                _datosCargados = new DataTable();
                foreach (var encabezado in encabezadoColumnas)
                {
                    _datosCargados.Columns.Add(encabezado, typeof(string));
                }

                dgvTablaAfiliados.Columns.Clear();
                dgvTablaAfiliados.DataSource = _datosCargados;

                ConfigurarUI(true, nombreSeleccionadoSinExtension);

                    // Manejo del hilo de carga
                _hiloDeCarga = new Thread(() => HiloCargarDatos(rutaArchivo));
                _hiloDeCarga.IsBackground = true;
                _hiloDeCarga.Start();
            }
            else
            {
                MessageBox.Show("Error: No se encontró la ruta del archivo seleccionado.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            // Botón Aplicar Filtro (Municipio)
        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            if (_datosCargados == null || _datosCargados.Rows.Count == 0)
            {
                MessageBox.Show("Primero debe cargar un archivo con registros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string municipioSeleccionado = cbbMunicipio.SelectedItem.ToString();
            DataView dv = new DataView(_datosCargados);
            string filtro = string.Empty;

            if (municipioSeleccionado == "(Todos)")
            {
                filtro = string.Empty;
            }
            else if (municipioSeleccionado == "No especificado")
            {
                filtro = $"[Municipio] IS NULL OR [Municipio] = ''";
            }
            else
            {
                string valorEscapado = municipioSeleccionado.Replace("'", "''");
                filtro = $"[Municipio] = '{valorEscapado}'";
            }

            try
            {
                dv.RowFilter = filtro;
                dgvTablaAfiliados.DataSource = dv;
                sslEstadoArchivos.Text = $"Filtro aplicado. Registros visibles: {dv.Count:N0}.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el filtro: {ex.Message}", "Error de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dv.RowFilter = string.Empty;
            }
        }

        // Funciones Auxiliares/Logicas
            // Carga de datos en un hilo
        public void HiloCargarDatos(string rutaArchivo)
        {
            ExcelPackage.License.SetNonCommercialPersonal(nombreProgramador);

            Exception error = null;
            int totalRegistros = 0;

            try
            {
                using (var package = new ExcelPackage(new FileInfo(rutaArchivo)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null || worksheet.Dimension == null) return;

                    DataTable dtBase = _datosCargados.Clone();

                    int filaInicial = worksheet.Dimension.Start.Row + 1;
                    int totalFilas = worksheet.Dimension.End.Row;
                    totalRegistros = totalFilas - filaInicial + 1;
                    int totalColumnasRequeridas = TOTAL_COLUMNAS_REQUERIDAS;

                    DataTable dtLote = dtBase.Clone();
                    const int TAMANO_LOTE = 5000;
                    int filasProcesadasDesdeUltimoLote = 0;

                    for (int fila = filaInicial; fila <= totalFilas; fila++)
                    {
                        DataRow nuevaFila = dtLote.NewRow();
                        for (int col = 1; col <= totalColumnasRequeridas; col++)
                        {
                            var celda = worksheet.Cells[fila, col];
                            string valor = celda.Value?.ToString() ?? string.Empty;
                            nuevaFila[col - 1] = valor;
                        }

                        dtLote.Rows.Add(nuevaFila);
                        filasProcesadasDesdeUltimoLote++;

                        if (filasProcesadasDesdeUltimoLote >= TAMANO_LOTE || fila == totalFilas)
                        {
                            int registrosProcesadosTotal = fila - filaInicial + 1;
                            int progreso = (int)(((double)registrosProcesadosTotal / totalRegistros) * 100);

                                // Uso de delegado para actualizar la UI desde el hilo
                            this.Invoke(new DelegadoActualizarProgreso(ActualizarProgresoYDatos),
                                         progreso, registrosProcesadosTotal, dtLote);

                            dtLote = dtBase.Clone();
                            filasProcesadasDesdeUltimoLote = 0;
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
                error = new Exception("Carga cancelada.");
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                    // Finalizacion segura del hilo para evitar errores
                this.Invoke(new DelegadoFinalizarCarga(FinalizarCarga), error);
            }
        }

            // Bloquedo de elementos UI durante la carga
        private void ConfigurarUI(bool inicio, string nombreArchivo = "")
        {
            if (inicio)
            {
                sslEstadoArchivos.Text = $"Cargando {nombreArchivo}... Por favor espere.";
                prgEstatus.Value = 0;
                prgEstatus.Visible = true;
                btnCargarArchivo.Enabled = false;
                cbbEstado.Enabled = false;
                cbbMunicipio.Enabled = false;
                btnAplicarFiltro.Enabled = false;
            }
            else
            {
                prgEstatus.Visible = false;
                btnCargarArchivo.Enabled = true;
                cbbEstado.Enabled = true;
            }
        }

            // Actualizacion del progreso y DataGridView
        private void ActualizarProgresoYDatos(int porcentaje, int registrosActuales, DataTable dtLote)
        {
            prgEstatus.Value = porcentaje;
            sslEstadoArchivos.Text = $"Cargando... Registros actuales: {registrosActuales:N0}. {porcentaje}% completado.";
            
                // Sincronización para escribir en el DataTable
            lock (_lockTabla) 
            {
                foreach (DataRow row in dtLote.Rows)
                {
                    _datosCargados.ImportRow(row);
                }
            }

            dgvTablaAfiliados.Refresh();
        }

            // Manejo de finalización de carga
        private void FinalizarCarga(Exception ex)
        {
            ConfigurarUI(false);

            if (ex != null)
            {
                sslEstadoArchivos.Text = ex is ThreadAbortException ? "Carga cancelada." : "Error durante la carga.";
                if (!(ex is ThreadAbortException))
                {
                    MessageBox.Show($"Ocurrió un error al cargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvTablaAfiliados.DataSource = null;
                _datosCargados = null;
                return;
            }

            if (_datosCargados != null && _datosCargados.Rows.Count > 0)
            {
                int totalRegistros = _datosCargados.Rows.Count;
                sslEstadoArchivos.Text = $"Carga completada. Total de registros: {totalRegistros:N0}.";

                AjustarAnchoColumnas();

                CargarFiltroMunicipios(_datosCargados);
                cbbMunicipio.Enabled = true;
                btnAplicarFiltro.Enabled = true;
            }
            else
            {
                sslEstadoArchivos.Text = "Carga completada. No se encontraron registros.";
                dgvTablaAfiliados.DataSource = null;
            }
        }

            // Ajusta el ancho de las columnas
        private void AjustarAnchoColumnas()
        {
            if (dgvTablaAfiliados.Columns.Count != anchosColumnas.Length)
            {
                MessageBox.Show("Advertencia: El número de columnas no coincide con el arreglo de anchos definidos.",
                                "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < dgvTablaAfiliados.Columns.Count; i++)
            {
                DataGridViewColumn columna = dgvTablaAfiliados.Columns[i];
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                columna.Width = anchosColumnas[i];
            }
        }

            // Busqueda y carga de archivos Excel en el ComboBox de Estados
        private void CargarEstadosComboBox(string rutafolder)
        {
            cbbEstado.Items.Clear();
            mapaArchivos.Clear();
            cbbMunicipio.Items.Clear();

            int contador = 0;
            sslEstadoArchivos.Text = "Buscando archivos...";

            try
            {
                string[] archivosXLSX = System.IO.Directory.GetFiles(rutafolder, "*.xlsx");
                string[] archivosXLS = System.IO.Directory.GetFiles(rutafolder, "*.xls");
                var todosLosArchivos = archivosXLSX.Concat(archivosXLS);

                cbbEstado.Items.Add("");

                foreach (string rutaCompleta in todosLosArchivos)
                {
                    string nombreArchivoCompleto = System.IO.Path.GetFileName(rutaCompleta);
                    string nombreParaComboBox = System.IO.Path.GetFileNameWithoutExtension(rutaCompleta);

                    if (!mapaArchivos.ContainsKey(nombreArchivoCompleto))
                    {
                        mapaArchivos.Add(nombreArchivoCompleto, rutaCompleta);
                        cbbEstado.Items.Add(nombreParaComboBox);
                        contador++;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Archivo duplicado omitido: {nombreArchivoCompleto}");
                    }
                }

                if (contador > 0)
                {
                    cbbEstado.SelectedIndex = 0;
                    MessageBox.Show($"Se cargaron {contador} archivos Excel listos para usar.", "Archivos cargados correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCargarArchivo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron archivos .xlsx o .xls en la carpeta seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCargarArchivo.Enabled = false;
                }
                sslEstadoArchivos.Text = $"Archivos disponibles: {contador}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer la carpeta: {ex.Message}", "Error de E/S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mapaArchivos.Clear();
                cbbEstado.Items.Clear();
                sslEstadoArchivos.Text = "Error al cargar carpeta.";
            }
        }

            // Extraccion de municipios únicos y llena el ComboBox de Municipios
        private void CargarFiltroMunicipios(DataTable dtAfiliados)
        {
            const string nombreColumnaFiltro = "Municipio";
            cbbMunicipio.Items.Clear();

            var municipiosValidos = dtAfiliados.AsEnumerable()
                                              .Select(row => row.Field<string>(nombreColumnaFiltro))
                                              .Where(m => !string.IsNullOrWhiteSpace(m))
                                              .Distinct()
                                              .OrderBy(m => m)
                                              .ToList();

            bool existeNoEspecificado = dtAfiliados.AsEnumerable()
                                                  .Any(row => string.IsNullOrWhiteSpace(row.Field<string>(nombreColumnaFiltro)));

            cbbMunicipio.Items.Add("(Todos)");

            if (municipiosValidos.Any() || existeNoEspecificado)
            {
                if (existeNoEspecificado)
                {
                    cbbMunicipio.Items.Add("No especificado");
                }
                cbbMunicipio.Items.AddRange(municipiosValidos.ToArray());
                cbbMunicipio.SelectedIndex = 0;
            }
            else
            {
                cbbMunicipio.Items.Add("No hay municipios disponibles");
                cbbMunicipio.SelectedIndex = 0;
            }
        }
    }
}