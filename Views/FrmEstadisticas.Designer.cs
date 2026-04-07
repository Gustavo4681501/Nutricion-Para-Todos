namespace NutricionApp.Views
{
    partial class FrmEstadisticas
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Releases the unmanaged resources used by the component and optionally releases the managed resources.
        /// </summary>
        /// <remarks>This method is called by the public Dispose() method and the finalizer. When
        /// disposing is true, this method disposes all managed resources referenced by this object. When disposing is
        /// false, only unmanaged resources are released.</remarks>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpHoy = new System.Windows.Forms.GroupBox();
            this.lblHoyFecha = new System.Windows.Forms.Label();
            this.lblHoyConsumo = new System.Windows.Forms.Label();
            this.lblHoyMacros = new System.Windows.Forms.Label();
            this.pbHoy = new System.Windows.Forms.ProgressBar();
            this.lblHoyFalta = new System.Windows.Forms.Label();
            this.grpDiario = new System.Windows.Forms.GroupBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarDiario = new System.Windows.Forms.Button();
            this.dgvDiario = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCumple = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMensual = new System.Windows.Forms.GroupBox();
            this.lblMesLabel = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAnioLabel = new System.Windows.Forms.Label();
            this.numAnio = new System.Windows.Forms.NumericUpDown();
            this.btnBuscarMensual = new System.Windows.Forms.Button();
            this.lblMensualResultado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.grpHoy.SuspendLayout();
            this.grpDiario.SuspendLayout();
            this.grpMensual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            this.SuspendLayout();

            this.grpHoy.Controls.Add(this.lblHoyFalta);
            this.grpHoy.Controls.Add(this.pbHoy);
            this.grpHoy.Controls.Add(this.lblHoyMacros);
            this.grpHoy.Controls.Add(this.lblHoyConsumo);
            this.grpHoy.Controls.Add(this.lblHoyFecha);
            this.grpHoy.Location = new System.Drawing.Point(12, 10);
            this.grpHoy.Name = "grpHoy";
            this.grpHoy.Size = new System.Drawing.Size(960, 130);
            this.grpHoy.TabIndex = 0;
            this.grpHoy.Text = "Resumen de hoy";

            this.lblHoyFecha.AutoSize = true;
            this.lblHoyFecha.Location = new System.Drawing.Point(10, 22);
            this.lblHoyFecha.Name = "lblHoyFecha";
            this.lblHoyFecha.Text = "Hoy:";

            this.lblHoyConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoyConsumo.Location = new System.Drawing.Point(10, 40);
            this.lblHoyConsumo.Name = "lblHoyConsumo";
            this.lblHoyConsumo.Size = new System.Drawing.Size(930, 18);
            this.lblHoyConsumo.Text = "Consumido: — kcal     Meta: — kcal";

            this.lblHoyMacros.Location = new System.Drawing.Point(10, 60);
            this.lblHoyMacros.Name = "lblHoyMacros";
            this.lblHoyMacros.Size = new System.Drawing.Size(930, 18);
            this.lblHoyMacros.Text = "Proteinas: — / —   Carbohidratos: — / —   Grasas: — / —";

            this.pbHoy.Location = new System.Drawing.Point(10, 82);
            this.pbHoy.Name = "pbHoy";
            this.pbHoy.Size = new System.Drawing.Size(930, 16);
            this.pbHoy.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            this.lblHoyFalta.AutoSize = true;
            this.lblHoyFalta.Location = new System.Drawing.Point(10, 103);
            this.lblHoyFalta.Name = "lblHoyFalta";
            this.lblHoyFalta.Text = "--";

            // ── grpDiario ─────────────────────────────────────────────────────
            this.grpDiario.Controls.Add(this.dgvDiario);
            this.grpDiario.Controls.Add(this.btnBuscarDiario);
            this.grpDiario.Controls.Add(this.dtpHasta);
            this.grpDiario.Controls.Add(this.lblHasta);
            this.grpDiario.Controls.Add(this.dtpDesde);
            this.grpDiario.Controls.Add(this.lblDesde);
            this.grpDiario.Location = new System.Drawing.Point(12, 150);
            this.grpDiario.Name = "grpDiario";
            this.grpDiario.Size = new System.Drawing.Size(660, 390);
            this.grpDiario.TabIndex = 1;
            this.grpDiario.Text = "Historial diario (parametrizable por fechas)";

            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(8, 25);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Text = "Desde:";

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(58, 21);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 20);
            this.dtpDesde.TabIndex = 0;

            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(180, 25);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Text = "Hasta:";

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(225, 21);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 20);
            this.dtpHasta.TabIndex = 1;

            this.btnBuscarDiario.Location = new System.Drawing.Point(350, 19);
            this.btnBuscarDiario.Name = "btnBuscarDiario";
            this.btnBuscarDiario.Size = new System.Drawing.Size(80, 26);
            this.btnBuscarDiario.TabIndex = 2;
            this.btnBuscarDiario.Text = "Buscar";
            this.btnBuscarDiario.UseVisualStyleBackColor = true;
            this.btnBuscarDiario.Click += new System.EventHandler(this.btnBuscarDiario_Click);

            this.colFecha.HeaderText = "Fecha"; this.colFecha.Name = "colFecha"; this.colFecha.Width = 85; this.colFecha.ReadOnly = true;
            this.colCal.HeaderText = "Calorias"; this.colCal.Name = "colCal"; this.colCal.Width = 70; this.colCal.ReadOnly = true;
            this.colMeta.HeaderText = "Meta"; this.colMeta.Name = "colMeta"; this.colMeta.Width = 65; this.colMeta.ReadOnly = true;
            this.colPct.HeaderText = "% Cumplido"; this.colPct.Name = "colPct"; this.colPct.Width = 75; this.colPct.ReadOnly = true;
            this.colCumple.HeaderText = "Meta"; this.colCumple.Name = "colCumple"; this.colCumple.Width = 50; this.colCumple.ReadOnly = true;
            this.colProt.HeaderText = "Proteinas"; this.colProt.Name = "colProt"; this.colProt.Width = 75; this.colProt.ReadOnly = true;
            this.colCarb.HeaderText = "Carbohidratos"; this.colCarb.Name = "colCarb"; this.colCarb.Width = 95; this.colCarb.ReadOnly = true;
            this.colGras.HeaderText = "Grasas"; this.colGras.Name = "colGras"; this.colGras.Width = 70; this.colGras.ReadOnly = true;

            this.dgvDiario.AllowUserToAddRows = false;
            this.dgvDiario.AllowUserToDeleteRows = false;
            this.dgvDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFecha, this.colCal, this.colMeta, this.colPct, this.colCumple,
                this.colProt, this.colCarb, this.colGras });
            this.dgvDiario.Location = new System.Drawing.Point(8, 52);
            this.dgvDiario.MultiSelect = false;
            this.dgvDiario.Name = "dgvDiario";
            this.dgvDiario.ReadOnly = true;
            this.dgvDiario.RowHeadersVisible = false;
            this.dgvDiario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiario.Size = new System.Drawing.Size(642, 325);
            this.dgvDiario.TabIndex = 3;


            this.grpMensual.Controls.Add(this.lblMensualResultado);
            this.grpMensual.Controls.Add(this.btnBuscarMensual);
            this.grpMensual.Controls.Add(this.numAnio);
            this.grpMensual.Controls.Add(this.lblAnioLabel);
            this.grpMensual.Controls.Add(this.cmbMes);
            this.grpMensual.Controls.Add(this.lblMesLabel);
            this.grpMensual.Location = new System.Drawing.Point(685, 150);
            this.grpMensual.Name = "grpMensual";
            this.grpMensual.Size = new System.Drawing.Size(287, 390);
            this.grpMensual.TabIndex = 2;
            this.grpMensual.Text = "Resumen mensual";

            this.lblMesLabel.AutoSize = true;
            this.lblMesLabel.Location = new System.Drawing.Point(8, 25);
            this.lblMesLabel.Name = "lblMesLabel";
            this.lblMesLabel.Text = "Mes:";

            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
                "Enero","Febrero","Marzo","Abril","Mayo","Junio",
                "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" });
            this.cmbMes.Location = new System.Drawing.Point(42, 21);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(110, 21);
            this.cmbMes.TabIndex = 0;

            this.lblAnioLabel.AutoSize = true;
            this.lblAnioLabel.Location = new System.Drawing.Point(8, 55);
            this.lblAnioLabel.Name = "lblAnioLabel";
            this.lblAnioLabel.Text = "Anio:";

            this.numAnio.Location = new System.Drawing.Point(50, 51);
            this.numAnio.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numAnio.Name = "numAnio";
            this.numAnio.Size = new System.Drawing.Size(70, 20);
            this.numAnio.TabIndex = 1;
            this.numAnio.Value = new decimal(new int[] { 2025, 0, 0, 0 });

            this.btnBuscarMensual.Location = new System.Drawing.Point(130, 49);
            this.btnBuscarMensual.Name = "btnBuscarMensual";
            this.btnBuscarMensual.Size = new System.Drawing.Size(75, 26);
            this.btnBuscarMensual.TabIndex = 2;
            this.btnBuscarMensual.Text = "Calcular";
            this.btnBuscarMensual.UseVisualStyleBackColor = true;
            this.btnBuscarMensual.Click += new System.EventHandler(this.btnBuscarMensual_Click);

            this.lblMensualResultado.Location = new System.Drawing.Point(8, 85);
            this.lblMensualResultado.Name = "lblMensualResultado";
            this.lblMensualResultado.Size = new System.Drawing.Size(265, 295);
            this.lblMensualResultado.Text = "Selecciona un mes y presiona Calcular.";


            this.btnCerrar.Location = new System.Drawing.Point(840, 555);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 28);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 600);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.grpMensual);
            this.Controls.Add(this.grpDiario);
            this.Controls.Add(this.grpHoy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estadisticas";

            this.grpHoy.ResumeLayout(false);
            this.grpHoy.PerformLayout();
            this.grpDiario.ResumeLayout(false);
            this.grpDiario.PerformLayout();
            this.grpMensual.ResumeLayout(false);
            this.grpMensual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpHoy;
        private System.Windows.Forms.Label lblHoyFecha;
        private System.Windows.Forms.Label lblHoyConsumo;
        private System.Windows.Forms.Label lblHoyMacros;
        private System.Windows.Forms.ProgressBar pbHoy;
        private System.Windows.Forms.Label lblHoyFalta;
        private System.Windows.Forms.GroupBox grpDiario;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscarDiario;
        private System.Windows.Forms.DataGridView dgvDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCumple;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGras;
        private System.Windows.Forms.GroupBox grpMensual;
        private System.Windows.Forms.Label lblMesLabel;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblAnioLabel;
        private System.Windows.Forms.NumericUpDown numAnio;
        private System.Windows.Forms.Button btnBuscarMensual;
        private System.Windows.Forms.Label lblMensualResultado;
        private System.Windows.Forms.Button btnCerrar;
    }
}