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
using ClosedXML.Excel;

namespace SistemaGestionGanado {
    public partial class Main: Form {
        private List<Vaca> vacas;
        private Dictionary<string, Vaca> dictVacas = new Dictionary<string, Vaca>();
        private List<Vaca> vacasAgregar = new List<Vaca>();
        private int archivosAgregar = 0;
        public Main() {
            InitializeComponent();
            this.inicializarEstadosCategorias();
            actualizarGridView(true);
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
                this.lstBoxCatGanadoDesaparecido.Items.Add(cat);
                this.lstBoxCatGG.Items.Add(cat);
            }
        }

        //Actualiza el DataGridView, recibe un bool refreshDB como parametro el cual indicara si debe actualizarse desde la base de datos o solo actualizar filtros
        public void actualizarGridView(bool refreshDB) {
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
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getUltimaVezPesada().ToString("yyyy-MM-dd") });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getProcedencia() });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = vaca.getEstado() });
                    this.dataGridView1.Rows.Add(row);
                }
            }
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

        //Dada una vaca la persiste en la base de datos
        private static void persistirVaca(Vaca vaca) {
            Vaca.PersistirVaca(vaca);
        }

        //Dada una vaca la mata o vende en la base de datos
        private static void matarVenderVaca(Vaca vaca) {
            Vaca.MatarVenderVacaPersistencia(vaca);
        }

        //Dada una vaca retorna true sii la vaca cumple con los filtros solicitados
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
                for(int i = 0; i < lstBoxCat.CheckedItems.Count; i++) {
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

        private void limpiarArchivosSubidos() {
            archivosAgregar = 0;
            vacasAgregar.Clear();
            actualizarLblArchivosSubidos();
        }

        private void actualizarLblArchivosSubidos() {
            this.lblArchivosSubidos.Text = archivosAgregar.ToString();
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
                    case Estado.Muerta:
                    case Estado.Vendida:
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

        private void btnSubir_Click(object sender, EventArgs e) {
            try {
                string procedencia = txtProcedenciaAuto.Text;
                int categoriaSelectedIndex = cboCatAuto.SelectedIndex;
                int estadoSelectedIndex = cboEstadoAuto.SelectedIndex;
                if(estadoSelectedIndex != -1) {
                    bool muertaVendida = (Estado)estadoSelectedIndex == Estado.Muerta || (Estado)estadoSelectedIndex == Estado.Vendida;
                    if((procedencia != "" && categoriaSelectedIndex != -1) || muertaVendida) {
                        using(OpenFileDialog openFileDialog = new OpenFileDialog()) {
                            openFileDialog.Filter = "Excel Files (*.csv;*.xlsx;*.xls)|*.csv;*.xlsx;*.xls|All Files (*.*)|*.*";
                            if(openFileDialog.ShowDialog() == DialogResult.OK) {
                                string filePath = openFileDialog.FileName;
                                List<Vaca> vacasArchivo;
                                if(openFileDialog.SafeFileName.Contains(".csv")) {
                                    vacasArchivo = LectorArchivos.VacasEnCsv(filePath, muertaVendida);
                                }
                                else if(openFileDialog.SafeFileName.Contains(".xlsx")) {
                                    vacasArchivo = LectorArchivos.VacasEnXlsx(filePath, muertaVendida);
                                }
                                else {
                                    vacasArchivo = LectorArchivos.VacasEnXls(filePath, muertaVendida);
                                }
                                int cantidadRepetidas = Vaca.EliminarRepetidas(ref vacasArchivo);
                                if(cantidadRepetidas == -1) return;

                                DialogResult result = MessageBox.Show("Se leyeron: " + (vacasArchivo.Count + cantidadRepetidas) + " animales, de los cuales " + cantidadRepetidas + " repetidas fueron eliminadas, Quedaron: " + vacasArchivo.Count + " ¿Desea Continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if(result == DialogResult.Yes) {
                                    if(!muertaVendida) {
                                        foreach(Vaca vaca in vacasArchivo) {
                                            vaca.setCategoria((Categoria)categoriaSelectedIndex);
                                            vaca.setProcedencia(procedencia);
                                            vaca.setEstado((Estado)estadoSelectedIndex);
                                        }
                                        vacasAgregar.AddRange(vacasArchivo);
                                    }
                                    else {
                                        foreach(Vaca vaca in vacasArchivo) {
                                            vaca.setEstado((Estado)estadoSelectedIndex);
                                            vaca.setCategoria(dictVacas[vaca.getId()].getCategoria());
                                            vaca.setProcedencia(dictVacas[vaca.getId()].getProcedencia());
                                        }
                                        vacasAgregar.AddRange(vacasArchivo);
                                    }
                                    this.archivosAgregar++;
                                    this.actualizarLblArchivosSubidos();
                                }
                            }
                        }
                    }
                    else {
                        MessageBox.Show("Rellene todos los datos de la actualización automática");
                    }
                }
                else {
                    MessageBox.Show("Rellene los datos del estado");
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button3_Click(object sender, EventArgs e) {
            if(this.vacas.Count > 0) {
                List<Vaca> filtrada = new List<Vaca>();
                foreach(Vaca vaca in this.vacas) {
                    if(cumpleFiltrosVaca(vaca)) filtrada.Add(vaca);
                }
                Vaca.GenerarXlsxListaVacas(filtrada, "VistaSistemaGestionGanado");
            }
        }

        private void btnExportaGanadoDesaparecido_Click(object sender, EventArgs e) {
            if(datePickerPrimerPes1.Checked && datePickerPrimerPes2.Checked && datePickerSegPes1.Checked && datePickerSegPes2.Checked) {
                string proc = txtProcedenciaGanadoDesaparecido.Text;
                List<Categoria> categorias = new List<Categoria>();
                for(int i = 0; i < lstBoxCatGanadoDesaparecido.CheckedItems.Count; i++) {
                    categorias.Add((Categoria)Enum.Parse(typeof(Categoria), lstBoxCatGanadoDesaparecido.CheckedItems[i].ToString()));
                }
                Consultas.ExportarGanadoDesaparecido(datePickerPrimerPes1.Value, datePickerPrimerPes2.Value,
                    datePickerSegPes1.Value, datePickerSegPes2.Value, proc, categorias);
            }
            else {
                MessageBox.Show("Rellene todos los datos");
            }
        }

        private void btnExportarGG_Click(object sender, EventArgs e) {
            if(datePickerPrimerPes1GG.Checked && datePickerPrimerPes2GG.Checked && datePickerSegPes1GG.Checked && datePickerSegPes2GG.Checked) {
                string proc = txtProcedenciaGG.Text;
                List<Categoria> categorias = new List<Categoria>();
                for(int i = 0; i < lstBoxCatGG.CheckedItems.Count; i++) {
                    categorias.Add((Categoria)Enum.Parse(typeof(Categoria), lstBoxCatGG.CheckedItems[i].ToString()));
                }
                Consultas.ExportarGananciaGanado(datePickerPrimerPes1GG.Value, datePickerPrimerPes2GG.Value,
                    datePickerSegPes1GG.Value, datePickerSegPes2GG.Value, proc, categorias);
            }
            else {
                MessageBox.Show("Rellene todos los datos");
            }
        }

        private void btnReidentificacion_Click(object sender, EventArgs e) {
            if(txtIdReid1.Text != "" && txtIdReid2.Text != "") {
                Vaca.ReidentificarVaca(txtIdReid1.Text, txtIdReid2.Text);
                this.actualizarGridView(true);
            }
            else {
                MessageBox.Show("Rellene todos los datos");
            }
        }

        private void btnAgregarAuto_Click(object sender, EventArgs e) {
            if(vacasAgregar.Count > 0) {
                int repetidas = Vaca.EliminarRepetidas(ref vacasAgregar);
                DialogResult result = MessageBox.Show("Se leyeron: " + (vacasAgregar.Count + repetidas) +
                    " animales, de los cuales " + repetidas + " repetidas fueron eliminadas, Quedaron: " + vacasAgregar.Count +
                    " ¿Desea Continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes) {
                    foreach(Vaca vaca in vacasAgregar) {
                        if(vaca.getEstado() == Estado.Viva) {
                            persistirVaca(vaca);
                        }
                        else {
                            matarVenderVaca(vaca);
                        }
                    }
                    actualizarGridView(true);
                    limpiarArchivosSubidos();
                }
            }
            else {
                MessageBox.Show("No hay archivos que agregar");
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            limpiarArchivosSubidos();
        }

        private void btnConfig_Click(object sender, EventArgs e) {
            src.Front.Config config = new src.Front.Config(this);
            config.ShowDialog();
        }
    }
}
