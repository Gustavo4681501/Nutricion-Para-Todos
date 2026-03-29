namespace NutricionApp.Views
{
    partial class FrmPerfil
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
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblEdad        = new System.Windows.Forms.Label();
            this.numEdad        = new System.Windows.Forms.NumericUpDown();
            this.lblPeso        = new System.Windows.Forms.Label();
            this.numPeso        = new System.Windows.Forms.NumericUpDown();
            this.lblAltura      = new System.Windows.Forms.Label();
            this.numAltura      = new System.Windows.Forms.NumericUpDown();
            this.lblObjetivo    = new System.Windows.Forms.Label();
            this.cmbObjetivo    = new System.Windows.Forms.ComboBox();
            this.lblSeparador   = new System.Windows.Forms.Label();
            this.lblCalorias    = new System.Windows.Forms.Label();
            this.lblIMC         = new System.Windows.Forms.Label();
            this.btnGuardar     = new System.Windows.Forms.Button();
            this.btnCerrar      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numEdad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font      = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location  = new System.Drawing.Point(12, 10);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(360, 28);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Mi Perfil";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(20, 55);
            this.lblEdad.Name     = "lblEdad";
            this.lblEdad.TabIndex = 1;
            this.lblEdad.Text     = "Edad (anos):";
            // 
            // numEdad
            // 
            this.numEdad.Location = new System.Drawing.Point(200, 52);
            this.numEdad.Minimum  = new decimal(new int[] { 10, 0, 0, 0 });
            this.numEdad.Maximum  = new decimal(new int[] { 100, 0, 0, 0 });
            this.numEdad.Name     = "numEdad";
            this.numEdad.Size     = new System.Drawing.Size(80, 20);
            this.numEdad.TabIndex = 2;
            this.numEdad.Value    = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(20, 90);
            this.lblPeso.Name     = "lblPeso";
            this.lblPeso.TabIndex = 3;
            this.lblPeso.Text     = "Peso (kg):";
            // 
            // numPeso
            // 
            this.numPeso.DecimalPlaces = 1;
            this.numPeso.Location      = new System.Drawing.Point(200, 87);
            this.numPeso.Minimum       = new decimal(new int[] { 30, 0, 0, 0 });
            this.numPeso.Maximum       = new decimal(new int[] { 300, 0, 0, 0 });
            this.numPeso.Name          = "numPeso";
            this.numPeso.Size          = new System.Drawing.Size(80, 20);
            this.numPeso.TabIndex      = 4;
            this.numPeso.Value         = new decimal(new int[] { 70, 0, 0, 0 });
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(20, 125);
            this.lblAltura.Name     = "lblAltura";
            this.lblAltura.TabIndex = 5;
            this.lblAltura.Text     = "Altura (cm):";
            // 
            // numAltura
            // 
            this.numAltura.DecimalPlaces = 1;
            this.numAltura.Location      = new System.Drawing.Point(200, 122);
            this.numAltura.Minimum       = new decimal(new int[] { 100, 0, 0, 0 });
            this.numAltura.Maximum       = new decimal(new int[] { 250, 0, 0, 0 });
            this.numAltura.Name          = "numAltura";
            this.numAltura.Size          = new System.Drawing.Size(80, 20);
            this.numAltura.TabIndex      = 6;
            this.numAltura.Value         = new decimal(new int[] { 170, 0, 0, 0 });
            // 
            // lblObjetivo
            // 
            this.lblObjetivo.AutoSize = true;
            this.lblObjetivo.Location = new System.Drawing.Point(20, 160);
            this.lblObjetivo.Name     = "lblObjetivo";
            this.lblObjetivo.TabIndex = 7;
            this.lblObjetivo.Text     = "Objetivo:";
            // 
            // cmbObjetivo
            // 
            this.cmbObjetivo.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjetivo.FormattingEnabled = true;
            this.cmbObjetivo.Items.AddRange(new object[] { "Mantener peso", "Perder peso", "Ganar masa" });
            this.cmbObjetivo.Location      = new System.Drawing.Point(200, 157);
            this.cmbObjetivo.Name          = "cmbObjetivo";
            this.cmbObjetivo.SelectedIndex = 0;
            this.cmbObjetivo.Size          = new System.Drawing.Size(160, 21);
            this.cmbObjetivo.TabIndex      = 8;
            // 
            // lblSeparador
            // 
            this.lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparador.Location    = new System.Drawing.Point(20, 195);
            this.lblSeparador.Name        = "lblSeparador";
            this.lblSeparador.Size        = new System.Drawing.Size(355, 2);
            this.lblSeparador.TabIndex    = 9;
            // 
            // lblCalorias
            // 
            this.lblCalorias.Font     = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCalorias.Location = new System.Drawing.Point(20, 207);
            this.lblCalorias.Name     = "lblCalorias";
            this.lblCalorias.Size     = new System.Drawing.Size(355, 22);
            this.lblCalorias.TabIndex = 10;
            this.lblCalorias.Text     = "Calorias recomendadas: —";
            // 
            // lblIMC
            // 
            this.lblIMC.Font     = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblIMC.Location = new System.Drawing.Point(20, 232);
            this.lblIMC.Name     = "lblIMC";
            this.lblIMC.Size     = new System.Drawing.Size(355, 22);
            this.lblIMC.TabIndex = 11;
            this.lblIMC.Text     = "IMC: —";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(120, 270);
            this.btnGuardar.Name     = "btnGuardar";
            this.btnGuardar.Size     = new System.Drawing.Size(110, 28);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text     = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(245, 270);
            this.btnCerrar.Name     = "btnCerrar";
            this.btnCerrar.Size     = new System.Drawing.Size(110, 28);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(384, 316);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblIMC);
            this.Controls.Add(this.lblCalorias);
            this.Controls.Add(this.lblSeparador);
            this.Controls.Add(this.cmbObjetivo);
            this.Controls.Add(this.lblObjetivo);
            this.Controls.Add(this.numAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.numPeso);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.numEdad);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "FrmPerfil";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Mi Perfil";
            ((System.ComponentModel.ISupportInitialize)(this.numEdad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label          lblTitulo;
        private System.Windows.Forms.Label          lblEdad;
        private System.Windows.Forms.NumericUpDown  numEdad;
        private System.Windows.Forms.Label          lblPeso;
        private System.Windows.Forms.NumericUpDown  numPeso;
        private System.Windows.Forms.Label          lblAltura;
        private System.Windows.Forms.NumericUpDown  numAltura;
        private System.Windows.Forms.Label          lblObjetivo;
        private System.Windows.Forms.ComboBox       cmbObjetivo;
        private System.Windows.Forms.Label          lblSeparador;
        private System.Windows.Forms.Label          lblCalorias;
        private System.Windows.Forms.Label          lblIMC;
        private System.Windows.Forms.Button         btnGuardar;
        private System.Windows.Forms.Button         btnCerrar;
    }
}
