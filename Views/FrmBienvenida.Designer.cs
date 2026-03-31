namespace NutricionApp.Views
{
    partial class FrmBienvenida
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Releases the unmanaged resources used by the component and optionally releases the managed resources.
        /// </summary>
        /// <remarks>This method is called by the public Dispose() method and the finalizer. When disposing
        /// is true, this method disposes all managed resources referenced by this component. When disposing is false,
        /// only unmanaged resources are released.</remarks>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblBienvenida = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            grpMenus = new System.Windows.Forms.GroupBox();
            btnMenus = new System.Windows.Forms.Button();
            lblMenusDesc = new System.Windows.Forms.Label();
            grpAlimentos = new System.Windows.Forms.GroupBox();
            btnAlimentos = new System.Windows.Forms.Button();
            lblAlimentosDesc = new System.Windows.Forms.Label();
            grpEstadisticas = new System.Windows.Forms.GroupBox();
            btnEstadisticas = new System.Windows.Forms.Button();
            lblEstDesc = new System.Windows.Forms.Label();
            grpPerfil = new System.Windows.Forms.GroupBox();
            btnPerfil = new System.Windows.Forms.Button();
            lblPerfilDesc = new System.Windows.Forms.Label();
            btnSalir = new System.Windows.Forms.Button();
            grpMenus.SuspendLayout();
            grpAlimentos.SuspendLayout();
            grpEstadisticas.SuspendLayout();
            grpPerfil.SuspendLayout();
            SuspendLayout();
            // lblBienvenida
            lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            lblBienvenida.Location = new System.Drawing.Point(20, 29);
            lblBienvenida.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new System.Drawing.Size(933, 62);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido!";
            lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // lblSubtitulo
            lblSubtitulo.ForeColor = System.Drawing.SystemColors.GrayText;
            lblSubtitulo.Location = new System.Drawing.Point(20, 96);
            lblSubtitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(933, 35);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Selecciona una opcion para comenzar";
            lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // grpMenus
            grpMenus.Controls.Add(btnMenus);
            grpMenus.Controls.Add(lblMenusDesc);
            grpMenus.Location = new System.Drawing.Point(33, 154);
            grpMenus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpMenus.Name = "grpMenus";
            grpMenus.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpMenus.Size = new System.Drawing.Size(417, 212);
            grpMenus.TabIndex = 2;
            grpMenus.TabStop = false;
            grpMenus.Text = "Mis Menus";
            // btnMenus
            btnMenus.Location = new System.Drawing.Point(117, 131);
            btnMenus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnMenus.Name = "btnMenus";
            btnMenus.Size = new System.Drawing.Size(183, 54);
            btnMenus.TabIndex = 1;
            btnMenus.Text = "Ver menus";
            btnMenus.UseVisualStyleBackColor = true;
            btnMenus.Click += btnMenus_Click;
            // lblMenusDesc
            lblMenusDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            lblMenusDesc.Location = new System.Drawing.Point(13, 42);
            lblMenusDesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblMenusDesc.Name = "lblMenusDesc";
            lblMenusDesc.Size = new System.Drawing.Size(390, 77);
            lblMenusDesc.TabIndex = 0;
            lblMenusDesc.Text = "Crea y administra tus menus diarios de comida.";
            // grpAlimentos
            grpAlimentos.Controls.Add(btnAlimentos);
            grpAlimentos.Controls.Add(lblAlimentosDesc);
            grpAlimentos.Location = new System.Drawing.Point(517, 154);
            grpAlimentos.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpAlimentos.Name = "grpAlimentos";
            grpAlimentos.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpAlimentos.Size = new System.Drawing.Size(417, 212);
            grpAlimentos.TabIndex = 3;
            grpAlimentos.TabStop = false;
            grpAlimentos.Text = "Catalogo de Alimentos";
            // btnAlimentos
            btnAlimentos.Location = new System.Drawing.Point(117, 131);
            btnAlimentos.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnAlimentos.Name = "btnAlimentos";
            btnAlimentos.Size = new System.Drawing.Size(183, 54);
            btnAlimentos.TabIndex = 1;
            btnAlimentos.Text = "Ver catalogo";
            btnAlimentos.UseVisualStyleBackColor = true;
            btnAlimentos.Click += btnAlimentos_Click;
            // lblAlimentosDesc
            lblAlimentosDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            lblAlimentosDesc.Location = new System.Drawing.Point(13, 42);
            lblAlimentosDesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblAlimentosDesc.Name = "lblAlimentosDesc";
            lblAlimentosDesc.Size = new System.Drawing.Size(390, 77);
            lblAlimentosDesc.TabIndex = 0;
            lblAlimentosDesc.Text = "Consulta y agrega alimentos con sus valores nutricionales.";
            // grpEstadisticas
            grpEstadisticas.Controls.Add(btnEstadisticas);
            grpEstadisticas.Controls.Add(lblEstDesc);
            grpEstadisticas.Location = new System.Drawing.Point(33, 394);
            grpEstadisticas.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpEstadisticas.Name = "grpEstadisticas";
            grpEstadisticas.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpEstadisticas.Size = new System.Drawing.Size(417, 212);
            grpEstadisticas.TabIndex = 4;
            grpEstadisticas.TabStop = false;
            grpEstadisticas.Text = "Estadisticas";
            // btnEstadisticas  <-- habilitado en este avance
            btnEstadisticas.Enabled = true;
            btnEstadisticas.Location = new System.Drawing.Point(117, 131);
            btnEstadisticas.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnEstadisticas.Name = "btnEstadisticas";
            btnEstadisticas.Size = new System.Drawing.Size(183, 54);
            btnEstadisticas.TabIndex = 1;
            btnEstadisticas.Text = "Ver estadisticas";
            btnEstadisticas.UseVisualStyleBackColor = true;
            btnEstadisticas.Click += btnEstadisticas_Click;
            // lblEstDesc
            lblEstDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            lblEstDesc.Location = new System.Drawing.Point(13, 42);
            lblEstDesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblEstDesc.Name = "lblEstDesc";
            lblEstDesc.Size = new System.Drawing.Size(390, 77);
            lblEstDesc.TabIndex = 0;
            lblEstDesc.Text = "Revisa tu consumo calorico diario y mensual.";
            // grpPerfil
            grpPerfil.Controls.Add(btnPerfil);
            grpPerfil.Controls.Add(lblPerfilDesc);
            grpPerfil.Location = new System.Drawing.Point(517, 394);
            grpPerfil.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpPerfil.Name = "grpPerfil";
            grpPerfil.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            grpPerfil.Size = new System.Drawing.Size(417, 212);
            grpPerfil.TabIndex = 5;
            grpPerfil.TabStop = false;
            grpPerfil.Text = "Mi Perfil";
            // btnPerfil
            btnPerfil.Location = new System.Drawing.Point(117, 131);
            btnPerfil.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnPerfil.Name = "btnPerfil";
            btnPerfil.Size = new System.Drawing.Size(183, 54);
            btnPerfil.TabIndex = 1;
            btnPerfil.Text = "Ver mi perfil";
            btnPerfil.UseVisualStyleBackColor = true;
            btnPerfil.Click += btnPerfil_Click_1;
            // lblPerfilDesc
            lblPerfilDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            lblPerfilDesc.Location = new System.Drawing.Point(13, 42);
            lblPerfilDesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblPerfilDesc.Name = "lblPerfilDesc";
            lblPerfilDesc.Size = new System.Drawing.Size(390, 77);
            lblPerfilDesc.TabIndex = 0;
            lblPerfilDesc.Text = "Configura tu peso, altura, objetivo y tipo de dieta.";
            // btnSalir
            btnSalir.Location = new System.Drawing.Point(383, 638);
            btnSalir.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(200, 54);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Cerrar sesion";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // FrmBienvenida
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(973, 721);
            Controls.Add(btnSalir);
            Controls.Add(grpPerfil);
            Controls.Add(grpEstadisticas);
            Controls.Add(grpAlimentos);
            Controls.Add(grpMenus);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblBienvenida);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FrmBienvenida";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Nutricion Para Todos";
            grpMenus.ResumeLayout(false);
            grpAlimentos.ResumeLayout(false);
            grpEstadisticas.ResumeLayout(false);
            grpPerfil.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.GroupBox grpMenus;
        private System.Windows.Forms.Label lblMenusDesc;
        private System.Windows.Forms.Button btnMenus;
        private System.Windows.Forms.GroupBox grpAlimentos;
        private System.Windows.Forms.Label lblAlimentosDesc;
        private System.Windows.Forms.Button btnAlimentos;
        private System.Windows.Forms.GroupBox grpEstadisticas;
        private System.Windows.Forms.Label lblEstDesc;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.GroupBox grpPerfil;
        private System.Windows.Forms.Label lblPerfilDesc;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Button btnSalir;
    }
}
