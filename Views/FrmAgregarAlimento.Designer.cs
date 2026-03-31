namespace NutricionApp.Views
{
    partial class FrmAgregarAlimento
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
            lblNombre = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            lblCalorias = new System.Windows.Forms.Label();
            txtCalorias = new System.Windows.Forms.TextBox();
            lblProteinas = new System.Windows.Forms.Label();
            txtProteinas = new System.Windows.Forms.TextBox();
            lblCarbohidratos = new System.Windows.Forms.Label();
            txtCarbohidratos = new System.Windows.Forms.TextBox();
            lblGrasas = new System.Windows.Forms.Label();
            txtGrasas = new System.Windows.Forms.TextBox();
            lblPorcion = new System.Windows.Forms.Label();
            txtPorcion = new System.Windows.Forms.TextBox();
            lblPorcionInfo = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(33, 38);
            lblNombre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(82, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(300, 33);
            txtNombre.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(397, 31);
            txtNombre.TabIndex = 1;
            // 
            // lblCalorias
            // 
            lblCalorias.AutoSize = true;
            lblCalorias.Location = new System.Drawing.Point(33, 106);
            lblCalorias.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblCalorias.Name = "lblCalorias";
            lblCalorias.Size = new System.Drawing.Size(123, 25);
            lblCalorias.TabIndex = 2;
            lblCalorias.Text = "Calorias (kcal):";
            // 
            // txtCalorias
            // 
            txtCalorias.Location = new System.Drawing.Point(300, 100);
            txtCalorias.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtCalorias.Name = "txtCalorias";
            txtCalorias.Size = new System.Drawing.Size(197, 31);
            txtCalorias.TabIndex = 3;
            // 
            // lblProteinas
            // 
            lblProteinas.AutoSize = true;
            lblProteinas.Location = new System.Drawing.Point(33, 173);
            lblProteinas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblProteinas.Name = "lblProteinas";
            lblProteinas.Size = new System.Drawing.Size(115, 25);
            lblProteinas.TabIndex = 4;
            lblProteinas.Text = "Proteinas (g):";
            // 
            // txtProteinas
            // 
            txtProteinas.Location = new System.Drawing.Point(300, 167);
            txtProteinas.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtProteinas.Name = "txtProteinas";
            txtProteinas.Size = new System.Drawing.Size(197, 31);
            txtProteinas.TabIndex = 5;
            // 
            // lblCarbohidratos
            // 
            lblCarbohidratos.AutoSize = true;
            lblCarbohidratos.Location = new System.Drawing.Point(33, 240);
            lblCarbohidratos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblCarbohidratos.Name = "lblCarbohidratos";
            lblCarbohidratos.Size = new System.Drawing.Size(155, 25);
            lblCarbohidratos.TabIndex = 6;
            lblCarbohidratos.Text = "Carbohidratos (g):";
            // 
            // txtCarbohidratos
            // 
            txtCarbohidratos.Location = new System.Drawing.Point(300, 235);
            txtCarbohidratos.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtCarbohidratos.Name = "txtCarbohidratos";
            txtCarbohidratos.Size = new System.Drawing.Size(197, 31);
            txtCarbohidratos.TabIndex = 7;
            // 
            // lblGrasas
            // 
            lblGrasas.AutoSize = true;
            lblGrasas.Location = new System.Drawing.Point(33, 308);
            lblGrasas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblGrasas.Name = "lblGrasas";
            lblGrasas.Size = new System.Drawing.Size(94, 25);
            lblGrasas.TabIndex = 8;
            lblGrasas.Text = "Grasas (g):";
            // 
            // txtGrasas
            // 
            txtGrasas.Location = new System.Drawing.Point(300, 302);
            txtGrasas.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtGrasas.Name = "txtGrasas";
            txtGrasas.Size = new System.Drawing.Size(197, 31);
            txtGrasas.TabIndex = 9;
            // 
            // lblPorcion
            // 
            lblPorcion.AutoSize = true;
            lblPorcion.Location = new System.Drawing.Point(33, 375);
            lblPorcion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblPorcion.Name = "lblPorcion";
            lblPorcion.Size = new System.Drawing.Size(101, 25);
            lblPorcion.TabIndex = 10;
            lblPorcion.Text = "Porcion (g):";
            // 
            // txtPorcion
            // 
            txtPorcion.Location = new System.Drawing.Point(300, 369);
            txtPorcion.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtPorcion.Name = "txtPorcion";
            txtPorcion.Size = new System.Drawing.Size(197, 31);
            txtPorcion.TabIndex = 11;
            txtPorcion.Text = "100";
            // 
            // lblPorcionInfo
            // 
            lblPorcionInfo.AutoSize = true;
            lblPorcionInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            lblPorcionInfo.Location = new System.Drawing.Point(513, 375);
            lblPorcionInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblPorcionInfo.Name = "lblPorcionInfo";
            lblPorcionInfo.Size = new System.Drawing.Size(374, 25);
            lblPorcionInfo.TabIndex = 12;
            lblPorcionInfo.Text = "Los valores nutricionales son por esta porcion";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new System.Drawing.Point(200, 462);
            btnGuardar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(183, 58);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(408, 462);
            btnCancelar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(183, 58);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAgregarAlimento
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(961, 583);
            Controls.Add(lblPorcionInfo);
            Controls.Add(txtPorcion);
            Controls.Add(lblPorcion);
            Controls.Add(txtGrasas);
            Controls.Add(lblGrasas);
            Controls.Add(txtCarbohidratos);
            Controls.Add(lblCarbohidratos);
            Controls.Add(txtProteinas);
            Controls.Add(lblProteinas);
            Controls.Add(txtCalorias);
            Controls.Add(lblCalorias);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FrmAgregarAlimento";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Agregar Alimento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label   lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label   lblCalorias;
        private System.Windows.Forms.TextBox txtCalorias;
        private System.Windows.Forms.Label   lblProteinas;
        private System.Windows.Forms.TextBox txtProteinas;
        private System.Windows.Forms.Label   lblCarbohidratos;
        private System.Windows.Forms.TextBox txtCarbohidratos;
        private System.Windows.Forms.Label   lblGrasas;
        private System.Windows.Forms.TextBox txtGrasas;
        private System.Windows.Forms.Label   lblPorcion;
        private System.Windows.Forms.TextBox txtPorcion;
        private System.Windows.Forms.Label   lblPorcionInfo;
        private System.Windows.Forms.Button  btnGuardar;
        private System.Windows.Forms.Button  btnCancelar;
    }
}
