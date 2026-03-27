namespace NutricionApp.Views
{
    partial class FrmCrearMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblFecha      = new System.Windows.Forms.Label();
            this.dtpFecha      = new System.Windows.Forms.DateTimePicker();
            this.lblAlimento   = new System.Windows.Forms.Label();
            this.cmbAlimento   = new System.Windows.Forms.ComboBox();
            this.lblGramos     = new System.Windows.Forms.Label();
            this.txtGramos     = new System.Windows.Forms.TextBox();
            this.btnAgregarItem= new System.Windows.Forms.Button();
            this.dgvItems      = new System.Windows.Forms.DataGridView();
            this.colNombre     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalItem    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitarItem = new System.Windows.Forms.Button();
            this.lblTotal      = new System.Windows.Forms.Label();
            this.btnGuardar    = new System.Windows.Forms.Button();
            this.btnCancelar   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 15);
            this.lblFecha.Name     = "lblFecha";
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text     = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(70, 11);
            this.dtpFecha.Name     = "dtpFecha";
            this.dtpFecha.Size     = new System.Drawing.Size(130, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblAlimento
            // 
            this.lblAlimento.AutoSize = true;
            this.lblAlimento.Location = new System.Drawing.Point(12, 50);
            this.lblAlimento.Name     = "lblAlimento";
            this.lblAlimento.TabIndex = 2;
            this.lblAlimento.Text     = "Alimento:";
            // 
            // cmbAlimento
            // 
            this.cmbAlimento.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlimento.FormattingEnabled = true;
            this.cmbAlimento.Location         = new System.Drawing.Point(70, 47);
            this.cmbAlimento.Name             = "cmbAlimento";
            this.cmbAlimento.Size             = new System.Drawing.Size(280, 21);
            this.cmbAlimento.TabIndex         = 3;
            // 
            // lblGramos
            // 
            this.lblGramos.AutoSize = true;
            this.lblGramos.Location = new System.Drawing.Point(360, 50);
            this.lblGramos.Name     = "lblGramos";
            this.lblGramos.TabIndex = 4;
            this.lblGramos.Text     = "Gramos:";
            // 
            // txtGramos
            // 
            this.txtGramos.Location = new System.Drawing.Point(415, 47);
            this.txtGramos.Name     = "txtGramos";
            this.txtGramos.Size     = new System.Drawing.Size(70, 20);
            this.txtGramos.TabIndex = 5;
            this.txtGramos.Text     = "100";
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Location = new System.Drawing.Point(500, 45);
            this.btnAgregarItem.Name     = "btnAgregarItem";
            this.btnAgregarItem.Size     = new System.Drawing.Size(80, 26);
            this.btnAgregarItem.TabIndex = 6;
            this.btnAgregarItem.Text     = "Agregar";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Alimento";
            this.colNombre.Name       = "colNombre";
            this.colNombre.Width      = 240;
            this.colNombre.ReadOnly   = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name       = "colCantidad";
            this.colCantidad.Width      = 90;
            this.colCantidad.ReadOnly   = true;
            // 
            // colCalItem
            // 
            this.colCalItem.HeaderText = "Calorias";
            this.colCalItem.Name       = "colCalItem";
            this.colCalItem.Width      = 100;
            this.colCalItem.ReadOnly   = true;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows    = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNombre, this.colCantidad, this.colCalItem });
            this.dgvItems.Location          = new System.Drawing.Point(12, 82);
            this.dgvItems.MultiSelect       = false;
            this.dgvItems.Name              = "dgvItems";
            this.dgvItems.ReadOnly          = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size              = new System.Drawing.Size(568, 280);
            this.dgvItems.TabIndex          = 7;
            // 
            // btnQuitarItem
            // 
            this.btnQuitarItem.Location = new System.Drawing.Point(12, 372);
            this.btnQuitarItem.Name     = "btnQuitarItem";
            this.btnQuitarItem.Size     = new System.Drawing.Size(130, 28);
            this.btnQuitarItem.TabIndex = 8;
            this.btnQuitarItem.Text     = "Quitar seleccionado";
            this.btnQuitarItem.UseVisualStyleBackColor = true;
            this.btnQuitarItem.Click += new System.EventHandler(this.btnQuitarItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font     = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(300, 377);
            this.lblTotal.Name     = "lblTotal";
            this.lblTotal.Size     = new System.Drawing.Size(280, 18);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text     = "Total: 0.0 kcal";
            this.lblTotal.TextAlign= System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(370, 415);
            this.btnGuardar.Name     = "btnGuardar";
            this.btnGuardar.Size     = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text     = "Guardar menu";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(482, 415);
            this.btnCancelar.Name     = "btnCancelar";
            this.btnCancelar.Size     = new System.Drawing.Size(98, 30);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text     = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmCrearMenu
            // 
            this.AcceptButton        = this.btnAgregarItem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(592, 460);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnQuitarItem);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnAgregarItem);
            this.Controls.Add(this.txtGramos);
            this.Controls.Add(this.lblGramos);
            this.Controls.Add(this.cmbAlimento);
            this.Controls.Add(this.lblAlimento);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "FrmCrearMenu";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Crear Menu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label                     lblFecha;
        private System.Windows.Forms.DateTimePicker            dtpFecha;
        private System.Windows.Forms.Label                     lblAlimento;
        private System.Windows.Forms.ComboBox                  cmbAlimento;
        private System.Windows.Forms.Label                     lblGramos;
        private System.Windows.Forms.TextBox                   txtGramos;
        private System.Windows.Forms.Button                    btnAgregarItem;
        private System.Windows.Forms.DataGridView              dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalItem;
        private System.Windows.Forms.Button                    btnQuitarItem;
        private System.Windows.Forms.Label                     lblTotal;
        private System.Windows.Forms.Button                    btnGuardar;
        private System.Windows.Forms.Button                    btnCancelar;
    }
}
