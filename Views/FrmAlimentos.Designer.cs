namespace NutricionApp.Views
{
    partial class FrmAlimentos
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
            this.lblTitulo     = new System.Windows.Forms.Label();
            this.dgvAlimentos  = new System.Windows.Forms.DataGridView();
            this.colNombre     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalorias   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProteinas  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarbs      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrasas     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcion    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar    = new System.Windows.Forms.Button();
            this.btnEliminar   = new System.Windows.Forms.Button();
            this.btnCerrar     = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlimentos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font      = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location  = new System.Drawing.Point(12, 10);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(760, 28);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Catalogo de Alimentos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name       = "colNombre";
            this.colNombre.Width      = 200;
            this.colNombre.ReadOnly   = true;
            // 
            // colCalorias
            // 
            this.colCalorias.HeaderText = "Calorias";
            this.colCalorias.Name       = "colCalorias";
            this.colCalorias.Width      = 80;
            this.colCalorias.ReadOnly   = true;
            // 
            // colProteinas
            // 
            this.colProteinas.HeaderText = "Proteinas (g)";
            this.colProteinas.Name       = "colProteinas";
            this.colProteinas.Width      = 100;
            this.colProteinas.ReadOnly   = true;
            // 
            // colCarbs
            // 
            this.colCarbs.HeaderText = "Carbohidratos (g)";
            this.colCarbs.Name       = "colCarbs";
            this.colCarbs.Width      = 120;
            this.colCarbs.ReadOnly   = true;
            // 
            // colGrasas
            // 
            this.colGrasas.HeaderText = "Grasas (g)";
            this.colGrasas.Name       = "colGrasas";
            this.colGrasas.Width      = 90;
            this.colGrasas.ReadOnly   = true;
            // 
            // colPorcion
            // 
            this.colPorcion.HeaderText = "Porcion";
            this.colPorcion.Name       = "colPorcion";
            this.colPorcion.Width      = 80;
            this.colPorcion.ReadOnly   = true;
            // 
            // dgvAlimentos
            // 
            this.dgvAlimentos.AllowUserToAddRows    = false;
            this.dgvAlimentos.AllowUserToDeleteRows = false;
            this.dgvAlimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNombre, this.colCalorias, this.colProteinas,
                this.colCarbs, this.colGrasas, this.colPorcion });
            this.dgvAlimentos.Location          = new System.Drawing.Point(12, 48);
            this.dgvAlimentos.MultiSelect       = false;
            this.dgvAlimentos.Name              = "dgvAlimentos";
            this.dgvAlimentos.ReadOnly          = true;
            this.dgvAlimentos.RowHeadersVisible = false;
            this.dgvAlimentos.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlimentos.Size              = new System.Drawing.Size(760, 370);
            this.dgvAlimentos.TabIndex          = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 432);
            this.btnAgregar.Name     = "btnAgregar";
            this.btnAgregar.Size     = new System.Drawing.Size(120, 30);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text     = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(145, 432);
            this.btnEliminar.Name     = "btnEliminar";
            this.btnEliminar.Size     = new System.Drawing.Size(120, 30);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text     = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(652, 432);
            this.btnCerrar.Name     = "btnCerrar";
            this.btnCerrar.Size     = new System.Drawing.Size(120, 30);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmAlimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(784, 477);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvAlimentos);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "FrmAlimentos";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Catalogo de Alimentos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlimentos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label                     lblTitulo;
        private System.Windows.Forms.DataGridView              dgvAlimentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProteinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarbs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrasas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcion;
        private System.Windows.Forms.Button                    btnAgregar;
        private System.Windows.Forms.Button                    btnEliminar;
        private System.Windows.Forms.Button                    btnCerrar;
    }
}
