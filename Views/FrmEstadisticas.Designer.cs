namespace NutricionApp.Views
{
    partial class FrmEstadisticas
    {
        private System.ComponentModel.IContainer components = null;

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpHoy              = new System.Windows.Forms.GroupBox();
            this.lblHoyFecha         = new System.Windows.Forms.Label();
            this.lblHoyConsumo       = new System.Windows.Forms.Label();
            this.pbHoy               = new System.Windows.Forms.ProgressBar();
            this.lblHoyFalta         = new System.Windows.Forms.Label();
            this.grpDiario           = new System.Windows.Forms.GroupBox();
            this.lblDesde            = new System.Windows.Forms.Label();
            this.dtpDesde            = new System.Windows.Forms.DateTimePicker();
            this.lblHasta            = new System.Windows.Forms.Label();
            this.dtpHasta            = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarDiario     = new System.Windows.Forms.Button();
            this.dgvDiario           = new System.Windows.Forms.DataGridView();
            this.colFecha            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCal              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeta             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPct              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCumple           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMensual          = new System.Windows.Forms.GroupBox();
            this.lblMesLabel         = new System.Windows.Forms.Label();
            this.cmbMes              = new System.Windows.Forms.ComboBox();
            this.lblAnioLabel        = new System.Windows.Forms.Label();
            this.numAnio             = new System.Windows.Forms.NumericUpDown();
            this.btnBuscarMensual    = new System.Windows.Forms.Button();
            this.lblMensualResultado = new System.Windows.Forms.Label();
            this.btnCerrar           = new System.Windows.Forms.Button();
            this.grpHoy.SuspendLayout();
            this.grpDiario.SuspendLayout();
            this.grpMensual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            this.SuspendLayout();
            // grpHoy
            this.grpHoy.Controls.Add(this.lblHoyFalta);
            this.grpHoy.Controls.Add(this.pbHoy);
            this.grpHoy.Controls.Add(this.lblHoyConsumo);
            this.grpHoy.Controls.Add(this.lblHoyFecha);
            this.grpHoy.Location = new System.Drawing.Point(12, 10);
            this.grpHoy.Name     = "grpHoy";
            this.grpHoy.Size     = new System.Drawing.Size(760, 120);
            this.grpHoy.TabIndex = 0;
            this.grpHoy.Text     = "Resumen de hoy";
            // lblHoyFecha
            this.lblHoyFecha.AutoSize = true;
            this.lblHoyFecha.Location = new System.Drawing.Point(10, 22);
            this.lblHoyFecha.Name     = "lblHoyFecha";
            this.lblHoyFecha.Text     = "Hoy:";
            // lblHoyConsumo
            this.lblHoyConsumo.Font     = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoyConsumo.Location = new System.Drawing.Point(10, 42);
            this.lblHoyConsumo.Name     = "lblHoyConsumo";
            this.lblHoyConsumo.Size     = new System.Drawing.Size(730, 18);
            this.lblHoyConsumo.Text     = "Consumido: — kcal     Meta: — kcal";
            // pbHoy
            this.pbHoy.Location = new System.Drawing.Point(10, 65);
            this.pbHoy.Name     = "pbHoy";
            this.pbHoy.Size     = new System.Drawing.Size(730, 16);
            this.pbHoy.Style    = System.Windows.Forms.ProgressBarStyle.Continuous;
            // lblHoyFalta
            this.lblHoyFalta.AutoSize = true;
            this.lblHoyFalta.Location = new System.Drawing.Point(10, 87);
            this.lblHoyFalta.Name     = "lblHoyFalta";
            this.lblHoyFalta.Text     = "--";
            // grpDiario
            this.grpDiario.Controls.Add(this.dgvDiario);
            this.grpDiario.Controls.Add(this.btnBuscarDiario);
            this.grpDiario.Controls.Add(this.dtpHasta);
            this.grpDiario.Controls.Add(this.lblHasta);
            this.grpDiario.Controls.Add(this.dtpDesde);
            this.grpDiario.Controls.Add(this.lblDesde);
            this.grpDiario.Location = new System.Drawing.Point(12, 140);
            this.grpDiario.Name     = "grpDiario";
            this.grpDiario.Size     = new System.Drawing.Size(470, 370);
            this.grpDiario.TabIndex = 1;
            this.grpDiario.Text     = "Historial diario";
            // lblDesde
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(8, 25);
            this.lblDesde.Name     = "lblDesde";
            this.lblDesde.Text     = "Desde:";
            // dtpDesde
            this.dtpDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(55, 21);
            this.dtpDesde.Name     = "dtpDesde";
            this.dtpDesde.Size     = new System.Drawing.Size(110, 20);
            this.dtpDesde.TabIndex = 0;
            // lblHasta
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(175, 25);
            this.lblHasta.Name     = "lblHasta";
            this.lblHasta.Text     = "Hasta:";
            // dtpHasta
            this.dtpHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(220, 21);
            this.dtpHasta.Name     = "dtpHasta";
            this.dtpHasta.Size     = new System.Drawing.Size(110, 20);
            this.dtpHasta.TabIndex = 1;
            // btnBuscarDiario
            this.btnBuscarDiario.Location = new System.Drawing.Point(342, 19);
            this.btnBuscarDiario.Name     = "btnBuscarDiario";
            this.btnBuscarDiario.Size     = new System.Drawing.Size(80, 26);
            this.btnBuscarDiario.TabIndex = 2;
            this.btnBuscarDiario.Text     = "Buscar";
            this.btnBuscarDiario.UseVisualStyleBackColor = true;
            this.btnBuscarDiario.Click += new System.EventHandler(this.btnBuscarDiario_Click);
            // columns
            this.colFecha.HeaderText  = "Fecha";         this.colFecha.Name  = "colFecha";  this.colFecha.Width  = 90;  this.colFecha.ReadOnly  = true;
            this.colCal.HeaderText    = "Calorias";       this.colCal.Name    = "colCal";    this.colCal.Width    = 75;  this.colCal.ReadOnly    = true;
            this.colMeta.HeaderText   = "Meta";           this.colMeta.Name   = "colMeta";   this.colMeta.Width   = 75;  this.colMeta.ReadOnly   = true;
            this.colPct.HeaderText    = "% Cumplido";     this.colPct.Name    = "colPct";    this.colPct.Width    = 80;  this.colPct.ReadOnly    = true;
            this.colCumple.HeaderText = "Meta cumplida";  this.colCumple.Name = "colCumple"; this.colCumple.Width = 90;  this.colCumple.ReadOnly = true;
            // dgvDiario
            this.dgvDiario.AllowUserToAddRows    = false;
            this.dgvDiario.AllowUserToDeleteRows = false;
            this.dgvDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFecha, this.colCal, this.colMeta, this.colPct, this.colCumple });
            this.dgvDiario.Location          = new System.Drawing.Point(8, 52);
            this.dgvDiario.MultiSelect       = false;
            this.dgvDiario.Name              = "dgvDiario";
            this.dgvDiario.ReadOnly          = true;
            this.dgvDiario.RowHeadersVisible = false;
            this.dgvDiario.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiario.Size              = new System.Drawing.Size(452, 306);
            this.dgvDiario.TabIndex          = 3;
            // grpMensual
            this.grpMensual.Controls.Add(this.lblMensualResultado);
            this.grpMensual.Controls.Add(this.btnBuscarMensual);
            this.grpMensual.Controls.Add(this.numAnio);
            this.grpMensual.Controls.Add(this.lblAnioLabel);
            this.grpMensual.Controls.Add(this.cmbMes);
            this.grpMensual.Controls.Add(this.lblMesLabel);
            this.grpMensual.Location = new System.Drawing.Point(497, 140);
            this.grpMensual.Name     = "grpMensual";
            this.grpMensual.Size     = new System.Drawing.Size(275, 370);
            this.grpMensual.TabIndex = 2;
            this.grpMensual.Text     = "Resumen mensual";
            // lblMesLabel
            this.lblMesLabel.AutoSize = true;
            this.lblMesLabel.Location = new System.Drawing.Point(8, 25);
            this.lblMesLabel.Name     = "lblMesLabel";
            this.lblMesLabel.Text     = "Mes:";
            // cmbMes
            this.cmbMes.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
                "Enero","Febrero","Marzo","Abril","Mayo","Junio",
                "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" });
            this.cmbMes.Location = new System.Drawing.Point(40, 21);
            this.cmbMes.Name     = "cmbMes";
            this.cmbMes.Size     = new System.Drawing.Size(110, 21);
            this.cmbMes.TabIndex = 0;
            // lblAnioLabel
            this.lblAnioLabel.AutoSize = true;
            this.lblAnioLabel.Location = new System.Drawing.Point(8, 55);
            this.lblAnioLabel.Name     = "lblAnioLabel";
            this.lblAnioLabel.Text     = "Anio:";
            // numAnio
            this.numAnio.Location = new System.Drawing.Point(50, 51);
            this.numAnio.Minimum  = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numAnio.Maximum  = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numAnio.Name     = "numAnio";
            this.numAnio.Size     = new System.Drawing.Size(70, 20);
            this.numAnio.TabIndex = 1;
            this.numAnio.Value    = new decimal(new int[] { 2025, 0, 0, 0 });
            // btnBuscarMensual
            this.btnBuscarMensual.Location = new System.Drawing.Point(130, 49);
            this.btnBuscarMensual.Name     = "btnBuscarMensual";
            this.btnBuscarMensual.Size     = new System.Drawing.Size(70, 26);
            this.btnBuscarMensual.TabIndex = 2;
            this.btnBuscarMensual.Text     = "Calcular";
            this.btnBuscarMensual.UseVisualStyleBackColor = true;
            this.btnBuscarMensual.Click += new System.EventHandler(this.btnBuscarMensual_Click);
            // lblMensualResultado
            this.lblMensualResultado.Location = new System.Drawing.Point(8, 85);
            this.lblMensualResultado.Name     = "lblMensualResultado";
            this.lblMensualResultado.Size     = new System.Drawing.Size(255, 270);
            this.lblMensualResultado.Text     = "Selecciona un mes y presiona Calcular.";
            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(652, 524);
            this.btnCerrar.Name     = "btnCerrar";
            this.btnCerrar.Size     = new System.Drawing.Size(120, 28);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // FrmEstadisticas
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(784, 566);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.grpMensual);
            this.Controls.Add(this.grpDiario);
            this.Controls.Add(this.grpHoy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "FrmEstadisticas";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Estadisticas";
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

        private System.Windows.Forms.GroupBox   grpHoy;
        private System.Windows.Forms.Label      lblHoyFecha;
        private System.Windows.Forms.Label      lblHoyConsumo;
        private System.Windows.Forms.ProgressBar pbHoy;
        private System.Windows.Forms.Label      lblHoyFalta;
        private System.Windows.Forms.GroupBox   grpDiario;
        private System.Windows.Forms.Label      lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label      lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button     btnBuscarDiario;
        private System.Windows.Forms.DataGridView dgvDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCumple;
        private System.Windows.Forms.GroupBox   grpMensual;
        private System.Windows.Forms.Label      lblMesLabel;
        private System.Windows.Forms.ComboBox   cmbMes;
        private System.Windows.Forms.Label      lblAnioLabel;
        private System.Windows.Forms.NumericUpDown numAnio;
        private System.Windows.Forms.Button     btnBuscarMensual;
        private System.Windows.Forms.Label      lblMensualResultado;
        private System.Windows.Forms.Button     btnCerrar;
    }
}
