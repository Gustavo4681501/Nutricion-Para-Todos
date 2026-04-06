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
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblEdad         = new System.Windows.Forms.Label();
            this.numEdad         = new System.Windows.Forms.NumericUpDown();
            this.lblPeso         = new System.Windows.Forms.Label();
            this.numPeso         = new System.Windows.Forms.NumericUpDown();
            this.lblAltura       = new System.Windows.Forms.Label();
            this.numAltura       = new System.Windows.Forms.NumericUpDown();
            this.lblObjetivo     = new System.Windows.Forms.Label();
            this.cmbObjetivo     = new System.Windows.Forms.ComboBox();
            this.lblActividad    = new System.Windows.Forms.Label();
            this.cmbActividad    = new System.Windows.Forms.ComboBox();
            this.lblDieta        = new System.Windows.Forms.Label();
            this.cmbDieta        = new System.Windows.Forms.ComboBox();
            this.lblSeparador    = new System.Windows.Forms.Label();
            this.lblCalorias     = new System.Windows.Forms.Label();
            this.lblMacros       = new System.Windows.Forms.Label();
            this.lblIMC          = new System.Windows.Forms.Label();
            this.btnGuardar      = new System.Windows.Forms.Button();
            this.btnCerrar       = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numEdad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).BeginInit();
            this.SuspendLayout();


            this.lblTitulo.Font      = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location  = new System.Drawing.Point(12, 10);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(460, 28);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Mi Perfil";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(20, 55);
            this.lblEdad.Name     = "lblEdad";
            this.lblEdad.TabIndex = 1;
            this.lblEdad.Text     = "Edad (anos):";


            this.numEdad.Location = new System.Drawing.Point(260, 52);
            this.numEdad.Minimum  = new decimal(new int[] { 10, 0, 0, 0 });
            this.numEdad.Maximum  = new decimal(new int[] { 100, 0, 0, 0 });
            this.numEdad.Name     = "numEdad";
            this.numEdad.Size     = new System.Drawing.Size(80, 20);
            this.numEdad.TabIndex = 2;
            this.numEdad.Value    = new decimal(new int[] { 25, 0, 0, 0 });

            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(20, 90);
            this.lblPeso.Name     = "lblPeso";
            this.lblPeso.TabIndex = 3;
            this.lblPeso.Text     = "Peso (kg):";

            this.numPeso.DecimalPlaces = 1;
            this.numPeso.Location      = new System.Drawing.Point(260, 87);
            this.numPeso.Minimum       = new decimal(new int[] { 30, 0, 0, 0 });
            this.numPeso.Maximum       = new decimal(new int[] { 300, 0, 0, 0 });
            this.numPeso.Name          = "numPeso";
            this.numPeso.Size          = new System.Drawing.Size(80, 20);
            this.numPeso.TabIndex      = 4;
            this.numPeso.Value         = new decimal(new int[] { 70, 0, 0, 0 });

            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(20, 125);
            this.lblAltura.Name     = "lblAltura";
            this.lblAltura.TabIndex = 5;
            this.lblAltura.Text     = "Altura (cm):";

            this.numAltura.DecimalPlaces = 1;
            this.numAltura.Location      = new System.Drawing.Point(260, 122);
            this.numAltura.Minimum       = new decimal(new int[] { 100, 0, 0, 0 });
            this.numAltura.Maximum       = new decimal(new int[] { 250, 0, 0, 0 });
            this.numAltura.Name          = "numAltura";
            this.numAltura.Size          = new System.Drawing.Size(80, 20);
            this.numAltura.TabIndex      = 6;
            this.numAltura.Value         = new decimal(new int[] { 170, 0, 0, 0 });

            this.lblObjetivo.AutoSize = true;
            this.lblObjetivo.Location = new System.Drawing.Point(20, 160);
            this.lblObjetivo.Name     = "lblObjetivo";
            this.lblObjetivo.TabIndex = 7;
            this.lblObjetivo.Text     = "Objetivo nutricional:";

            this.cmbObjetivo.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjetivo.FormattingEnabled = true;
            this.cmbObjetivo.Items.AddRange(new object[] { "Mantener peso", "Perder peso", "Ganar masa" });
            this.cmbObjetivo.Location      = new System.Drawing.Point(260, 157);
            this.cmbObjetivo.Name          = "cmbObjetivo";
            this.cmbObjetivo.SelectedIndex = 0;
            this.cmbObjetivo.Size          = new System.Drawing.Size(185, 21);
            this.cmbObjetivo.TabIndex      = 8;

            this.lblActividad.AutoSize = true;
            this.lblActividad.Location = new System.Drawing.Point(20, 197);
            this.lblActividad.Name     = "lblActividad";
            this.lblActividad.TabIndex = 9;
            this.lblActividad.Text     = "Nivel de actividad:";

            this.cmbActividad.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Items.AddRange(new object[]
            {
                "Sedentario (sin ejercicio)",
                "Ligero (1-3 dias/semana)",
                "Moderado (3-5 dias/semana)",
                "Activo (6-7 dias/semana)",
                "Muy activo (trabajo fisico intenso)"
            });
            this.cmbActividad.Location      = new System.Drawing.Point(260, 194);
            this.cmbActividad.Name          = "cmbActividad";
            this.cmbActividad.SelectedIndex = 2;
            this.cmbActividad.Size          = new System.Drawing.Size(185, 21);
            this.cmbActividad.TabIndex      = 10;

            this.lblDieta.AutoSize = true;
            this.lblDieta.Location = new System.Drawing.Point(20, 234);
            this.lblDieta.Name     = "lblDieta";
            this.lblDieta.TabIndex = 11;
            this.lblDieta.Text     = "Tipo de dieta:";

            this.cmbDieta.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDieta.FormattingEnabled = true;
            this.cmbDieta.Items.AddRange(new object[] { "Estandar", "Keto", "Vegetariano" });
            this.cmbDieta.Location      = new System.Drawing.Point(260, 231);
            this.cmbDieta.Name          = "cmbDieta";
            this.cmbDieta.SelectedIndex = 0;
            this.cmbDieta.Size          = new System.Drawing.Size(185, 21);
            this.cmbDieta.TabIndex      = 12;

            this.lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparador.Location    = new System.Drawing.Point(20, 265);
            this.lblSeparador.Name        = "lblSeparador";
            this.lblSeparador.Size        = new System.Drawing.Size(430, 2);
            this.lblSeparador.TabIndex    = 13;


            this.lblCalorias.Font     = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCalorias.Location = new System.Drawing.Point(20, 277);
            this.lblCalorias.Name     = "lblCalorias";
            this.lblCalorias.Size     = new System.Drawing.Size(430, 22);
            this.lblCalorias.TabIndex = 14;
            this.lblCalorias.Text     = "Calorias recomendadas: -";

            this.lblMacros.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblMacros.Location = new System.Drawing.Point(20, 302);
            this.lblMacros.Name     = "lblMacros";
            this.lblMacros.Size     = new System.Drawing.Size(430, 22);
            this.lblMacros.TabIndex = 15;
            this.lblMacros.Text     = "Macros: -";

            this.lblIMC.Font     = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblIMC.Location = new System.Drawing.Point(20, 327);
            this.lblIMC.Name     = "lblIMC";
            this.lblIMC.Size     = new System.Drawing.Size(430, 22);
            this.lblIMC.TabIndex = 16;
            this.lblIMC.Text     = "IMC: -";

            this.btnGuardar.Location = new System.Drawing.Point(150, 365);
            this.btnGuardar.Name     = "btnGuardar";
            this.btnGuardar.Size     = new System.Drawing.Size(110, 28);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text     = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCerrar.Location = new System.Drawing.Point(280, 365);
            this.btnCerrar.Name     = "btnCerrar";
            this.btnCerrar.Size     = new System.Drawing.Size(110, 28);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(484, 410);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblIMC);
            this.Controls.Add(this.lblMacros);
            this.Controls.Add(this.lblCalorias);
            this.Controls.Add(this.lblSeparador);
            this.Controls.Add(this.cmbDieta);
            this.Controls.Add(this.lblDieta);
            this.Controls.Add(this.cmbActividad);
            this.Controls.Add(this.lblActividad);
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
        private System.Windows.Forms.Label          lblActividad;
        private System.Windows.Forms.ComboBox       cmbActividad;
        private System.Windows.Forms.Label          lblDieta;
        private System.Windows.Forms.ComboBox       cmbDieta;
        private System.Windows.Forms.Label          lblSeparador;
        private System.Windows.Forms.Label          lblCalorias;
        private System.Windows.Forms.Label          lblMacros;
        private System.Windows.Forms.Label          lblIMC;
        private System.Windows.Forms.Button         btnGuardar;
        private System.Windows.Forms.Button         btnCerrar;
    }
}
