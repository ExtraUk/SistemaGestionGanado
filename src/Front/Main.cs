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
using System.Data.SqlClient;
using System.Configuration;

namespace SistemaGestionGanado {
    public partial class Main: Form {
        private List<Vaca> vacas;
        private Dictionary<string, Vaca> dictVacas = new Dictionary<string, Vaca>();
        public Main() {
            InitializeComponent();
            this.inicializarEstadosCategorias();
            actualizarGridView(true);
        }

        private void actualizarDiccionario() {
            if(vacas.Count == 0) return;
            foreach(Vaca vaca in vacas) {
                if(vaca.getId() != null) {
                    if(dictVacas.ContainsKey(vaca.getId())) {
                        dictVacas[vaca.getId()] = vaca;
                    }
                    else {
                        dictVacas.Add(vaca.getId(), vaca);
                    }
                }
            }
        }

        private void inicializarEstadosCategorias() {
            foreach(var estado in Enum.GetValues(typeof(Estado))) {
                this.cboEstado.Items.Add(estado);
                this.cboEstadoAuto.Items.Add(estado);
                this.lstBoxEstado.Items.Add(estado);
            }
            foreach(Categoria cat in Enum.GetValues(typeof(Categoria))) {
                this.cboCat.Items.Add(cat);
                this.cboCatAuto.Items.Add(cat);
                this.lstBoxCat.Items.Add(cat);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            try {
                Estado estado = (Estado)this.cboEstado.SelectedIndex;
                bool flag = false;
                switch(estado) {
                    case Estado.Viva:
                        if(this.txtId.Text != "" && this.txtPeso.Text != "" && this.dateTimePicker1.Checked && this.cboCat.SelectedIndex != -1) {
                            String id = this.txtId.Text.Trim();
                            float peso = float.Parse(this.txtPeso.Text);
                            DateTime fecha = this.dateTimePicker1.Value;
                            Categoria cat = (Categoria)this.cboCat.SelectedIndex;
                            String proc = this.txtProcedencia.Text;
                            Vaca vaca = new Vaca(id, peso, fecha, cat, proc, estado);
                            persistirVaca(vaca);
                            this.actualizarGridView(true);
                        }
                        else flag = true;
                        break;
                    case Estado.Muerta: case Estado.Vendida:
                        if(this.txtId.Text != "" && this.dateTimePicker1.Checked) {
                            String id = this.txtId.Text;
                            DateTime fecha = this.dateTimePicker1.Value;
                            Vaca vaca = new Vaca(id);
                            vaca.setEstado(estado);
                            vaca.setUltimaVezPesada(fecha);
                            vaca.setCategoria(dictVacas[vaca.getId()].getCategoria());
                            vaca.setProcedencia(dictVacas[vaca.getId()].getProcedencia());
                            matarVenderVaca(vaca);
                            this.actualizarGridView(true);
                        }
                        else flag = true;
                        break;
                    default:
                        flag = true;
                        break;
                }
                if(flag) MessageBox.Show("Rellene todos los datos para continuar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarGridView(bool refreshDB) {
            if(refreshDB) {
                vacas = src.Persistencia.Vaca.TraerTodas();
                actualizarDiccionario();
            }
            this.dataGridView1.Rows.Clear();
            foreach(Vaca vaca in vacas) {
                if(cumpleFiltrosVaca(vaca)) {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getId() });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getPesoActual() });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getCategoria() });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getUltimaVezPesada() });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getProcedencia() });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getEstado() });
                    this.dataGridView1.Rows.Add(row);
                }
            }
        }

        private void btnSubir_Click(object sender, EventArgs e) {
            string procedencia = txtProcedenciaAuto.Text;
            int categoriaSelectedIndex = cboCatAuto.SelectedIndex;
            int estadoSelectedIndex = cboEstadoAuto.SelectedIndex;
            if(procedencia != "" && categoriaSelectedIndex != -1 && estadoSelectedIndex != -1) {
                bool muertaVendida = (Estado)estadoSelectedIndex == Estado.Muerta || (Estado)estadoSelectedIndex == Estado.Vendida;
                using(OpenFileDialog openFileDialog = new OpenFileDialog()) {
                    openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                    if(openFileDialog.ShowDialog() == DialogResult.OK) {
                        string filePath = openFileDialog.FileName;
                        List<Vaca> vacasCSV = vacasEnCsv(filePath, muertaVendida);
                        int cantidadRepetidas = eliminarRepetidas(ref vacasCSV);
                        if(cantidadRepetidas == -1) return;

                        DialogResult result = MessageBox.Show("Se leyeron: " + (vacasCSV.Count+cantidadRepetidas) + " animales, de los cuales " + cantidadRepetidas + " repetidas fueron eliminadas, Quedaron: " + vacasCSV.Count + " ¿Desea Continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(result == DialogResult.Yes) {
                            if(!muertaVendida) {
                                foreach(Vaca vaca in vacasCSV) {
                                    vaca.setCategoria((Categoria)categoriaSelectedIndex);
                                    vaca.setProcedencia(procedencia);
                                    vaca.setEstado((Estado)estadoSelectedIndex);
                                }
                                persistirVacas(vacasCSV);
                            }
                            else {
                                foreach(Vaca vaca in vacasCSV) {
                                    vaca.setEstado((Estado)estadoSelectedIndex);
                                    vaca.setCategoria(dictVacas[vaca.getId()].getCategoria());
                                    vaca.setProcedencia(dictVacas[vaca.getId()].getProcedencia());
                                    matarVenderVaca(vaca);
                                }
                            }
                            this.actualizarGridView(true);
                        }
                    }
                }
            }
            else {
                MessageBox.Show("Rellene todos los datos de la actualización automática");
            }
        }

        private List<Vaca> vacasEnCsv(string filePath, bool matarVender) {
            try {
                List<Vaca> vacasCSV = new List<Vaca>();
                using(StreamReader reader = new StreamReader(filePath)) {
                    while(!reader.EndOfStream) {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        Vaca vaca = leerLinea(values, matarVender);
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

        private Vaca leerLinea(string[] values, bool matarVender) {
            Vaca vaca = new Vaca(null);
            if(matarVender) {
                for(int i = 0; i < values.Length; i++) {
                    switch(i) {
                        case 0:
                            vaca.setId(values[0]);
                            break;
                        case 1:
                            vaca.setUltimaVezPesada(DateTime.Parse(values[1]));
                            break;
                    }
                }
            }
            else {
                for(int i = 0; i < values.Length; i++) {
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
            }
            if(vaca.getId() != null) return vaca;
            return null;
        }

        //Elimina repetidas y retorna la cantidad de repetidas que elimino
        private int eliminarRepetidas(ref List<Vaca> vacas) {
            try {
                Dictionary<string, bool> conjuntoVacas = new Dictionary<string, bool>();
                int repetidas = 0;

                List<Vaca> vacasIterador = new List<Vaca>(); //Lista para que no se rompa en el foreach
                foreach(Vaca vaca in vacas) {
                    vacasIterador.Add(vaca);
                }

                foreach(Vaca vaca in vacasIterador) {
                    if(conjuntoVacas.ContainsKey(vaca.getId())) {
                        vacas.Remove(vaca);
                        repetidas++;
                    }
                    else {
                        conjuntoVacas.Add(vaca.getId(), true);
                    }
                }
                return repetidas;
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private static void persistirVaca(Vaca vaca) {
            Vaca.PersistirVaca(vaca);
        }
        private static void persistirVacas(List<Vaca> listaVacas) {
            foreach(Vaca vaca in listaVacas) {
                persistirVaca(vaca);
            }
        }
        private static void matarVenderVaca(Vaca vaca) {
            Vaca.MatarVenderVacaPersistencia(vaca);
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) {
            if((Estado)cboEstado.SelectedIndex == Estado.Muerta || (Estado)cboEstado.SelectedIndex == Estado.Vendida) {
                txtPeso.Enabled = false;
                txtProcedencia.Enabled = false;
                cboCat.Enabled = false;
            }
            else {
                txtPeso.Enabled = true;
                txtProcedencia.Enabled = true;
                cboCat.Enabled = true;
            }
        }

        private void cboEstadoAuto_SelectedIndexChanged(object sender, EventArgs e) {
            if((Estado)cboEstadoAuto.SelectedIndex == Estado.Muerta || (Estado)cboEstadoAuto.SelectedIndex == Estado.Vendida) {
                txtProcedenciaAuto.Enabled = false;
                cboCatAuto.Enabled = false;
            }
            else {
                txtProcedenciaAuto.Enabled = true;
                cboCatAuto.Enabled = true;
            }
        }

        private bool cumpleFiltrosVaca(Vaca vaca) {
            bool retorno = true;
            string id = txtIdFiltros.Text;
            if(id != "") {
                retorno = retorno && vaca.getId().Contains(id);
            }
            string proc = txtProcedenciaFiltros.Text;
            if(proc != "") {
                retorno = retorno && vaca.getProcedencia().Contains(proc);
            }
            if(txtPesoDesdeFiltros.Text != "") {
                float pesoDesde = float.Parse(txtPesoDesdeFiltros.Text);
                retorno = retorno && (vaca.getPesoActual() >= pesoDesde);
            }
            if(txtPesoHastaFiltros.Text != "") {
                float pesoHasta = float.Parse(txtPesoHastaFiltros.Text);
                retorno = retorno && (vaca.getPesoActual() <= pesoHasta);
            }
            if(datePickerDesdeFiltros.Checked) {
                DateTime desde = datePickerDesdeFiltros.Value;
                retorno = retorno && (vaca.getUltimaVezPesada().CompareTo(desde) >= 0);
            }
            if(datePickerHastaFiltros.Checked) {
                DateTime hasta = datePickerHastaFiltros.Value;
                retorno = retorno && (vaca.getUltimaVezPesada().CompareTo(hasta) <= 0);
            }
            if(lstBoxCat.CheckedItems.Count > 0) {
                bool flag = false;
                for(int i=0; i<lstBoxCat.CheckedItems.Count; i++) {
                    flag = flag || vaca.getCategoria().ToString().Equals(lstBoxCat.CheckedItems[i].ToString());
                }
                retorno = retorno && flag;
            }
            if(lstBoxEstado.CheckedItems.Count > 0) {
                bool flag = false;
                for(int i = 0; i < lstBoxEstado.CheckedItems.Count; i++) {
                    flag = flag || vaca.getEstado().ToString().Equals(lstBoxEstado.CheckedItems[i].ToString());
                }
                retorno = retorno && flag;
            }
            return retorno;
        }

        

        private void button1_Click(object sender, EventArgs e) {
            if(dataGridView1.SelectedRows.Count > 0) {
                foreach(DataGridViewRow row in dataGridView1.SelectedRows) {
                    Vaca vaca = Vaca.BuscarVacaPorId(row.Cells[0].Value.ToString(), this.vacas);
                    if(vaca != null) {
                        this.vacas.Remove(vaca);
                        Vaca.EliminarVacaPersistencia(vaca);
                    }
                }
            }
            actualizarGridView(true);
        }

        private void button2_Click(object sender, EventArgs e) {
            actualizarGridView(false);
        }
    }
}
