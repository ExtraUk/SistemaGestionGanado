
namespace SistemaGestionGanado {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtProcedencia = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblReidentificacion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblActualizacion = new System.Windows.Forms.Label();
            this.lblManual = new System.Windows.Forms.Label();
            this.lblAutomatico = new System.Windows.Forms.Label();
            this.cboEstadoAuto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProcedenciaAuto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSubir = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboCatAuto = new System.Windows.Forms.ComboBox();
            this.cboCat = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtIdFiltros = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtProcedenciaFiltros = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.datePickerDesdeFiltros = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.datePickerHastaFiltros = new System.Windows.Forms.DateTimePicker();
            this.lstBoxCat = new System.Windows.Forms.CheckedListBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtPesoDesdeFiltros = new System.Windows.Forms.TextBox();
            this.txtPesoHastaFiltros = new System.Windows.Forms.TextBox();
            this.lstBoxEstado = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.peso,
            this.categoria,
            this.fecha,
            this.procedencia,
            this.estado});
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(643, 513);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            // 
            // peso
            // 
            this.peso.HeaderText = "Peso";
            this.peso.Name = "peso";
            // 
            // categoria
            // 
            this.categoria.HeaderText = "Categoria";
            this.categoria.Name = "categoria";
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            // 
            // procedencia
            // 
            this.procedencia.HeaderText = "Procedencia";
            this.procedencia.Name = "procedencia";
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(661, 234);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 3;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(767, 234);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(100, 23);
            this.txtPeso.TabIndex = 4;
            // 
            // txtProcedencia
            // 
            this.txtProcedencia.Location = new System.Drawing.Point(1097, 234);
            this.txtProcedencia.Name = "txtProcedencia";
            this.txtProcedencia.Size = new System.Drawing.Size(100, 23);
            this.txtProcedencia.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1238, 263);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(661, 213);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(17, 15);
            this.lblId.TabIndex = 10;
            this.lblId.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Peso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(873, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Categoría";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(991, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1097, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Procedencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1203, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Estado";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(489, 37);
            this.lblTitulo.TabIndex = 16;
            this.lblTitulo.Text = "Sistema de Gestión de Ganado";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(1203, 234);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(110, 23);
            this.cboEstado.TabIndex = 17;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(713, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(899, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 19;
            // 
            // lblReidentificacion
            // 
            this.lblReidentificacion.AutoSize = true;
            this.lblReidentificacion.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblReidentificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReidentificacion.Location = new System.Drawing.Point(661, 61);
            this.lblReidentificacion.Name = "lblReidentificacion";
            this.lblReidentificacion.Size = new System.Drawing.Size(135, 21);
            this.lblReidentificacion.TabIndex = 20;
            this.lblReidentificacion.Text = "Reidentificación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(661, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Id Viejo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(838, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Id Nuevo";
            // 
            // lblActualizacion
            // 
            this.lblActualizacion.AutoSize = true;
            this.lblActualizacion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblActualizacion.Location = new System.Drawing.Point(659, 144);
            this.lblActualizacion.Name = "lblActualizacion";
            this.lblActualizacion.Size = new System.Drawing.Size(285, 25);
            this.lblActualizacion.TabIndex = 23;
            this.lblActualizacion.Text = "Actualización de Base de Datos";
            // 
            // lblManual
            // 
            this.lblManual.AutoSize = true;
            this.lblManual.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblManual.Location = new System.Drawing.Point(661, 186);
            this.lblManual.Name = "lblManual";
            this.lblManual.Size = new System.Drawing.Size(58, 19);
            this.lblManual.TabIndex = 24;
            this.lblManual.Text = "Manual";
            // 
            // lblAutomatico
            // 
            this.lblAutomatico.AutoSize = true;
            this.lblAutomatico.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblAutomatico.Location = new System.Drawing.Point(661, 308);
            this.lblAutomatico.Name = "lblAutomatico";
            this.lblAutomatico.Size = new System.Drawing.Size(87, 19);
            this.lblAutomatico.TabIndex = 25;
            this.lblAutomatico.Text = "Automático";
            // 
            // cboEstadoAuto
            // 
            this.cboEstadoAuto.FormattingEnabled = true;
            this.cboEstadoAuto.Location = new System.Drawing.Point(883, 362);
            this.cboEstadoAuto.Name = "cboEstadoAuto";
            this.cboEstadoAuto.Size = new System.Drawing.Size(110, 23);
            this.cboEstadoAuto.TabIndex = 31;
            this.cboEstadoAuto.SelectedIndexChanged += new System.EventHandler(this.cboEstadoAuto_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(883, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "Estado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(777, 341);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Procedencia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(661, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Categoría";
            // 
            // txtProcedenciaAuto
            // 
            this.txtProcedenciaAuto.Location = new System.Drawing.Point(777, 362);
            this.txtProcedenciaAuto.Name = "txtProcedenciaAuto";
            this.txtProcedenciaAuto.Size = new System.Drawing.Size(100, 23);
            this.txtProcedenciaAuto.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(663, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(650, 2);
            this.label11.TabIndex = 32;
            // 
            // btnSubir
            // 
            this.btnSubir.AutoSize = true;
            this.btnSubir.Location = new System.Drawing.Point(999, 361);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(88, 25);
            this.btnSubir.TabIndex = 33;
            this.btnSubir.Text = "Subir Archivo";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(989, 234);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 23);
            this.dateTimePicker1.TabIndex = 35;
            // 
            // cboCatAuto
            // 
            this.cboCatAuto.FormattingEnabled = true;
            this.cboCatAuto.Location = new System.Drawing.Point(661, 362);
            this.cboCatAuto.Name = "cboCatAuto";
            this.cboCatAuto.Size = new System.Drawing.Size(110, 23);
            this.cboCatAuto.TabIndex = 36;
            // 
            // cboCat
            // 
            this.cboCat.FormattingEnabled = true;
            this.cboCat.Location = new System.Drawing.Point(873, 234);
            this.cboCat.Name = "cboCat";
            this.cboCat.Size = new System.Drawing.Size(110, 23);
            this.cboCat.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(663, 410);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(650, 2);
            this.label12.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(663, 421);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 19);
            this.label15.TabIndex = 44;
            this.label15.Text = "Eliminar Seleccion";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(12, 588);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 25);
            this.label16.TabIndex = 45;
            this.label16.Text = "Filtros";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 680);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 15);
            this.label18.TabIndex = 48;
            this.label18.Text = "Categoría";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 623);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 15);
            this.label17.TabIndex = 51;
            this.label17.Text = "Id";
            // 
            // txtIdFiltros
            // 
            this.txtIdFiltros.Location = new System.Drawing.Point(12, 641);
            this.txtIdFiltros.Name = "txtIdFiltros";
            this.txtIdFiltros.Size = new System.Drawing.Size(100, 23);
            this.txtIdFiltros.TabIndex = 50;
            this.txtIdFiltros.TextChanged += new System.EventHandler(this.txtIdFiltros_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 771);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 15);
            this.label19.TabIndex = 53;
            this.label19.Text = "Procedencia";
            // 
            // txtProcedenciaFiltros
            // 
            this.txtProcedenciaFiltros.Location = new System.Drawing.Point(12, 789);
            this.txtProcedenciaFiltros.Name = "txtProcedenciaFiltros";
            this.txtProcedenciaFiltros.Size = new System.Drawing.Size(100, 23);
            this.txtProcedenciaFiltros.TabIndex = 52;
            this.txtProcedenciaFiltros.TextChanged += new System.EventHandler(this.txtProcedenciaFiltros_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(153, 680);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 15);
            this.label20.TabIndex = 54;
            this.label20.Text = "Estado";
            // 
            // datePickerDesdeFiltros
            // 
            this.datePickerDesdeFiltros.Checked = false;
            this.datePickerDesdeFiltros.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerDesdeFiltros.Location = new System.Drawing.Point(185, 789);
            this.datePickerDesdeFiltros.Name = "datePickerDesdeFiltros";
            this.datePickerDesdeFiltros.Size = new System.Drawing.Size(100, 23);
            this.datePickerDesdeFiltros.TabIndex = 57;
            this.datePickerDesdeFiltros.ValueChanged += new System.EventHandler(this.datePickerDesdeFiltros_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(131, 780);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 15);
            this.label21.TabIndex = 56;
            this.label21.Text = "Fecha";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(137, 795);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 15);
            this.label22.TabIndex = 58;
            this.label22.Text = "Desde:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(291, 795);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 15);
            this.label23.TabIndex = 60;
            this.label23.Text = "Hasta:";
            // 
            // datePickerHastaFiltros
            // 
            this.datePickerHastaFiltros.Checked = false;
            this.datePickerHastaFiltros.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerHastaFiltros.Location = new System.Drawing.Point(339, 789);
            this.datePickerHastaFiltros.Name = "datePickerHastaFiltros";
            this.datePickerHastaFiltros.Size = new System.Drawing.Size(100, 23);
            this.datePickerHastaFiltros.TabIndex = 59;
            this.datePickerHastaFiltros.ValueChanged += new System.EventHandler(this.datePickerHastaFiltros_ValueChanged);
            // 
            // lstBoxCat
            // 
            this.lstBoxCat.FormattingEnabled = true;
            this.lstBoxCat.Location = new System.Drawing.Point(12, 698);
            this.lstBoxCat.Name = "lstBoxCat";
            this.lstBoxCat.Size = new System.Drawing.Size(120, 58);
            this.lstBoxCat.TabIndex = 61;
            this.lstBoxCat.SelectedValueChanged += new System.EventHandler(this.lstBoxCat_SelectedValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(291, 647);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 15);
            this.label24.TabIndex = 66;
            this.label24.Text = "Hasta:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(137, 647);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 15);
            this.label25.TabIndex = 64;
            this.label25.Text = "Desde:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(131, 632);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 15);
            this.label26.TabIndex = 62;
            this.label26.Text = "Peso";
            // 
            // txtPesoDesdeFiltros
            // 
            this.txtPesoDesdeFiltros.Location = new System.Drawing.Point(185, 641);
            this.txtPesoDesdeFiltros.Name = "txtPesoDesdeFiltros";
            this.txtPesoDesdeFiltros.Size = new System.Drawing.Size(100, 23);
            this.txtPesoDesdeFiltros.TabIndex = 67;
            this.txtPesoDesdeFiltros.TextChanged += new System.EventHandler(this.txtPesoDesdeFiltros_TextChanged);
            // 
            // txtPesoHastaFiltros
            // 
            this.txtPesoHastaFiltros.Location = new System.Drawing.Point(337, 641);
            this.txtPesoHastaFiltros.Name = "txtPesoHastaFiltros";
            this.txtPesoHastaFiltros.Size = new System.Drawing.Size(100, 23);
            this.txtPesoHastaFiltros.TabIndex = 68;
            this.txtPesoHastaFiltros.TextChanged += new System.EventHandler(this.txtPesoHastaFiltros_TextChanged);
            // 
            // lstBoxEstado
            // 
            this.lstBoxEstado.FormattingEnabled = true;
            this.lstBoxEstado.Location = new System.Drawing.Point(153, 698);
            this.lstBoxEstado.Name = "lstBoxEstado";
            this.lstBoxEstado.Size = new System.Drawing.Size(120, 58);
            this.lstBoxEstado.TabIndex = 69;
            this.lstBoxEstado.SelectedValueChanged += new System.EventHandler(this.lstBoxEstado_SelectedValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 898);
            this.Controls.Add(this.lstBoxEstado);
            this.Controls.Add(this.txtPesoHastaFiltros);
            this.Controls.Add(this.txtPesoDesdeFiltros);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lstBoxCat);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.datePickerHastaFiltros);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.datePickerDesdeFiltros);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtProcedenciaFiltros);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtIdFiltros);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboCat);
            this.Controls.Add(this.cboCatAuto);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboEstadoAuto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtProcedenciaAuto);
            this.Controls.Add(this.lblAutomatico);
            this.Controls.Add(this.lblManual);
            this.Controls.Add(this.lblActualizacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblReidentificacion);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtProcedencia);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn procedencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtProcedencia;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblReidentificacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblActualizacion;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.Label lblAutomatico;
        private System.Windows.Forms.ComboBox cboEstadoAuto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProcedenciaAuto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboCatAuto;
        private System.Windows.Forms.ComboBox cboCat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtIdFiltros;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtProcedenciaFiltros;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker datePickerDesdeFiltros;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker datePickerHastaFiltros;
        private System.Windows.Forms.CheckedListBox lstBoxCat;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtPesoDesdeFiltros;
        private System.Windows.Forms.TextBox txtPesoHastaFiltros;
        private System.Windows.Forms.CheckedListBox lstBoxEstado;
    }
}

