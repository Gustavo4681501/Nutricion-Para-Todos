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
            lblTitulo = new System.Windows.Forms.Label();
            dgvAlimentos = new System.Windows.Forms.DataGridView();
            colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCalorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProteinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCarbs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGrasas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPorcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnAgregar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlimentos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 19);
            lblTitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(1267, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Catalogo de Alimentos";
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAlimentos
            // 
            dgvAlimentos.AllowUserToAddRows = false;
            dgvAlimentos.AllowUserToDeleteRows = false;
            dgvAlimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNombre, colCalorias, colProteinas, colCarbs, colGrasas, colPorcion });
            dgvAlimentos.Location = new System.Drawing.Point(20, 92);
            dgvAlimentos.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            dgvAlimentos.MultiSelect = false;
            dgvAlimentos.Name = "dgvAlimentos";
            dgvAlimentos.ReadOnly = true;
            dgvAlimentos.RowHeadersVisible = false;
            dgvAlimentos.RowHeadersWidth = 62;
            dgvAlimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAlimentos.Size = new System.Drawing.Size(1267, 712);
            dgvAlimentos.TabIndex = 1;
            dgvAlimentos.CellContentClick += dgvAlimentos_CellContentClick;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 8;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 200;
            // 
            // colCalorias
            // 
            colCalorias.HeaderText = "Calorias";
            colCalorias.MinimumWidth = 8;
            colCalorias.Name = "colCalorias";
            colCalorias.ReadOnly = true;
            colCalorias.Width = 80;
            // 
            // colProteinas
            // 
            colProteinas.HeaderText = "Proteinas (g)";
            colProteinas.MinimumWidth = 8;
            colProteinas.Name = "colProteinas";
            colProteinas.ReadOnly = true;
            // 
            // colCarbs
            // 
            colCarbs.HeaderText = "Carbohidratos (g)";
            colCarbs.MinimumWidth = 8;
            colCarbs.Name = "colCarbs";
            colCarbs.ReadOnly = true;
            colCarbs.Width = 120;
            // 
            // colGrasas
            // 
            colGrasas.HeaderText = "Grasas (g)";
            colGrasas.MinimumWidth = 8;
            colGrasas.Name = "colGrasas";
            colGrasas.ReadOnly = true;
            colGrasas.Width = 90;
            // 
            // colPorcion
            // 
            colPorcion.HeaderText = "Porcion";
            colPorcion.MinimumWidth = 8;
            colPorcion.Name = "colPorcion";
            colPorcion.ReadOnly = true;
            colPorcion.Width = 80;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new System.Drawing.Point(20, 831);
            btnAgregar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(200, 58);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new System.Drawing.Point(242, 831);
            btnEliminar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(200, 58);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new System.Drawing.Point(1087, 831);
            btnCerrar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(200, 58);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmAlimentos
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1307, 917);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvAlimentos);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FrmAlimentos";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Catalogo de Alimentos";
            ((System.ComponentModel.ISupportInitialize)dgvAlimentos).EndInit();
            ResumeLayout(false);
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
