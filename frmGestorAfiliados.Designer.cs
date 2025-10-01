using System;

namespace Gestor_de_Afiliados
{
    partial class frmGesorAfiliados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGesorAfiliados));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.txtEstado = new System.Windows.Forms.Label();
            this.cbbEstado = new System.Windows.Forms.ComboBox();
            this.cbbMunicipio = new System.Windows.Forms.ComboBox();
            this.txtMunicipio = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAplicarOrdenamiento = new System.Windows.Forms.Button();
            this.rbOrdenFechaD = new System.Windows.Forms.RadioButton();
            this.rbOrdenFechaA = new System.Windows.Forms.RadioButton();
            this.rbOrdenID = new System.Windows.Forms.RadioButton();
            this.txtOrdenar = new System.Windows.Forms.Label();
            this.dgvTablaAfiliados = new System.Windows.Forms.DataGridView();
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarArchivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwCargarDatos = new System.ComponentModel.BackgroundWorker();
            this.bgwFiltrarDatos = new System.ComponentModel.BackgroundWorker();
            this.bgwOrdenarDatos = new System.ComponentModel.BackgroundWorker();
            this.stsEstadoFunciones = new System.Windows.Forms.StatusStrip();
            this.prgEstatus = new System.Windows.Forms.ToolStripProgressBar();
            this.sslEstadoArchivos = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAfiliados)).BeginInit();
            this.mnsMenu.SuspendLayout();
            this.stsEstadoFunciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTablaAfiliados);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 512);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnAplicarFiltro);
            this.splitContainer2.Panel1.Controls.Add(this.btnCargarArchivo);
            this.splitContainer2.Panel1.Controls.Add(this.txtEstado);
            this.splitContainer2.Panel1.Controls.Add(this.cbbEstado);
            this.splitContainer2.Panel1.Controls.Add(this.cbbMunicipio);
            this.splitContainer2.Panel1.Controls.Add(this.txtMunicipio);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(303, 512);
            this.splitContainer2.SplitterDistance = 271;
            this.splitContainer2.TabIndex = 4;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltro.Location = new System.Drawing.Point(16, 198);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(262, 34);
            this.btnAplicarFiltro.TabIndex = 5;
            this.btnAplicarFiltro.Text = "Apliacar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = true;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.Location = new System.Drawing.Point(16, 88);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(262, 32);
            this.btnCargarArchivo.TabIndex = 4;
            this.btnCargarArchivo.Text = "Cargar Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // txtEstado
            // 
            this.txtEstado.AutoSize = true;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(12, 33);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(76, 20);
            this.txtEstado.TabIndex = 3;
            this.txtEstado.Text = "Estado :";
            // 
            // cbbEstado
            // 
            this.cbbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbEstado.FormattingEnabled = true;
            this.cbbEstado.Location = new System.Drawing.Point(16, 56);
            this.cbbEstado.Name = "cbbEstado";
            this.cbbEstado.Size = new System.Drawing.Size(262, 26);
            this.cbbEstado.TabIndex = 0;
            // 
            // cbbMunicipio
            // 
            this.cbbMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMunicipio.FormattingEnabled = true;
            this.cbbMunicipio.Location = new System.Drawing.Point(16, 166);
            this.cbbMunicipio.Name = "cbbMunicipio";
            this.cbbMunicipio.Size = new System.Drawing.Size(262, 26);
            this.cbbMunicipio.TabIndex = 2;
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.AutoSize = true;
            this.txtMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMunicipio.Location = new System.Drawing.Point(12, 143);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(94, 20);
            this.txtMunicipio.TabIndex = 1;
            this.txtMunicipio.Text = "Municipio :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnAplicarOrdenamiento);
            this.panel1.Controls.Add(this.rbOrdenFechaD);
            this.panel1.Controls.Add(this.rbOrdenFechaA);
            this.panel1.Controls.Add(this.rbOrdenID);
            this.panel1.Controls.Add(this.txtOrdenar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 237);
            this.panel1.TabIndex = 0;
            // 
            // btnAplicarOrdenamiento
            // 
            this.btnAplicarOrdenamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarOrdenamiento.Location = new System.Drawing.Point(16, 171);
            this.btnAplicarOrdenamiento.Name = "btnAplicarOrdenamiento";
            this.btnAplicarOrdenamiento.Size = new System.Drawing.Size(262, 34);
            this.btnAplicarOrdenamiento.TabIndex = 6;
            this.btnAplicarOrdenamiento.Text = "Apliacar Ordenamiento";
            this.btnAplicarOrdenamiento.UseVisualStyleBackColor = true;
            this.btnAplicarOrdenamiento.Click += new System.EventHandler(this.btnAplicarOrdenamiento_Click);
            // 
            // rbOrdenFechaD
            // 
            this.rbOrdenFechaD.AutoSize = true;
            this.rbOrdenFechaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOrdenFechaD.Location = new System.Drawing.Point(16, 128);
            this.rbOrdenFechaD.Name = "rbOrdenFechaD";
            this.rbOrdenFechaD.Size = new System.Drawing.Size(189, 24);
            this.rbOrdenFechaD.TabIndex = 9;
            this.rbOrdenFechaD.Text = "Fecha Descendente";
            this.rbOrdenFechaD.UseVisualStyleBackColor = true;
            // 
            // rbOrdenFechaA
            // 
            this.rbOrdenFechaA.AutoSize = true;
            this.rbOrdenFechaA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOrdenFechaA.Location = new System.Drawing.Point(16, 98);
            this.rbOrdenFechaA.Name = "rbOrdenFechaA";
            this.rbOrdenFechaA.Size = new System.Drawing.Size(178, 24);
            this.rbOrdenFechaA.TabIndex = 8;
            this.rbOrdenFechaA.Text = "Fecha Ascendente";
            this.rbOrdenFechaA.UseVisualStyleBackColor = true;
            // 
            // rbOrdenID
            // 
            this.rbOrdenID.AutoSize = true;
            this.rbOrdenID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOrdenID.Location = new System.Drawing.Point(16, 68);
            this.rbOrdenID.Name = "rbOrdenID";
            this.rbOrdenID.Size = new System.Drawing.Size(147, 24);
            this.rbOrdenID.TabIndex = 7;
            this.rbOrdenID.Text = "Ordenar por ID";
            this.rbOrdenID.UseVisualStyleBackColor = true;
            // 
            // txtOrdenar
            // 
            this.txtOrdenar.AutoSize = true;
            this.txtOrdenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdenar.Location = new System.Drawing.Point(12, 29);
            this.txtOrdenar.Name = "txtOrdenar";
            this.txtOrdenar.Size = new System.Drawing.Size(110, 20);
            this.txtOrdenar.TabIndex = 2;
            this.txtOrdenar.Text = "Ordenar por:";
            // 
            // dgvTablaAfiliados
            // 
            this.dgvTablaAfiliados.AllowUserToAddRows = false;
            this.dgvTablaAfiliados.AllowUserToDeleteRows = false;
            this.dgvTablaAfiliados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTablaAfiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaAfiliados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTablaAfiliados.Location = new System.Drawing.Point(0, 0);
            this.dgvTablaAfiliados.Name = "dgvTablaAfiliados";
            this.dgvTablaAfiliados.Size = new System.Drawing.Size(877, 512);
            this.dgvTablaAfiliados.TabIndex = 0;
            // 
            // mnsMenu
            // 
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.operacionesToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(1184, 24);
            this.mnsMenu.TabIndex = 1;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarArchivosToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // importarArchivosToolStripMenuItem
            // 
            this.importarArchivosToolStripMenuItem.Name = "importarArchivosToolStripMenuItem";
            this.importarArchivosToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.importarArchivosToolStripMenuItem.Text = "Importar &Archivos";
            this.importarArchivosToolStripMenuItem.Click += new System.EventHandler(this.importarArchivosToolStripMenuItem_Click);
            // 
            // stsEstadoFunciones
            // 
            this.stsEstadoFunciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgEstatus,
            this.sslEstadoArchivos});
            this.stsEstadoFunciones.Location = new System.Drawing.Point(0, 539);
            this.stsEstadoFunciones.Name = "stsEstadoFunciones";
            this.stsEstadoFunciones.Size = new System.Drawing.Size(1184, 22);
            this.stsEstadoFunciones.TabIndex = 7;
            this.stsEstadoFunciones.Text = "statusStrip1";
            // 
            // prgEstatus
            // 
            this.prgEstatus.Name = "prgEstatus";
            this.prgEstatus.Size = new System.Drawing.Size(100, 16);
            this.prgEstatus.Visible = false;
            // 
            // sslEstadoArchivos
            // 
            this.sslEstadoArchivos.Name = "sslEstadoArchivos";
            this.sslEstadoArchivos.Size = new System.Drawing.Size(74, 17);
            this.sslEstadoArchivos.Text = "InfoArchivos";
            // 
            // frmGesorAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.stsEstadoFunciones);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnsMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "frmGesorAfiliados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Afiliados (PaRtIdo politico)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAfiliados)).EndInit();
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.stsEstadoFunciones.ResumeLayout(false);
            this.stsEstadoFunciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTablaAfiliados;
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarArchivosToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbbMunicipio;
        private System.Windows.Forms.ComboBox cbbEstado;
        private System.Windows.Forms.Label txtMunicipio;
        private System.Windows.Forms.Label txtEstado;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtOrdenar;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.RadioButton rbOrdenFechaD;
        private System.Windows.Forms.RadioButton rbOrdenFechaA;
        private System.Windows.Forms.RadioButton rbOrdenID;
        private System.ComponentModel.BackgroundWorker bgwCargarDatos;
        private System.Windows.Forms.Button btnAplicarOrdenamiento;
        private System.ComponentModel.BackgroundWorker bgwFiltrarDatos;
        private System.ComponentModel.BackgroundWorker bgwOrdenarDatos;
        private System.Windows.Forms.StatusStrip stsEstadoFunciones;
        private System.Windows.Forms.ToolStripProgressBar prgEstatus;
        private System.Windows.Forms.ToolStripStatusLabel sslEstadoArchivos;
    }
}

