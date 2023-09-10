using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionGanado.src.Back;
using System.IO;

namespace SistemaGestionGanado {
    public partial class Main: Form {
        private List<Vaca> vacas;
        public Main() {
            InitializeComponent();
            vacas = new List<Vaca>();

            foreach(var estado in Enum.GetValues(typeof(Estado))) {
                this.cboEstado.Items.Add(estado);
                this.cboEstadoAuto.Items.Add(estado);
            }

            //TODO: cargar Vacas a la lista de la DB
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            String id = this.txtId.Text;
            float peso = float.Parse(this.txtPeso.Text);
            DateTime fecha = this.dateTimePicker1.Value;
            Categoria cat = null;
            String proc = this.txtProcedencia.Text;
            Estado estado = (Estado)this.estado.Index;
            Vaca vaca = new Vaca(id, peso, fecha, cat, proc, estado);
            vacas.Add(vaca);
            actualizarGridView();
        }

        private void actualizarGridView() {
            this.dataGridView1.Rows.Clear();
            foreach(Vaca vaca in vacas) {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getId() }) ;
                row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getPesoActual() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getCategoria() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getUltimaVezPesada() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getProcedencia() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getEstado() });
                this.dataGridView1.Rows.Add(row);
            }
        }

        private void btnSubir_Click(object sender, EventArgs e) {
            if(txtCatAuto.Text != "" && txtProcedenciaAuto.Text != "" && cboEstadoAuto.SelectedIndex != -1) {
                using(OpenFileDialog openFileDialog = new OpenFileDialog()) {
                    openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                    if(openFileDialog.ShowDialog() == DialogResult.OK) {
                        string filePath = openFileDialog.FileName;
                        List<Vaca> vacasCSV = vacasEnCsv(filePath);

                        DialogResult result = MessageBox.Show("Se leyeron: " + vacasCSV.Count + " animales, ¿Desea Continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(result == DialogResult.Yes) {
                            foreach(Vaca vaca in vacasCSV) {
                                //vaca.setCategoria(txtCatAuto);
                                vaca.setProcedencia(txtProcedenciaAuto.Text);
                                vaca.setEstado((Estado)cboEstadoAuto.SelectedIndex);
                            }
                        }
                    }
                }
            }
            else {
                MessageBox.Show("Rellene todos los datos de la actualización automática");
            }
        }

        private List<Vaca> vacasEnCsv(string filePath) {
            try {
                List<Vaca> vacasCSV = new List<Vaca>();
                using(StreamReader reader = new StreamReader(filePath)) {
                    while(!reader.EndOfStream) {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        Vaca vaca = leerLinea(values);
                        if(vaca != null) {
                            vacasCSV.Add(vaca);
                        }
                    }
                }
                return vacasCSV;
            }
            catch(Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Vaca leerLinea(string[] values) {
            Vaca vaca = new Vaca(null);
            for(int i=0; i<values.Length; i++) {
                switch(i) {
                    case 0:
                        vaca.setId(values[0]);
                        break;
                    case 1:
                        vaca.setPesoActual(float.Parse(values[1]));
                        break;
                    case 2:
                        vaca.setUltimaVezPesada(DateTime.Parse(values[2]));
                        break;
                }
            }
            if(vaca.getId() != null) return vaca;
            return null;
        }
    }
}
