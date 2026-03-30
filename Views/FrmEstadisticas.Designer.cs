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
            grpHoy = new System.Windows.Forms.GroupBox();
            lblHoyFalta = new System.Windows.Forms.Label();
            pbHoy = new System.Windows.Forms.ProgressBar();
            lblHoyConsumo = new System.Windows.Forms.Label();
            lblHoyFecha = new System.Windows.Forms.Label();
            grpDiario = new System.Windows.Forms.GroupBox();
            dgvDiario = new System.Windows.Forms.DataGridView();
            colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCumple = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnBuscarDiario = new System.Windows.Forms.Button();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblDesde = new System.Windows.Forms.Label();
            grpMensual = new System.Windows.Forms.GroupBox();
            lblMensualResultado = new System.Windows.Forms.Label();
            btnBuscarMensual = new System.Windows.Forms.Button();
            numAnio = new System.Windows.Forms.NumericUpDown();
            lblAnioLabel = new System.Windows.Forms.Label();
            cmbMes = new System.Windows.Forms.ComboBox();
            lblMesLabel = new System.Windows.Forms.Label();
            btnCerrar = new System.Windows.Forms.Button();
            grpHoy.SuspendLayout();
            grpDiario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiario).BeginInit();
            grpMensual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            SuspendLayout();
            // 
            // grpHoy
            // 
            grpHoy.Controls.Add(lblHoyFalta);
            grpHoy.Controls.Add(pbHoy);
            grpHoy.Controls.Add(lblHoyConsumo);
            grpHoy.Controls.Add(lblHoyFecha);
            grpHoy.Location = new System.Drawing.Point(20, 19);
            grpHoy.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpHoy.Name = "grpHoy";
            grpHoy.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpHoy.Size = new System.Drawing.Size(1267, 231);
            grpHoy.TabIndex = 0;
            grpHoy.TabStop = false;
            // 
            // lblHoyFalta
            // 
            lblHoyFalta.AutoSize = true;
            lblHoyFalta.Location = new System.Drawing.Point(17, 167);
            lblHoyFalta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblHoyFalta.Name = "lblHoyFalta";
            lblHoyFalta.Size = new System.Drawing.Size(26, 25);
            lblHoyFalta.TabIndex = 0;
            lblHoyFalta.Text = "--";
            // 
            // pbHoy
            // 
            pbHoy.Location = new System.Drawing.Point(17, 125);
            pbHoy.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            pbHoy.Name = "pbHoy";
            pbHoy.Size = new System.Drawing.Size(1217, 31);
            pbHoy.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            pbHoy.TabIndex = 1;
            pbHoy.Click += pbHoy_Click;
            // 
            // lblHoyConsumo
            // 
            lblHoyConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblHoyConsumo.Location = new System.Drawing.Point(17, 81);
            lblHoyConsumo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblHoyConsumo.Name = "lblHoyConsumo";
            lblHoyConsumo.Size = new System.Drawing.Size(1217, 35);
            lblHoyConsumo.TabIndex = 2;
            lblHoyConsumo.Text = "Consumido: — kcal     Meta: — kcal";
            // 
            // lblHoyFecha
            // 
            lblHoyFecha.AutoSize = true;
            lblHoyFecha.Location = new System.Drawing.Point(17, 42);
            lblHoyFecha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblHoyFecha.Name = "lblHoyFecha";
            lblHoyFecha.Size = new System.Drawing.Size(49, 25);
            lblHoyFecha.TabIndex = 3;
            lblHoyFecha.Text = "Hoy:";
            // 
            // grpDiario
            // 
            grpDiario.Controls.Add(dgvDiario);
            grpDiario.Controls.Add(btnBuscarDiario);
            grpDiario.Controls.Add(dtpHasta);
            grpDiario.Controls.Add(lblHasta);
            grpDiario.Controls.Add(dtpDesde);
            grpDiario.Controls.Add(lblDesde);
            grpDiario.Location = new System.Drawing.Point(20, 269);
            grpDiario.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpDiario.Name = "grpDiario";
            grpDiario.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpDiario.Size = new System.Drawing.Size(783, 712);
            grpDiario.TabIndex = 1;
            grpDiario.TabStop = false;
            grpDiario.Text = "Historial diario";
            // 
            // dgvDiario
            // 
            dgvDiario.AllowUserToAddRows = false;
            dgvDiario.AllowUserToDeleteRows = false;
            dgvDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colFecha, colCal, colMeta, colPct, colCumple });
            dgvDiario.Location = new System.Drawing.Point(13, 100);
            dgvDiario.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            dgvDiario.MultiSelect = false;
            dgvDiario.Name = "dgvDiario";
            dgvDiario.ReadOnly = true;
            dgvDiario.RowHeadersVisible = false;
            dgvDiario.RowHeadersWidth = 62;
            dgvDiario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDiario.Size = new System.Drawing.Size(753, 588);
            dgvDiario.TabIndex = 3;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 8;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 90;
            // 
            // colCal
            // 
            colCal.HeaderText = "Calorias";
            colCal.MinimumWidth = 8;
            colCal.Name = "colCal";
            colCal.ReadOnly = true;
            colCal.Width = 75;
            // 
            // colMeta
            // 
            colMeta.HeaderText = "Meta";
            colMeta.MinimumWidth = 8;
            colMeta.Name = "colMeta";
            colMeta.ReadOnly = true;
            colMeta.Width = 75;
            // 
            // colPct
            // 
            colPct.HeaderText = "% Cumplido";
            colPct.MinimumWidth = 8;
            colPct.Name = "colPct";
            colPct.ReadOnly = true;
            colPct.Width = 80;
            // 
            // colCumple
            // 
            colCumple.HeaderText = "Meta cumplida";
            colCumple.MinimumWidth = 8;
            colCumple.Name = "colCumple";
            colCumple.ReadOnly = true;
            colCumple.Width = 90;
            // 
            // btnBuscarDiario
            // 
            btnBuscarDiario.Location = new System.Drawing.Point(570, 37);
            btnBuscarDiario.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnBuscarDiario.Name = "btnBuscarDiario";
            btnBuscarDiario.Size = new System.Drawing.Size(133, 50);
            btnBuscarDiario.TabIndex = 2;
            btnBuscarDiario.Text = "Buscar";
            btnBuscarDiario.UseVisualStyleBackColor = true;
            btnBuscarDiario.Click += btnBuscarDiario_Click;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpHasta.Location = new System.Drawing.Point(367, 40);
            dtpHasta.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new System.Drawing.Size(181, 31);
            dtpHasta.TabIndex = 1;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new System.Drawing.Point(292, 48);
            lblHasta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new System.Drawing.Size(61, 25);
            lblHasta.TabIndex = 4;
            lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDesde.Location = new System.Drawing.Point(92, 40);
            dtpDesde.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new System.Drawing.Size(181, 31);
            dtpDesde.TabIndex = 0;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new System.Drawing.Point(13, 48);
            lblDesde.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new System.Drawing.Size(66, 25);
            lblDesde.TabIndex = 5;
            lblDesde.Text = "Desde:";
            // 
            // grpMensual
            // 
            grpMensual.Controls.Add(lblMensualResultado);
            grpMensual.Controls.Add(btnBuscarMensual);
            grpMensual.Controls.Add(numAnio);
            grpMensual.Controls.Add(lblAnioLabel);
            grpMensual.Controls.Add(cmbMes);
            grpMensual.Controls.Add(lblMesLabel);
            grpMensual.Location = new System.Drawing.Point(828, 269);
            grpMensual.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpMensual.Name = "grpMensual";
            grpMensual.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpMensual.Size = new System.Drawing.Size(458, 712);
            grpMensual.TabIndex = 2;
            grpMensual.TabStop = false;
            grpMensual.Text = "Resumen mensual";
            // 
            // lblMensualResultado
            // 
            lblMensualResultado.Location = new System.Drawing.Point(13, 163);
            lblMensualResultado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblMensualResultado.Name = "lblMensualResultado";
            lblMensualResultado.Size = new System.Drawing.Size(425, 519);
            lblMensualResultado.TabIndex = 0;
            lblMensualResultado.Text = "Selecciona un mes y presiona Calcular.";
            // 
            // btnBuscarMensual
            // 
            btnBuscarMensual.Location = new System.Drawing.Point(217, 94);
            btnBuscarMensual.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnBuscarMensual.Name = "btnBuscarMensual";
            btnBuscarMensual.Size = new System.Drawing.Size(117, 50);
            btnBuscarMensual.TabIndex = 2;
            btnBuscarMensual.Text = "Calcular";
            btnBuscarMensual.UseVisualStyleBackColor = true;
            btnBuscarMensual.Click += btnBuscarMensual_Click;
            // 
            // numAnio
            // 
            numAnio.Location = new System.Drawing.Point(83, 98);
            numAnio.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            numAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numAnio.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numAnio.Name = "numAnio";
            numAnio.Size = new System.Drawing.Size(117, 31);
            numAnio.TabIndex = 1;
            numAnio.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // lblAnioLabel
            // 
            lblAnioLabel.AutoSize = true;
            lblAnioLabel.Location = new System.Drawing.Point(13, 106);
            lblAnioLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblAnioLabel.Name = "lblAnioLabel";
            lblAnioLabel.Size = new System.Drawing.Size(53, 25);
            lblAnioLabel.TabIndex = 3;
            lblAnioLabel.Text = "Anio:";
            // 
            // cmbMes
            // 
            cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMes.FormattingEnabled = true;
            cmbMes.Items.AddRange(new object[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" });
            cmbMes.Location = new System.Drawing.Point(67, 40);
            cmbMes.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cmbMes.Name = "cmbMes";
            cmbMes.Size = new System.Drawing.Size(181, 33);
            cmbMes.TabIndex = 0;
            // 
            // lblMesLabel
            // 
            lblMesLabel.AutoSize = true;
            lblMesLabel.Location = new System.Drawing.Point(13, 48);
            lblMesLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblMesLabel.Name = "lblMesLabel";
            lblMesLabel.Size = new System.Drawing.Size(49, 25);
            lblMesLabel.TabIndex = 4;
            lblMesLabel.Text = "Mes:";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new System.Drawing.Point(1087, 1008);
            btnCerrar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(200, 54);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmEstadisticas
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1307, 1050);
            Controls.Add(btnCerrar);
            Controls.Add(grpMensual);
            Controls.Add(grpDiario);
            Controls.Add(grpHoy);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FrmEstadisticas";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Estadisticas";
            grpHoy.ResumeLayout(false);
            grpHoy.PerformLayout();
            grpDiario.ResumeLayout(false);
            grpDiario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiario).EndInit();
            grpMensual.ResumeLayout(false);
            grpMensual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            ResumeLayout(false);
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
