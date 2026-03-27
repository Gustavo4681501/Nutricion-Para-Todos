namespace NutricionApp.Views
{
    partial class FrmMenus
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
            this.lblTitulo   = new System.Windows.Forms.Label();
            this.dgvMenus    = new System.Windows.Forms.DataGridView();
            this.colFecha    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar  = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font      = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location  = new System.Drawing.Point(12, 10);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(560, 28);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Mis Menus Diarios";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name       = "colFecha";
            this.colFecha.Width      = 120;
            this.colFecha.ReadOnly   = true;
            // 
            // colItems
            // 
            this.colItems.HeaderText = "Alimentos";
            this.colItems.Name       = "colItems";
            this.colItems.Width      = 100;
            this.colItems.ReadOnly   = true;
            // 
            // colCalorias
            // 
            this.colCalorias.HeaderText = "Total calorias";
            this.colCalorias.Name       = "colCalorias";
            this.colCalorias.Width      = 140;
            this.colCalorias.ReadOnly   = true;
            // 
            // dgvMenus
            // 
            this.dgvMenus.AllowUserToAddRows    = false;
            this.dgvMenus.AllowUserToDeleteRows = false;
            this.dgvMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFecha, this.colItems, this.colCalorias });
            this.dgvMenus.Location          = new System.Drawing.Point(12, 48);
            this.dgvMenus.MultiSelect       = false;
            this.dgvMenus.Name              = "dgvMenus";
            this.dgvMenus.ReadOnly          = true;
            this.dgvMenus.RowHeadersVisible = false;
            this.dgvMenus.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenus.Size              = new System.Drawing.Size(560, 330);
            this.dgvMenus.TabIndex          = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 394);
            this.btnAgregar.Name     = "btnAgregar";
            this.btnAgregar.Size     = new System.Drawing.Size(120, 30);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text     = "Nuevo menu";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(145, 394);
            this.btnEliminar.Name     = "btnEliminar";
            this.btnEliminar.Size     = new System.Drawing.Size(120, 30);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text     = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(452, 394);
            this.btnCerrar.Name     = "btnCerrar";
            this.btnCerrar.Size     = new System.Drawing.Size(120, 30);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(584, 440);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvMenus);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "FrmMenus";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Mis Menus";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label                     lblTitulo;
        private System.Windows.Forms.DataGridView              dgvMenus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalorias;
        private System.Windows.Forms.Button                    btnAgregar;
        private System.Windows.Forms.Button                    btnEliminar;
        private System.Windows.Forms.Button                    btnCerrar;
    }
}
