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
            this.lblNombre        = new System.Windows.Forms.Label();
            this.txtNombre        = new System.Windows.Forms.TextBox();
            this.lblCalorias      = new System.Windows.Forms.Label();
            this.txtCalorias      = new System.Windows.Forms.TextBox();
            this.lblProteinas     = new System.Windows.Forms.Label();
            this.txtProteinas     = new System.Windows.Forms.TextBox();
            this.lblCarbohidratos = new System.Windows.Forms.Label();
            this.txtCarbohidratos = new System.Windows.Forms.TextBox();
            this.lblGrasas        = new System.Windows.Forms.Label();
            this.txtGrasas        = new System.Windows.Forms.TextBox();
            this.lblPorcion       = new System.Windows.Forms.Label();
            this.txtPorcion       = new System.Windows.Forms.TextBox();
            this.lblPorcionInfo   = new System.Windows.Forms.Label();
            this.btnGuardar       = new System.Windows.Forms.Button();
            this.btnCancelar      = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            this.lblNombre.Name     = "lblNombre";
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text     = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(180, 17);
            this.txtNombre.Name     = "txtNombre";
            this.txtNombre.Size     = new System.Drawing.Size(240, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblCalorias
            // 
            this.lblCalorias.AutoSize = true;
            this.lblCalorias.Location = new System.Drawing.Point(20, 55);
            this.lblCalorias.Name     = "lblCalorias";
            this.lblCalorias.TabIndex = 2;
            this.lblCalorias.Text     = "Calorias (kcal):";
            // 
            // txtCalorias
            // 
            this.txtCalorias.Location = new System.Drawing.Point(180, 52);
            this.txtCalorias.Name     = "txtCalorias";
            this.txtCalorias.Size     = new System.Drawing.Size(120, 20);
            this.txtCalorias.TabIndex = 3;
            // 
            // lblProteinas
            // 
            this.lblProteinas.AutoSize = true;
            this.lblProteinas.Location = new System.Drawing.Point(20, 90);
            this.lblProteinas.Name     = "lblProteinas";
            this.lblProteinas.TabIndex = 4;
            this.lblProteinas.Text     = "Proteinas (g):";
            // 
            // txtProteinas
            // 
            this.txtProteinas.Location = new System.Drawing.Point(180, 87);
            this.txtProteinas.Name     = "txtProteinas";
            this.txtProteinas.Size     = new System.Drawing.Size(120, 20);
            this.txtProteinas.TabIndex = 5;
            // 
            // lblCarbohidratos
            // 
            this.lblCarbohidratos.AutoSize = true;
            this.lblCarbohidratos.Location = new System.Drawing.Point(20, 125);
            this.lblCarbohidratos.Name     = "lblCarbohidratos";
            this.lblCarbohidratos.TabIndex = 6;
            this.lblCarbohidratos.Text     = "Carbohidratos (g):";
            // 
            // txtCarbohidratos
            // 
            this.txtCarbohidratos.Location = new System.Drawing.Point(180, 122);
            this.txtCarbohidratos.Name     = "txtCarbohidratos";
            this.txtCarbohidratos.Size     = new System.Drawing.Size(120, 20);
            this.txtCarbohidratos.TabIndex = 7;
            // 
            // lblGrasas
            // 
            this.lblGrasas.AutoSize = true;
            this.lblGrasas.Location = new System.Drawing.Point(20, 160);
            this.lblGrasas.Name     = "lblGrasas";
            this.lblGrasas.TabIndex = 8;
            this.lblGrasas.Text     = "Grasas (g):";
            // 
            // txtGrasas
            // 
            this.txtGrasas.Location = new System.Drawing.Point(180, 157);
            this.txtGrasas.Name     = "txtGrasas";
            this.txtGrasas.Size     = new System.Drawing.Size(120, 20);
            this.txtGrasas.TabIndex = 9;
            // 
            // lblPorcion
            // 
            this.lblPorcion.AutoSize = true;
            this.lblPorcion.Location = new System.Drawing.Point(20, 195);
            this.lblPorcion.Name     = "lblPorcion";
            this.lblPorcion.TabIndex = 10;
            this.lblPorcion.Text     = "Porcion (g):";
            // 
            // txtPorcion
            // 
            this.txtPorcion.Location = new System.Drawing.Point(180, 192);
            this.txtPorcion.Name     = "txtPorcion";
            this.txtPorcion.Size     = new System.Drawing.Size(120, 20);
            this.txtPorcion.TabIndex = 11;
            this.txtPorcion.Text     = "100";
            // 
            // lblPorcionInfo
            // 
            this.lblPorcionInfo.AutoSize  = true;
            this.lblPorcionInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPorcionInfo.Location  = new System.Drawing.Point(308, 195);
            this.lblPorcionInfo.Name      = "lblPorcionInfo";
            this.lblPorcionInfo.TabIndex  = 12;
            this.lblPorcionInfo.Text      = "Los valores nutricionales son por esta porcion";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(120, 240);
            this.btnGuardar.Name     = "btnGuardar";
            this.btnGuardar.Size     = new System.Drawing.Size(110, 30);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text     = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(245, 240);
            this.btnCancelar.Name     = "btnCancelar";
            this.btnCancelar.Size     = new System.Drawing.Size(110, 30);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text     = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAgregarAlimento
            // 
            this.AcceptButton        = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(460, 290);
            this.Controls.Add(this.lblPorcionInfo);
            this.Controls.Add(this.txtPorcion);
            this.Controls.Add(this.lblPorcion);
            this.Controls.Add(this.txtGrasas);
            this.Controls.Add(this.lblGrasas);
            this.Controls.Add(this.txtCarbohidratos);
            this.Controls.Add(this.lblCarbohidratos);
            this.Controls.Add(this.txtProteinas);
            this.Controls.Add(this.lblProteinas);
            this.Controls.Add(this.txtCalorias);
            this.Controls.Add(this.lblCalorias);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "FrmAgregarAlimento";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Agregar Alimento";
            this.ResumeLayout(false);
            this.PerformLayout();
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
