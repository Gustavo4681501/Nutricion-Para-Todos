namespace NutricionApp.Views
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsuario          = new System.Windows.Forms.Label();
            this.btnEditarPerfil     = new System.Windows.Forms.Button();
            this.btnCambiarUsuario   = new System.Windows.Forms.Button();
            this.tabControl1         = new System.Windows.Forms.TabControl();
            // tabs
            this.tabAlimentos        = new System.Windows.Forms.TabPage();
            this.tabMenus            = new System.Windows.Forms.TabPage();
            this.tabInfo             = new System.Windows.Forms.TabPage();
            this.tabEstadisticas     = new System.Windows.Forms.TabPage();
            // tab alimentos controls
            this.lblBuscarAlimento   = new System.Windows.Forms.Label();
            this.txtBuscarAlimento   = new System.Windows.Forms.TextBox();
            this.btnAgregarAlimento  = new System.Windows.Forms.Button();
            this.btnEditarAlimento   = new System.Windows.Forms.Button();
            this.btnEliminarAlimento = new System.Windows.Forms.Button();
            this.dgvAlimentos        = new System.Windows.Forms.DataGridView();
            this.aColId              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aColNombre          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aColCat             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aColCal             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aColProt            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aColCarbs           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aColGrasas          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aColPorc            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            // tab menus controls
            this.lblMenuDesde        = new System.Windows.Forms.Label();
            this.dtpMenuDesde        = new System.Windows.Forms.DateTimePicker();
            this.lblMenuHasta        = new System.Windows.Forms.Label();
            this.dtpMenuHasta        = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarMenus      = new System.Windows.Forms.Button();
            this.btnAgregarMenu      = new System.Windows.Forms.Button();
            this.btnEditarMenu       = new System.Windows.Forms.Button();
            this.btnEliminarMenu     = new System.Windows.Forms.Button();
            this.dgvMenus            = new System.Windows.Forms.DataGridView();
            this.mColId              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColFecha           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColItems           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColCal             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColProt            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColCarbs           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mColGrasas          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            // tab info controls
            this.grpMetabolismo      = new System.Windows.Forms.GroupBox();
            this.lblTMB              = new System.Windows.Forms.Label();
            this.lblTDEE             = new System.Windows.Forms.Label();
            this.lblObj              = new System.Windows.Forms.Label();
            this.lblIMC              = new System.Windows.Forms.Label();
            this.grpMacros           = new System.Windows.Forms.GroupBox();
            this.lblProt             = new System.Windows.Forms.Label();
            this.lblCarbs            = new System.Windows.Forms.Label();
            this.lblGrasas           = new System.Windows.Forms.Label();
            this.lblDieta            = new System.Windows.Forms.Label();
            // tab estadisticas controls
            this.grpHoy              = new System.Windows.Forms.GroupBox();
            this.lblEstHoy           = new System.Windows.Forms.Label();
            this.lblEstFalta         = new System.Windows.Forms.Label();
            this.pbHoy               = new System.Windows.Forms.ProgressBar();
            this.grpDiario           = new System.Windows.Forms.GroupBox();
            this.lblEstDesde         = new System.Windows.Forms.Label();
            this.dtpEstDesde         = new System.Windows.Forms.DateTimePicker();
            this.lblEstHasta         = new System.Windows.Forms.Label();
            this.dtpEstHasta         = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarDiario     = new System.Windows.Forms.Button();
            this.dgvEstDiario        = new System.Windows.Forms.DataGridView();
            this.eColFecha           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eColCal             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eColMeta            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eColPct             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eColEstado          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMensual          = new System.Windows.Forms.GroupBox();
            this.lblMesLabel         = new System.Windows.Forms.Label();
            this.cmbMes              = new System.Windows.Forms.ComboBox();
            this.lblAnioLabel        = new System.Windows.Forms.Label();
            this.numAnio             = new System.Windows.Forms.NumericUpDown();
            this.btnBuscarMensual    = new System.Windows.Forms.Button();
            this.lblMensual          = new System.Windows.Forms.Label();

            this.tabControl1.SuspendLayout();
            this.tabAlimentos.SuspendLayout();
            this.tabMenus.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabEstadisticas.SuspendLayout();
            this.grpMetabolismo.SuspendLayout();
            this.grpMacros.SuspendLayout();
            this.grpHoy.SuspendLayout();
            this.grpDiario.SuspendLayout();
            this.grpMensual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlimentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            this.SuspendLayout();

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(8, 8);
            this.lblUsuario.Name     = "lblUsuario";
            this.lblUsuario.Text     = "Usuario:";

            // btnEditarPerfil
            this.btnEditarPerfil.Location = new System.Drawing.Point(700, 4);
            this.btnEditarPerfil.Name     = "btnEditarPerfil";
            this.btnEditarPerfil.Size     = new System.Drawing.Size(100, 24);
            this.btnEditarPerfil.Text     = "Editar perfil";
            this.btnEditarPerfil.Click   += new System.EventHandler(this.btnEditarPerfil_Click);

            // btnCambiarUsuario
            this.btnCambiarUsuario.Location = new System.Drawing.Point(808, 4);
            this.btnCambiarUsuario.Name     = "btnCambiarUsuario";
            this.btnCambiarUsuario.Size     = new System.Drawing.Size(120, 24);
            this.btnCambiarUsuario.Text     = "Cambiar usuario";
            this.btnCambiarUsuario.Click   += new System.EventHandler(this.btnCambiarUsuario_Click);

            // ── TAB ALIMENTOS ─────────────────────────────────────────────────
            // lblBuscarAlimento
            this.lblBuscarAlimento.AutoSize = true;
            this.lblBuscarAlimento.Location = new System.Drawing.Point(6, 8);
            this.lblBuscarAlimento.Name     = "lblBuscarAlimento";
            this.lblBuscarAlimento.Text     = "Buscar:";
            // txtBuscarAlimento
            this.txtBuscarAlimento.Location      = new System.Drawing.Point(55, 5);
            this.txtBuscarAlimento.Name          = "txtBuscarAlimento";
            this.txtBuscarAlimento.Size          = new System.Drawing.Size(220, 20);
            this.txtBuscarAlimento.TabIndex      = 0;
            this.txtBuscarAlimento.TextChanged  += new System.EventHandler(this.txtBuscarAlimento_TextChanged);
            // btnAgregarAlimento
            this.btnAgregarAlimento.Location = new System.Drawing.Point(285, 4);
            this.btnAgregarAlimento.Name     = "btnAgregarAlimento";
            this.btnAgregarAlimento.Size     = new System.Drawing.Size(80, 24);
            this.btnAgregarAlimento.TabIndex = 1;
            this.btnAgregarAlimento.Text     = "Agregar";
            this.btnAgregarAlimento.Click   += new System.EventHandler(this.btnAgregarAlimento_Click);
            // btnEditarAlimento
            this.btnEditarAlimento.Location = new System.Drawing.Point(372, 4);
            this.btnEditarAlimento.Name     = "btnEditarAlimento";
            this.btnEditarAlimento.Size     = new System.Drawing.Size(80, 24);
            this.btnEditarAlimento.TabIndex = 2;
            this.btnEditarAlimento.Text     = "Editar";
            this.btnEditarAlimento.Click   += new System.EventHandler(this.btnEditarAlimento_Click);
            // btnEliminarAlimento
            this.btnEliminarAlimento.Location = new System.Drawing.Point(459, 4);
            this.btnEliminarAlimento.Name     = "btnEliminarAlimento";
            this.btnEliminarAlimento.Size     = new System.Drawing.Size(80, 24);
            this.btnEliminarAlimento.TabIndex = 3;
            this.btnEliminarAlimento.Text     = "Eliminar";
            this.btnEliminarAlimento.Click   += new System.EventHandler(this.btnEliminarAlimento_Click);
            // aCol definitions
            this.aColId.HeaderText    = "ID";     this.aColId.Name    = "aColId";    this.aColId.Width    = 35;  this.aColId.ReadOnly = true;
            this.aColNombre.HeaderText= "Nombre"; this.aColNombre.Name= "aColNombre";this.aColNombre.Width= 160; this.aColNombre.ReadOnly= true;
            this.aColCat.HeaderText   = "Cat.";   this.aColCat.Name   = "aColCat";   this.aColCat.Width   = 80;  this.aColCat.ReadOnly = true;
            this.aColCal.HeaderText   = "Kcal";   this.aColCal.Name   = "aColCal";   this.aColCal.Width   = 55;  this.aColCal.ReadOnly = true;
            this.aColProt.HeaderText  = "Prot.";  this.aColProt.Name  = "aColProt";  this.aColProt.Width  = 55;  this.aColProt.ReadOnly= true;
            this.aColCarbs.HeaderText = "Carbs."; this.aColCarbs.Name = "aColCarbs"; this.aColCarbs.Width = 55;  this.aColCarbs.ReadOnly= true;
            this.aColGrasas.HeaderText= "Grasas"; this.aColGrasas.Name= "aColGrasas";this.aColGrasas.Width= 55; this.aColGrasas.ReadOnly= true;
            this.aColPorc.HeaderText  = "Porc.";  this.aColPorc.Name  = "aColPorc";  this.aColPorc.Width  = 55;  this.aColPorc.ReadOnly= true;
            // dgvAlimentos
            this.dgvAlimentos.AllowUserToAddRows    = false;
            this.dgvAlimentos.AllowUserToDeleteRows = false;
            this.dgvAlimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.aColId, this.aColNombre, this.aColCat, this.aColCal,
                this.aColProt, this.aColCarbs, this.aColGrasas, this.aColPorc });
            this.dgvAlimentos.Location         = new System.Drawing.Point(6, 34);
            this.dgvAlimentos.MultiSelect      = false;
            this.dgvAlimentos.Name             = "dgvAlimentos";
            this.dgvAlimentos.ReadOnly         = true;
            this.dgvAlimentos.RowHeadersVisible = false;
            this.dgvAlimentos.SelectionMode    = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlimentos.Size             = new System.Drawing.Size(910, 490);
            this.dgvAlimentos.TabIndex         = 4;
            // tabAlimentos
            this.tabAlimentos.Controls.Add(this.dgvAlimentos);
            this.tabAlimentos.Controls.Add(this.btnEliminarAlimento);
            this.tabAlimentos.Controls.Add(this.btnEditarAlimento);
            this.tabAlimentos.Controls.Add(this.btnAgregarAlimento);
            this.tabAlimentos.Controls.Add(this.txtBuscarAlimento);
            this.tabAlimentos.Controls.Add(this.lblBuscarAlimento);
            this.tabAlimentos.Location = new System.Drawing.Point(4, 22);
            this.tabAlimentos.Name     = "tabAlimentos";
            this.tabAlimentos.Size     = new System.Drawing.Size(924, 534);
            this.tabAlimentos.TabIndex = 0;
            this.tabAlimentos.Text     = "Alimentos";
            this.tabAlimentos.UseVisualStyleBackColor = true;

            // ── TAB MENUS ─────────────────────────────────────────────────────
            this.lblMenuDesde.AutoSize = true;
            this.lblMenuDesde.Location = new System.Drawing.Point(6, 8);
            this.lblMenuDesde.Name     = "lblMenuDesde";
            this.lblMenuDesde.Text     = "Desde:";
            this.dtpMenuDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMenuDesde.Location = new System.Drawing.Point(55, 4);
            this.dtpMenuDesde.Name     = "dtpMenuDesde";
            this.dtpMenuDesde.Size     = new System.Drawing.Size(100, 20);
            this.dtpMenuDesde.Value    = System.DateTime.Today.AddMonths(-1);
            this.lblMenuHasta.AutoSize = true;
            this.lblMenuHasta.Location = new System.Drawing.Point(165, 8);
            this.lblMenuHasta.Name     = "lblMenuHasta";
            this.lblMenuHasta.Text     = "Hasta:";
            this.dtpMenuHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMenuHasta.Location = new System.Drawing.Point(208, 4);
            this.dtpMenuHasta.Name     = "dtpMenuHasta";
            this.dtpMenuHasta.Size     = new System.Drawing.Size(100, 20);
            this.dtpMenuHasta.Value    = System.DateTime.Today;
            this.btnBuscarMenus.Location = new System.Drawing.Point(316, 4);
            this.btnBuscarMenus.Name     = "btnBuscarMenus";
            this.btnBuscarMenus.Size     = new System.Drawing.Size(70, 24);
            this.btnBuscarMenus.Text     = "Buscar";
            this.btnBuscarMenus.Click   += new System.EventHandler(this.btnBuscarMenus_Click);
            this.btnAgregarMenu.Location = new System.Drawing.Point(394, 4);
            this.btnAgregarMenu.Name     = "btnAgregarMenu";
            this.btnAgregarMenu.Size     = new System.Drawing.Size(75, 24);
            this.btnAgregarMenu.Text     = "Agregar";
            this.btnAgregarMenu.Click   += new System.EventHandler(this.btnAgregarMenu_Click);
            this.btnEditarMenu.Location  = new System.Drawing.Point(476, 4);
            this.btnEditarMenu.Name      = "btnEditarMenu";
            this.btnEditarMenu.Size      = new System.Drawing.Size(75, 24);
            this.btnEditarMenu.Text      = "Editar";
            this.btnEditarMenu.Click    += new System.EventHandler(this.btnEditarMenu_Click);
            this.btnEliminarMenu.Location= new System.Drawing.Point(558, 4);
            this.btnEliminarMenu.Name    = "btnEliminarMenu";
            this.btnEliminarMenu.Size    = new System.Drawing.Size(75, 24);
            this.btnEliminarMenu.Text    = "Eliminar";
            this.btnEliminarMenu.Click  += new System.EventHandler(this.btnEliminarMenu_Click);
            this.mColId.HeaderText    = "ID";        this.mColId.Name    = "mColId";    this.mColId.Width    = 35;  this.mColId.ReadOnly = true;
            this.mColFecha.HeaderText = "Fecha";     this.mColFecha.Name = "mColFecha"; this.mColFecha.Width = 90;  this.mColFecha.ReadOnly = true;
            this.mColItems.HeaderText = "# Items";   this.mColItems.Name = "mColItems"; this.mColItems.Width = 60;  this.mColItems.ReadOnly = true;
            this.mColCal.HeaderText   = "Calorias";  this.mColCal.Name   = "mColCal";   this.mColCal.Width   = 80;  this.mColCal.ReadOnly = true;
            this.mColProt.HeaderText  = "Proteinas"; this.mColProt.Name  = "mColProt";  this.mColProt.Width  = 80;  this.mColProt.ReadOnly = true;
            this.mColCarbs.HeaderText = "Carbohid."; this.mColCarbs.Name = "mColCarbs"; this.mColCarbs.Width = 80;  this.mColCarbs.ReadOnly = true;
            this.mColGrasas.HeaderText= "Grasas";    this.mColGrasas.Name= "mColGrasas";this.mColGrasas.Width= 80; this.mColGrasas.ReadOnly = true;
            this.dgvMenus.AllowUserToAddRows    = false;
            this.dgvMenus.AllowUserToDeleteRows = false;
            this.dgvMenus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.mColId, this.mColFecha, this.mColItems,
                this.mColCal, this.mColProt, this.mColCarbs, this.mColGrasas });
            this.dgvMenus.Location         = new System.Drawing.Point(6, 34);
            this.dgvMenus.MultiSelect      = false;
            this.dgvMenus.Name             = "dgvMenus";
            this.dgvMenus.ReadOnly         = true;
            this.dgvMenus.RowHeadersVisible = false;
            this.dgvMenus.SelectionMode    = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenus.Size             = new System.Drawing.Size(910, 490);
            this.tabMenus.Controls.Add(this.dgvMenus);
            this.tabMenus.Controls.Add(this.btnEliminarMenu);
            this.tabMenus.Controls.Add(this.btnEditarMenu);
            this.tabMenus.Controls.Add(this.btnAgregarMenu);
            this.tabMenus.Controls.Add(this.btnBuscarMenus);
            this.tabMenus.Controls.Add(this.dtpMenuHasta);
            this.tabMenus.Controls.Add(this.lblMenuHasta);
            this.tabMenus.Controls.Add(this.dtpMenuDesde);
            this.tabMenus.Controls.Add(this.lblMenuDesde);
            this.tabMenus.Location = new System.Drawing.Point(4, 22);
            this.tabMenus.Name     = "tabMenus";
            this.tabMenus.Size     = new System.Drawing.Size(924, 534);
            this.tabMenus.TabIndex = 1;
            this.tabMenus.Text     = "Mis Menus";
            this.tabMenus.UseVisualStyleBackColor = true;

            // ── TAB INFO ──────────────────────────────────────────────────────
            this.grpMetabolismo.Controls.Add(this.lblIMC);
            this.grpMetabolismo.Controls.Add(this.lblObj);
            this.grpMetabolismo.Controls.Add(this.lblTDEE);
            this.grpMetabolismo.Controls.Add(this.lblTMB);
            this.grpMetabolismo.Location = new System.Drawing.Point(10, 10);
            this.grpMetabolismo.Name     = "grpMetabolismo";
            this.grpMetabolismo.Size     = new System.Drawing.Size(380, 130);
            this.grpMetabolismo.Text     = "Metabolismo e IMC";
            this.lblTMB.AutoSize  = true; this.lblTMB.Location  = new System.Drawing.Point(10, 20); this.lblTMB.Name  = "lblTMB";  this.lblTMB.Text  = "TMB: —";
            this.lblTDEE.AutoSize = true; this.lblTDEE.Location = new System.Drawing.Point(10, 45); this.lblTDEE.Name = "lblTDEE"; this.lblTDEE.Text = "TDEE: —";
            this.lblObj.AutoSize  = true; this.lblObj.Location  = new System.Drawing.Point(10, 70); this.lblObj.Name  = "lblObj";  this.lblObj.Text  = "Objetivo: —";
            this.lblIMC.AutoSize  = true; this.lblIMC.Location  = new System.Drawing.Point(10, 95); this.lblIMC.Name  = "lblIMC";  this.lblIMC.Text  = "IMC: —";
            this.grpMacros.Controls.Add(this.lblDieta);
            this.grpMacros.Controls.Add(this.lblGrasas);
            this.grpMacros.Controls.Add(this.lblCarbs);
            this.grpMacros.Controls.Add(this.lblProt);
            this.grpMacros.Location = new System.Drawing.Point(410, 10);
            this.grpMacros.Name     = "grpMacros";
            this.grpMacros.Size     = new System.Drawing.Size(380, 130);
            this.grpMacros.Text     = "Macronutrientes recomendados";
            this.lblProt.AutoSize   = true; this.lblProt.Location   = new System.Drawing.Point(10, 20); this.lblProt.Name   = "lblProt";   this.lblProt.Text   = "Proteinas: —";
            this.lblCarbs.AutoSize  = true; this.lblCarbs.Location  = new System.Drawing.Point(10, 45); this.lblCarbs.Name  = "lblCarbs";  this.lblCarbs.Text  = "Carbohidratos: —";
            this.lblGrasas.AutoSize = true; this.lblGrasas.Location = new System.Drawing.Point(10, 70); this.lblGrasas.Name = "lblGrasas"; this.lblGrasas.Text = "Grasas: —";
            this.lblDieta.AutoSize  = true; this.lblDieta.Location  = new System.Drawing.Point(10, 95); this.lblDieta.Name  = "lblDieta";  this.lblDieta.Text  = "Dieta: —";
            this.tabInfo.Controls.Add(this.grpMacros);
            this.tabInfo.Controls.Add(this.grpMetabolismo);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name     = "tabInfo";
            this.tabInfo.Size     = new System.Drawing.Size(924, 534);
            this.tabInfo.TabIndex = 2;
            this.tabInfo.Text     = "Mi Informacion";
            this.tabInfo.UseVisualStyleBackColor = true;

            // ── TAB ESTADISTICAS ──────────────────────────────────────────────
            // grpHoy
            this.grpHoy.Controls.Add(this.pbHoy);
            this.grpHoy.Controls.Add(this.lblEstFalta);
            this.grpHoy.Controls.Add(this.lblEstHoy);
            this.grpHoy.Location = new System.Drawing.Point(6, 6);
            this.grpHoy.Name     = "grpHoy";
            this.grpHoy.Size     = new System.Drawing.Size(380, 150);
            this.grpHoy.Text     = "Resumen de hoy";
            this.lblEstHoy.Location  = new System.Drawing.Point(10, 18); this.lblEstHoy.Name  = "lblEstHoy";  this.lblEstHoy.Size  = new System.Drawing.Size(355, 80); this.lblEstHoy.Text = "";
            this.lblEstFalta.AutoSize= true; this.lblEstFalta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEstFalta.Location= new System.Drawing.Point(10, 100); this.lblEstFalta.Name = "lblEstFalta"; this.lblEstFalta.Text = "";
            this.pbHoy.Location = new System.Drawing.Point(10, 124); this.pbHoy.Name = "pbHoy"; this.pbHoy.Size = new System.Drawing.Size(355, 16);
            // grpDiario
            this.grpDiario.Controls.Add(this.dgvEstDiario);
            this.grpDiario.Controls.Add(this.btnBuscarDiario);
            this.grpDiario.Controls.Add(this.dtpEstHasta);
            this.grpDiario.Controls.Add(this.lblEstHasta);
            this.grpDiario.Controls.Add(this.dtpEstDesde);
            this.grpDiario.Controls.Add(this.lblEstDesde);
            this.grpDiario.Location = new System.Drawing.Point(6, 165);
            this.grpDiario.Name     = "grpDiario";
            this.grpDiario.Size     = new System.Drawing.Size(580, 340);
            this.grpDiario.Text     = "Historial diario";
            this.lblEstDesde.AutoSize = true; this.lblEstDesde.Location = new System.Drawing.Point(8, 22); this.lblEstDesde.Name = "lblEstDesde"; this.lblEstDesde.Text = "Desde:";
            this.dtpEstDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEstDesde.Location = new System.Drawing.Point(55, 18); this.dtpEstDesde.Name = "dtpEstDesde"; this.dtpEstDesde.Size = new System.Drawing.Size(100, 20); this.dtpEstDesde.Value = System.DateTime.Today.AddMonths(-1);
            this.lblEstHasta.AutoSize = true; this.lblEstHasta.Location = new System.Drawing.Point(165, 22); this.lblEstHasta.Name = "lblEstHasta"; this.lblEstHasta.Text = "Hasta:";
            this.dtpEstHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEstHasta.Location = new System.Drawing.Point(208, 18); this.dtpEstHasta.Name = "dtpEstHasta"; this.dtpEstHasta.Size = new System.Drawing.Size(100, 20); this.dtpEstHasta.Value = System.DateTime.Today;
            this.btnBuscarDiario.Location = new System.Drawing.Point(318, 18); this.btnBuscarDiario.Name = "btnBuscarDiario"; this.btnBuscarDiario.Size = new System.Drawing.Size(70, 24); this.btnBuscarDiario.Text = "Buscar";
            this.btnBuscarDiario.Click += new System.EventHandler(this.btnBuscarDiario_Click);
            this.eColFecha.HeaderText  = "Fecha";    this.eColFecha.Name  = "eColFecha";  this.eColFecha.Width  = 90; this.eColFecha.ReadOnly  = true;
            this.eColCal.HeaderText    = "Kcal";     this.eColCal.Name    = "eColCal";    this.eColCal.Width    = 70; this.eColCal.ReadOnly    = true;
            this.eColMeta.HeaderText   = "Meta";     this.eColMeta.Name   = "eColMeta";   this.eColMeta.Width   = 70; this.eColMeta.ReadOnly   = true;
            this.eColPct.HeaderText    = "% Cumpl."; this.eColPct.Name    = "eColPct";    this.eColPct.Width    = 70; this.eColPct.ReadOnly    = true;
            this.eColEstado.HeaderText = "Estado";   this.eColEstado.Name = "eColEstado"; this.eColEstado.Width = 80; this.eColEstado.ReadOnly = true;
            this.dgvEstDiario.AllowUserToAddRows    = false;
            this.dgvEstDiario.AllowUserToDeleteRows = false;
            this.dgvEstDiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.eColFecha, this.eColCal, this.eColMeta, this.eColPct, this.eColEstado });
            this.dgvEstDiario.Location         = new System.Drawing.Point(6, 50);
            this.dgvEstDiario.MultiSelect      = false;
            this.dgvEstDiario.Name             = "dgvEstDiario";
            this.dgvEstDiario.ReadOnly         = true;
            this.dgvEstDiario.RowHeadersVisible = false;
            this.dgvEstDiario.SelectionMode    = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstDiario.Size             = new System.Drawing.Size(566, 280);
            // grpMensual
            this.grpMensual.Controls.Add(this.lblMensual);
            this.grpMensual.Controls.Add(this.btnBuscarMensual);
            this.grpMensual.Controls.Add(this.numAnio);
            this.grpMensual.Controls.Add(this.lblAnioLabel);
            this.grpMensual.Controls.Add(this.cmbMes);
            this.grpMensual.Controls.Add(this.lblMesLabel);
            this.grpMensual.Location = new System.Drawing.Point(600, 165);
            this.grpMensual.Name     = "grpMensual";
            this.grpMensual.Size     = new System.Drawing.Size(310, 340);
            this.grpMensual.Text     = "Resumen mensual";
            this.lblMesLabel.AutoSize = true; this.lblMesLabel.Location = new System.Drawing.Point(8, 22); this.lblMesLabel.Name = "lblMesLabel"; this.lblMesLabel.Text = "Mes:";
            this.cmbMes.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
                "Enero","Febrero","Marzo","Abril","Mayo","Junio",
                "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" });
            this.cmbMes.Location      = new System.Drawing.Point(40, 18);
            this.cmbMes.Name          = "cmbMes";
            this.cmbMes.Size          = new System.Drawing.Size(110, 21);
            this.cmbMes.SelectedIndex = System.DateTime.Today.Month - 1;
            this.lblAnioLabel.AutoSize = true; this.lblAnioLabel.Location = new System.Drawing.Point(158, 22); this.lblAnioLabel.Name = "lblAnioLabel"; this.lblAnioLabel.Text = "Anio:";
            this.numAnio.Location = new System.Drawing.Point(190, 18); this.numAnio.Minimum = new decimal(new int[]{2020,0,0,0}); this.numAnio.Maximum = new decimal(new int[]{2100,0,0,0}); this.numAnio.Name = "numAnio"; this.numAnio.Size = new System.Drawing.Size(65, 20); this.numAnio.Value = new decimal(new int[]{2025,0,0,0});
            this.btnBuscarMensual.Location = new System.Drawing.Point(262, 18); this.btnBuscarMensual.Name = "btnBuscarMensual"; this.btnBuscarMensual.Size = new System.Drawing.Size(40, 24); this.btnBuscarMensual.Text = "Ver";
            this.btnBuscarMensual.Click += new System.EventHandler(this.btnBuscarMensual_Click);
            this.lblMensual.Location = new System.Drawing.Point(8, 50); this.lblMensual.Name = "lblMensual"; this.lblMensual.Size = new System.Drawing.Size(290, 250); this.lblMensual.Text = "";
            // tabEstadisticas
            this.tabEstadisticas.Controls.Add(this.grpMensual);
            this.tabEstadisticas.Controls.Add(this.grpDiario);
            this.tabEstadisticas.Controls.Add(this.grpHoy);
            this.tabEstadisticas.Location = new System.Drawing.Point(4, 22);
            this.tabEstadisticas.Name     = "tabEstadisticas";
            this.tabEstadisticas.Size     = new System.Drawing.Size(924, 534);
            this.tabEstadisticas.TabIndex = 3;
            this.tabEstadisticas.Text     = "Estadisticas";
            this.tabEstadisticas.UseVisualStyleBackColor = true;

            // tabControl1
            this.tabControl1.Controls.Add(this.tabAlimentos);
            this.tabControl1.Controls.Add(this.tabMenus);
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Controls.Add(this.tabEstadisticas);
            this.tabControl1.Location = new System.Drawing.Point(0, 34);
            this.tabControl1.Name     = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size     = new System.Drawing.Size(932, 560);
            this.tabControl1.TabIndex = 3;

            // FrmPrincipal
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(940, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCambiarUsuario);
            this.Controls.Add(this.btnEditarPerfil);
            this.Controls.Add(this.lblUsuario);
            this.MinimumSize = new System.Drawing.Size(940, 630);
            this.Name        = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text        = "Nutricion Para Todos";

            this.tabControl1.ResumeLayout(false);
            this.tabAlimentos.ResumeLayout(false);
            this.tabAlimentos.PerformLayout();
            this.tabMenus.ResumeLayout(false);
            this.tabMenus.PerformLayout();
            this.tabInfo.ResumeLayout(false);
            this.tabEstadisticas.ResumeLayout(false);
            this.grpMetabolismo.ResumeLayout(false);
            this.grpMetabolismo.PerformLayout();
            this.grpMacros.ResumeLayout(false);
            this.grpMacros.PerformLayout();
            this.grpHoy.ResumeLayout(false);
            this.grpHoy.PerformLayout();
            this.grpDiario.ResumeLayout(false);
            this.grpDiario.PerformLayout();
            this.grpMensual.ResumeLayout(false);
            this.grpMensual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlimentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstDiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label         lblUsuario;
        private System.Windows.Forms.Button        btnEditarPerfil;
        private System.Windows.Forms.Button        btnCambiarUsuario;
        private System.Windows.Forms.TabControl    tabControl1;
        private System.Windows.Forms.TabPage       tabAlimentos;
        private System.Windows.Forms.TabPage       tabMenus;
        private System.Windows.Forms.TabPage       tabInfo;
        private System.Windows.Forms.TabPage       tabEstadisticas;
        private System.Windows.Forms.Label         lblBuscarAlimento;
        private System.Windows.Forms.TextBox       txtBuscarAlimento;
        private System.Windows.Forms.Button        btnAgregarAlimento;
        private System.Windows.Forms.Button        btnEditarAlimento;
        private System.Windows.Forms.Button        btnEliminarAlimento;
        private System.Windows.Forms.DataGridView  dgvAlimentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn aColId, aColNombre, aColCat, aColCal, aColProt, aColCarbs, aColGrasas, aColPorc;
        private System.Windows.Forms.Label         lblMenuDesde;
        private System.Windows.Forms.DateTimePicker dtpMenuDesde;
        private System.Windows.Forms.Label         lblMenuHasta;
        private System.Windows.Forms.DateTimePicker dtpMenuHasta;
        private System.Windows.Forms.Button        btnBuscarMenus;
        private System.Windows.Forms.Button        btnAgregarMenu;
        private System.Windows.Forms.Button        btnEditarMenu;
        private System.Windows.Forms.Button        btnEliminarMenu;
        private System.Windows.Forms.DataGridView  dgvMenus;
        private System.Windows.Forms.DataGridViewTextBoxColumn mColId, mColFecha, mColItems, mColCal, mColProt, mColCarbs, mColGrasas;
        private System.Windows.Forms.GroupBox      grpMetabolismo;
        private System.Windows.Forms.Label         lblTMB, lblTDEE, lblObj, lblIMC;
        private System.Windows.Forms.GroupBox      grpMacros;
        private System.Windows.Forms.Label         lblProt, lblCarbs, lblGrasas, lblDieta;
        private System.Windows.Forms.GroupBox      grpHoy;
        private System.Windows.Forms.Label         lblEstHoy, lblEstFalta;
        private System.Windows.Forms.ProgressBar   pbHoy;
        private System.Windows.Forms.GroupBox      grpDiario;
        private System.Windows.Forms.Label         lblEstDesde, lblEstHasta;
        private System.Windows.Forms.DateTimePicker dtpEstDesde, dtpEstHasta;
        private System.Windows.Forms.Button        btnBuscarDiario;
        private System.Windows.Forms.DataGridView  dgvEstDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn eColFecha, eColCal, eColMeta, eColPct, eColEstado;
        private System.Windows.Forms.GroupBox      grpMensual;
        private System.Windows.Forms.Label         lblMesLabel, lblAnioLabel, lblMensual;
        private System.Windows.Forms.ComboBox      cmbMes;
        private System.Windows.Forms.NumericUpDown numAnio;
        private System.Windows.Forms.Button        btnBuscarMensual;
    }
}
