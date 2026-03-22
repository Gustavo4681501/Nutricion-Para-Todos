namespace NutricionApp.Views
{
    partial class FrmAlimento
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
            this.txtNombre    = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblCal       = new System.Windows.Forms.Label();
            this.numCal       = new System.Windows.Forms.NumericUpDown();
            this.lblProt      = new System.Windows.Forms.Label();
            this.numProt      = new System.Windows.Forms.NumericUpDown();
            this.lblCarbs     = new System.Windows.Forms.Label();
            this.numCarbs     = new System.Windows.Forms.NumericUpDown();
            this.lblGrasas    = new System.Windows.Forms.Label();
            this.numGrasas    = new System.Windows.Forms.NumericUpDown();
            this.lblPorcion   = new System.Windows.Forms.Label();
            this.numPorcion   = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar   = new System.Windows.Forms.Button();
            this.btnCancelar  = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarbs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGrasas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcion)).BeginInit();
            this.SuspendLayout();

            this.lblNombre.AutoSize    = true; this.lblNombre.Location    = new System.Drawing.Point(12, 15);  this.lblNombre.Text    = "Nombre:";
            this.txtNombre.Location    = new System.Drawing.Point(150, 12); this.txtNombre.Name = "txtNombre"; this.txtNombre.Size = new System.Drawing.Size(200, 20); this.txtNombre.TabIndex = 0;
            this.lblCategoria.AutoSize = true; this.lblCategoria.Location = new System.Drawing.Point(12, 45);  this.lblCategoria.Text = "Categoria:";
            this.txtCategoria.Location = new System.Drawing.Point(150, 42); this.txtCategoria.Name = "txtCategoria"; this.txtCategoria.Size = new System.Drawing.Size(200, 20); this.txtCategoria.TabIndex = 1;
            this.lblCal.AutoSize       = true; this.lblCal.Location       = new System.Drawing.Point(12, 75);  this.lblCal.Text       = "Calorias (kcal):";
            this.numCal.DecimalPlaces  = 1; this.numCal.Maximum = new decimal(new int[]{5000,0,0,0}); this.numCal.Location = new System.Drawing.Point(150, 72); this.numCal.Name = "numCal"; this.numCal.Size = new System.Drawing.Size(100, 20); this.numCal.TabIndex = 2;
            this.lblProt.AutoSize      = true; this.lblProt.Location      = new System.Drawing.Point(12, 105); this.lblProt.Text      = "Proteinas (g):";
            this.numProt.DecimalPlaces = 1; this.numProt.Maximum = new decimal(new int[]{500,0,0,0}); this.numProt.Location = new System.Drawing.Point(150, 102); this.numProt.Name = "numProt"; this.numProt.Size = new System.Drawing.Size(100, 20); this.numProt.TabIndex = 3;
            this.lblCarbs.AutoSize     = true; this.lblCarbs.Location     = new System.Drawing.Point(12, 135); this.lblCarbs.Text     = "Carbohidratos (g):";
            this.numCarbs.DecimalPlaces= 1; this.numCarbs.Maximum = new decimal(new int[]{500,0,0,0}); this.numCarbs.Location = new System.Drawing.Point(150, 132); this.numCarbs.Name = "numCarbs"; this.numCarbs.Size = new System.Drawing.Size(100, 20); this.numCarbs.TabIndex = 4;
            this.lblGrasas.AutoSize    = true; this.lblGrasas.Location    = new System.Drawing.Point(12, 165); this.lblGrasas.Text    = "Grasas (g):";
            this.numGrasas.DecimalPlaces=1; this.numGrasas.Maximum = new decimal(new int[]{500,0,0,0}); this.numGrasas.Location = new System.Drawing.Point(150, 162); this.numGrasas.Name = "numGrasas"; this.numGrasas.Size = new System.Drawing.Size(100, 20); this.numGrasas.TabIndex = 5;
            this.lblPorcion.AutoSize   = true; this.lblPorcion.Location   = new System.Drawing.Point(12, 195); this.lblPorcion.Text   = "Porcion base (g):";
            this.numPorcion.Minimum    = new decimal(new int[]{1,0,0,0}); this.numPorcion.Maximum = new decimal(new int[]{1000,0,0,0}); this.numPorcion.Value = new decimal(new int[]{100,0,0,0}); this.numPorcion.Location = new System.Drawing.Point(150, 192); this.numPorcion.Name = "numPorcion"; this.numPorcion.Size = new System.Drawing.Size(100, 20); this.numPorcion.TabIndex = 6;

            this.btnGuardar.Location  = new System.Drawing.Point(100, 232); this.btnGuardar.Name = "btnGuardar"; this.btnGuardar.Size = new System.Drawing.Size(90, 26); this.btnGuardar.TabIndex = 7; this.btnGuardar.Text = "Guardar"; this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Location = new System.Drawing.Point(200, 232); this.btnCancelar.Name = "btnCancelar"; this.btnCancelar.Size = new System.Drawing.Size(90, 26); this.btnCancelar.TabIndex = 8; this.btnCancelar.Text = "Cancelar"; this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 276);
            this.Controls.Add(this.btnCancelar); this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.numPorcion); this.Controls.Add(this.lblPorcion);
            this.Controls.Add(this.numGrasas);  this.Controls.Add(this.lblGrasas);
            this.Controls.Add(this.numCarbs);   this.Controls.Add(this.lblCarbs);
            this.Controls.Add(this.numProt);    this.Controls.Add(this.lblProt);
            this.Controls.Add(this.numCal);     this.Controls.Add(this.lblCal);
            this.Controls.Add(this.txtCategoria); this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtNombre);  this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.Name = "FrmAlimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alimento";
            ((System.ComponentModel.ISupportInitialize)(this.numCal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarbs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGrasas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcion)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNombre, lblCategoria, lblCal, lblProt, lblCarbs, lblGrasas, lblPorcion;
        private System.Windows.Forms.TextBox txtNombre, txtCategoria;
        private System.Windows.Forms.NumericUpDown numCal, numProt, numCarbs, numGrasas, numPorcion;
        private System.Windows.Forms.Button btnGuardar, btnCancelar;
    }
}
