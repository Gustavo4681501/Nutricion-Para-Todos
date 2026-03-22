namespace NutricionApp.Views
{
    partial class FrmMenu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFecha    = new System.Windows.Forms.Label();
            this.dtpFecha    = new System.Windows.Forms.DateTimePicker();
            this.lblAlim     = new System.Windows.Forms.Label();
            this.cmbAlimento = new System.Windows.Forms.ComboBox();
            this.lblTiempo   = new System.Windows.Forms.Label();
            this.cmbTiempo   = new System.Windows.Forms.ComboBox();
            this.lblCant     = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar  = new System.Windows.Forms.Button();
            this.dgvItems    = new System.Windows.Forms.DataGridView();
            this.iColNombre  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iColTiempo  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iColCant    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iColCal     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iColProt    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iColCarbs   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iColGrasas  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitar   = new System.Windows.Forms.Button();
            this.lblTotales  = new System.Windows.Forms.Label();
            this.btnGuardar  = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            this.lblFecha.AutoSize = true; this.lblFecha.Location = new System.Drawing.Point(8,10); this.lblFecha.Text = "Fecha:";
            this.dtpFecha.Format   = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpFecha.Location = new System.Drawing.Point(55,6); this.dtpFecha.Name = "dtpFecha"; this.dtpFecha.Size = new System.Drawing.Size(110,20); this.dtpFecha.TabIndex = 0; this.dtpFecha.Value = System.DateTime.Today;
            this.lblAlim.AutoSize  = true; this.lblAlim.Location  = new System.Drawing.Point(8,40); this.lblAlim.Text  = "Alimento:";
            this.cmbAlimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbAlimento.FormattingEnabled = true; this.cmbAlimento.Location = new System.Drawing.Point(65,36); this.cmbAlimento.Name = "cmbAlimento"; this.cmbAlimento.Size = new System.Drawing.Size(240,21); this.cmbAlimento.TabIndex = 1;
            this.lblTiempo.AutoSize= true; this.lblTiempo.Location= new System.Drawing.Point(315,40); this.lblTiempo.Text= "Tiempo:";
            this.cmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTiempo.FormattingEnabled = true; this.cmbTiempo.Items.AddRange(new object[]{"Desayuno","Merienda manana","Almuerzo","Merienda tarde","Cena"}); this.cmbTiempo.Location = new System.Drawing.Point(365,36); this.cmbTiempo.Name = "cmbTiempo"; this.cmbTiempo.SelectedIndex = 0; this.cmbTiempo.Size = new System.Drawing.Size(130,21); this.cmbTiempo.TabIndex = 2;
            this.lblCant.AutoSize  = true; this.lblCant.Location  = new System.Drawing.Point(505,40); this.lblCant.Text  = "g:";
            this.numCantidad.Location = new System.Drawing.Point(520,36); this.numCantidad.Minimum = new decimal(new int[]{1,0,0,0}); this.numCantidad.Maximum = new decimal(new int[]{2000,0,0,0}); this.numCantidad.Value = new decimal(new int[]{100,0,0,0}); this.numCantidad.Name = "numCantidad"; this.numCantidad.Size = new System.Drawing.Size(65,20); this.numCantidad.TabIndex = 3;
            this.btnAgregar.Location = new System.Drawing.Point(596,36); this.btnAgregar.Name = "btnAgregar"; this.btnAgregar.Size = new System.Drawing.Size(100,24); this.btnAgregar.TabIndex = 4; this.btnAgregar.Text = "Agregar item"; this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.iColNombre.HeaderText = "Alimento"; this.iColNombre.Name = "iColNombre"; this.iColNombre.Width = 160; this.iColNombre.ReadOnly = true;
            this.iColTiempo.HeaderText = "Tiempo";   this.iColTiempo.Name = "iColTiempo"; this.iColTiempo.Width = 100; this.iColTiempo.ReadOnly = true;
            this.iColCant.HeaderText   = "Cant.";    this.iColCant.Name   = "iColCant";   this.iColCant.Width   = 60;  this.iColCant.ReadOnly   = true;
            this.iColCal.HeaderText    = "Kcal";     this.iColCal.Name    = "iColCal";    this.iColCal.Width    = 65;  this.iColCal.ReadOnly    = true;
            this.iColProt.HeaderText   = "Prot.";    this.iColProt.Name   = "iColProt";   this.iColProt.Width   = 65;  this.iColProt.ReadOnly   = true;
            this.iColCarbs.HeaderText  = "Carbs.";   this.iColCarbs.Name  = "iColCarbs";  this.iColCarbs.Width  = 65;  this.iColCarbs.ReadOnly  = true;
            this.iColGrasas.HeaderText = "Grasas.";  this.iColGrasas.Name = "iColGrasas"; this.iColGrasas.Width = 65;  this.iColGrasas.ReadOnly = true;

            this.dgvItems.AllowUserToAddRows    = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{
                this.iColNombre,this.iColTiempo,this.iColCant,this.iColCal,this.iColProt,this.iColCarbs,this.iColGrasas});
            this.dgvItems.Location = new System.Drawing.Point(8,66); this.dgvItems.MultiSelect = false; this.dgvItems.Name = "dgvItems"; this.dgvItems.ReadOnly = true; this.dgvItems.RowHeadersVisible = false; this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvItems.Size = new System.Drawing.Size(690,260); this.dgvItems.TabIndex = 5;

            this.btnQuitar.Location = new System.Drawing.Point(8,334); this.btnQuitar.Name = "btnQuitar"; this.btnQuitar.Size = new System.Drawing.Size(140,24); this.btnQuitar.TabIndex = 6; this.btnQuitar.Text = "Quitar seleccionado"; this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            this.lblTotales.AutoSize = true; this.lblTotales.Font = new System.Drawing.Font("Microsoft Sans Serif",8.25F,System.Drawing.FontStyle.Bold); this.lblTotales.Location = new System.Drawing.Point(8,368); this.lblTotales.Name = "lblTotales"; this.lblTotales.Text = "Total: 0 kcal";
            this.btnGuardar.Location  = new System.Drawing.Point(460,390); this.btnGuardar.Name = "btnGuardar"; this.btnGuardar.Size = new System.Drawing.Size(110,26); this.btnGuardar.TabIndex = 7; this.btnGuardar.Text = "Guardar menu"; this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Location = new System.Drawing.Point(578,390); this.btnCancelar.Name = "btnCancelar"; this.btnCancelar.Size = new System.Drawing.Size(90,26); this.btnCancelar.TabIndex = 8; this.btnCancelar.Text = "Cancelar"; this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710,428);
            this.Controls.Add(this.btnCancelar); this.Controls.Add(this.btnGuardar); this.Controls.Add(this.lblTotales); this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.dgvItems); this.Controls.Add(this.btnAgregar); this.Controls.Add(this.numCantidad); this.Controls.Add(this.lblCant);
            this.Controls.Add(this.cmbTiempo); this.Controls.Add(this.lblTiempo); this.Controls.Add(this.cmbAlimento); this.Controls.Add(this.lblAlim);
            this.Controls.Add(this.dtpFecha); this.Controls.Add(this.lblFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblFecha, lblAlim, lblTiempo, lblCant, lblTotales;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbAlimento, cmbTiempo;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregar, btnQuitar, btnGuardar, btnCancelar;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn iColNombre, iColTiempo, iColCant, iColCal, iColProt, iColCarbs, iColGrasas;
    }
}
