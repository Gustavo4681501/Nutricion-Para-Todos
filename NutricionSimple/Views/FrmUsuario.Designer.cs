namespace NutricionApp.Views
{
    partial class FrmUsuario
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombre    = new System.Windows.Forms.Label();
            this.lblPassword  = new System.Windows.Forms.Label();
            this.txtPassword  = new System.Windows.Forms.TextBox();
            this.txtNombre    = new System.Windows.Forms.TextBox();
            this.lblEdad      = new System.Windows.Forms.Label();
            this.numEdad      = new System.Windows.Forms.NumericUpDown();
            this.lblPeso      = new System.Windows.Forms.Label();
            this.numPeso      = new System.Windows.Forms.NumericUpDown();
            this.lblAltura    = new System.Windows.Forms.Label();
            this.numAltura    = new System.Windows.Forms.NumericUpDown();
            this.lblSexo      = new System.Windows.Forms.Label();
            this.cmbSexo      = new System.Windows.Forms.ComboBox();
            this.lblObjetivo  = new System.Windows.Forms.Label();
            this.cmbObjetivo  = new System.Windows.Forms.ComboBox();
            this.lblActividad = new System.Windows.Forms.Label();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.lblDieta     = new System.Windows.Forms.Label();
            this.cmbDieta     = new System.Windows.Forms.ComboBox();
            this.btnGuardar   = new System.Windows.Forms.Button();
            this.btnCancelar  = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numEdad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).BeginInit();
            this.SuspendLayout();

            this.lblNombre.AutoSize   = true; this.lblNombre.Location   = new System.Drawing.Point(12, 15);  this.lblNombre.Text   = "Nombre:";
            this.txtNombre.Location   = new System.Drawing.Point(130, 12); this.txtNombre.Name = "txtNombre"; this.txtNombre.Size = new System.Drawing.Size(220, 20); this.txtNombre.TabIndex = 0;
            this.lblEdad.AutoSize     = true; this.lblEdad.Location     = new System.Drawing.Point(12, 82);  this.lblEdad.Text     = "Edad (anos):";
            this.numEdad.Location     = new System.Drawing.Point(130, 78); this.numEdad.Minimum = new decimal(new int[]{10,0,0,0}); this.numEdad.Maximum = new decimal(new int[]{100,0,0,0}); this.numEdad.Value = new decimal(new int[]{25,0,0,0}); this.numEdad.Name = "numEdad"; this.numEdad.Size = new System.Drawing.Size(80, 20); this.numEdad.TabIndex = 1;
            this.lblPeso.AutoSize     = true; this.lblPeso.Location     = new System.Drawing.Point(12, 118);  this.lblPeso.Text     = "Peso (kg):";
            this.numPeso.DecimalPlaces= 1; this.numPeso.Location = new System.Drawing.Point(130, 114); this.numPeso.Minimum = new decimal(new int[]{30,0,0,0}); this.numPeso.Maximum = new decimal(new int[]{300,0,0,0}); this.numPeso.Value = new decimal(new int[]{70,0,0,0}); this.numPeso.Name = "numPeso"; this.numPeso.Size = new System.Drawing.Size(80, 20); this.numPeso.TabIndex = 2;
            this.lblAltura.AutoSize   = true; this.lblAltura.Location   = new System.Drawing.Point(12, 154); this.lblAltura.Text   = "Altura (cm):";
            this.numAltura.DecimalPlaces=1; this.numAltura.Location = new System.Drawing.Point(130, 150); this.numAltura.Minimum = new decimal(new int[]{100,0,0,0}); this.numAltura.Maximum = new decimal(new int[]{250,0,0,0}); this.numAltura.Value = new decimal(new int[]{170,0,0,0}); this.numAltura.Name = "numAltura"; this.numAltura.Size = new System.Drawing.Size(80, 20); this.numAltura.TabIndex = 3;
            this.lblSexo.AutoSize     = true; this.lblSexo.Location     = new System.Drawing.Point(12, 190); this.lblSexo.Text     = "Sexo:";
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbSexo.FormattingEnabled = true; this.cmbSexo.Items.AddRange(new object[]{"Masculino","Femenino"}); this.cmbSexo.Location = new System.Drawing.Point(130, 186); this.cmbSexo.Name = "cmbSexo"; this.cmbSexo.Size = new System.Drawing.Size(160, 21); this.cmbSexo.SelectedIndex = 0; this.cmbSexo.TabIndex = 4;
            this.lblObjetivo.AutoSize  = true; this.lblObjetivo.Location  = new System.Drawing.Point(12, 225); this.lblObjetivo.Text  = "Objetivo:";
            this.cmbObjetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbObjetivo.FormattingEnabled = true; this.cmbObjetivo.Items.AddRange(new object[]{"Mantener","Perder grasa","Ganar masa"}); this.cmbObjetivo.Location = new System.Drawing.Point(130, 221); this.cmbObjetivo.Name = "cmbObjetivo"; this.cmbObjetivo.Size = new System.Drawing.Size(160, 21); this.cmbObjetivo.SelectedIndex = 0; this.cmbObjetivo.TabIndex = 5;
            this.lblActividad.AutoSize = true; this.lblActividad.Location = new System.Drawing.Point(12, 260); this.lblActividad.Text = "Actividad:";
            this.cmbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbActividad.FormattingEnabled = true; this.cmbActividad.Items.AddRange(new object[]{"Sedentario","Ligero","Moderado","Muy activo","Extra activo"}); this.cmbActividad.Location = new System.Drawing.Point(130, 256); this.cmbActividad.Name = "cmbActividad"; this.cmbActividad.Size = new System.Drawing.Size(160, 21); this.cmbActividad.SelectedIndex = 0; this.cmbActividad.TabIndex = 6;
            this.lblDieta.AutoSize    = true; this.lblDieta.Location    = new System.Drawing.Point(12, 295); this.lblDieta.Text    = "Tipo de dieta:";
            this.cmbDieta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbDieta.FormattingEnabled = true; this.cmbDieta.Items.AddRange(new object[]{"Estandar","Keto","Vegetariano"}); this.cmbDieta.Location = new System.Drawing.Point(130, 291); this.cmbDieta.Name = "cmbDieta"; this.cmbDieta.Size = new System.Drawing.Size(160, 21); this.cmbDieta.SelectedIndex = 0; this.cmbDieta.TabIndex = 7;

            this.btnGuardar.Location = new System.Drawing.Point(100, 265); this.btnGuardar.Name = "btnGuardar"; this.btnGuardar.Size = new System.Drawing.Size(90, 26); this.btnGuardar.TabIndex = 8; this.btnGuardar.Text = "Guardar"; this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Location= new System.Drawing.Point(200, 265); this.btnCancelar.Name = "btnCancelar"; this.btnCancelar.Size = new System.Drawing.Size(90, 26); this.btnCancelar.TabIndex = 9; this.btnCancelar.Text = "Cancelar"; this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 376);
            this.Controls.Add(this.btnCancelar); this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbDieta); this.Controls.Add(this.lblDieta);
            this.Controls.Add(this.cmbActividad); this.Controls.Add(this.lblActividad);
            this.Controls.Add(this.cmbObjetivo); this.Controls.Add(this.lblObjetivo);
            this.Controls.Add(this.cmbSexo); this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.numAltura); this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.numPeso); this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.numEdad); this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtNombre); this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.numEdad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNombre, lblPassword, lblEdad, lblPeso, lblAltura, lblSexo, lblObjetivo, lblActividad, lblDieta;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown numEdad, numPeso, numAltura;
        private System.Windows.Forms.ComboBox cmbSexo, cmbObjetivo, cmbActividad, cmbDieta;
        private System.Windows.Forms.Button btnGuardar, btnCancelar;
    }
}
