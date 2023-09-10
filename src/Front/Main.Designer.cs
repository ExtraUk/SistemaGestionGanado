
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
            this.txtCat = new System.Windows.Forms.TextBox();
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
            this.txtCatAuto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnAgregarAuto = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(873, 234);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(100, 23);
            this.txtCat.TabIndex = 5;
            // 
            // txtProcedencia
            // 
            this.txtProcedencia.Location = new System.Drawing.Point(1085, 234);
            this.txtProcedencia.Name = "txtProcedencia";
            this.txtProcedencia.Size = new System.Drawing.Size(100, 23);
            this.txtProcedencia.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1216, 274);
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
            this.label3.Location = new System.Drawing.Point(979, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1085, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Procedencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1191, 213);
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
            this.cboEstado.Location = new System.Drawing.Point(1191, 234);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(110, 23);
            this.cboEstado.TabIndex = 17;
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
            this.cboEstadoAuto.Location = new System.Drawing.Point(873, 361);
            this.cboEstadoAuto.Name = "cboEstadoAuto";
            this.cboEstadoAuto.Size = new System.Drawing.Size(110, 23);
            this.cboEstadoAuto.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(873, 340);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "Estado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(767, 340);
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
            this.txtProcedenciaAuto.Location = new System.Drawing.Point(767, 361);
            this.txtProcedenciaAuto.Name = "txtProcedenciaAuto";
            this.txtProcedenciaAuto.Size = new System.Drawing.Size(100, 23);
            this.txtProcedenciaAuto.TabIndex = 27;
            // 
            // txtCatAuto
            // 
            this.txtCatAuto.Location = new System.Drawing.Point(661, 361);
            this.txtCatAuto.Name = "txtCatAuto";
            this.txtCatAuto.Size = new System.Drawing.Size(100, 23);
            this.txtCatAuto.TabIndex = 26;
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
            this.btnSubir.Location = new System.Drawing.Point(989, 360);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(88, 25);
            this.btnSubir.TabIndex = 33;
            this.btnSubir.Text = "Subir Archivo";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnAgregarAuto
            // 
            this.btnAgregarAuto.AutoSize = true;
            this.btnAgregarAuto.Location = new System.Drawing.Point(661, 390);
            this.btnAgregarAuto.Name = "btnAgregarAuto";
            this.btnAgregarAuto.Size = new System.Drawing.Size(88, 25);
            this.btnAgregarAuto.TabIndex = 34;
            this.btnAgregarAuto.Text = "Agregar";
            this.btnAgregarAuto.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(977, 234);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 23);
            this.dateTimePicker1.TabIndex = 35;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 715);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnAgregarAuto);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboEstadoAuto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtProcedenciaAuto);
            this.Controls.Add(this.txtCatAuto);
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
            this.Controls.Add(this.txtCat);
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
        private System.Windows.Forms.TextBox txtCat;
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
        private System.Windows.Forms.TextBox txtCatAuto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnAgregarAuto;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

