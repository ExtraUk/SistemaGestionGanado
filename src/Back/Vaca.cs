using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionGanado.src.Back {
    public class Vaca {
        private string id;
        private float pesoActual;
        private DateTime ultimaVezPesada;
        private Categoria categoria;
        private string procedencia;
        private Estado estado;

        public Vaca(string id, float peso, DateTime fecha, Categoria cat, string proc, Estado estado) {
            this.id = id;
            this.pesoActual = peso;
            this.ultimaVezPesada = fecha;
            this.categoria = cat;
            this.procedencia = proc;
            this.estado = estado;
        }
        public Vaca() {

        }

        public Vaca(string id) {
            this.id = id;
        }

        public string getId() { return this.id; }
        public float getPesoActual() { return this.pesoActual; }
        public DateTime getUltimaVezPesada() { return this.ultimaVezPesada; }
        public Categoria getCategoria() { return this.categoria; }
        public string getProcedencia() { return this.procedencia; }
        public Estado getEstado() { return this.estado; }
        public void setId(string id) {
            this.id = id;
        }
        public void setPesoActual(float pesoActual) {
            this.pesoActual = pesoActual;
        }
        public void setUltimaVezPesada(DateTime ultimaVezPesada) {
            this.ultimaVezPesada = ultimaVezPesada;
        }
        public void setCategoria(Categoria categoria) {
            this.categoria = categoria;
        }
        public void setProcedencia(string procedencia) {
            this.procedencia = procedencia;
        }
        public void setEstado(Estado estado) {
            this.estado = estado;
        }

        public static bool PersistirVaca(Vaca vaca) {
            return Persistencia.Vaca.Agregar(vaca);
        }

        public static Vaca BuscarVacaPorId(string id, List<Vaca> vacas) {
            Vaca retorno = null;
            if(vacas != null) {
                foreach(Vaca vaca in vacas) {
                    if(vaca.getId().Equals(id)) {
                        retorno = vaca;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static bool EliminarVacaPersistencia(Vaca vaca) {
            return Persistencia.Vaca.Remover(vaca);
        }

        public static bool MatarVenderVacaPersistencia(Vaca vaca) {
            return Persistencia.Vaca.MatarVender(vaca);
        }

        public static void GenerarXlsxListaVacas(List<Vaca> vacas, string titulo) {
            using(var saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                saveFileDialog.FileName = DateTime.Today.ToString("yyyy-MM-dd") + "-" + titulo;
                if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = saveFileDialog.FileName;

                    using(var workbook = new XLWorkbook()) {
                        var worksheet = workbook.Worksheets.Add("Output");
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Id";
                        worksheet.Cell(currentRow, 2).Value = "Peso";
                        worksheet.Cell(currentRow, 3).Value = "Categoria";
                        worksheet.Cell(currentRow, 4).Value = "Fecha";
                        worksheet.Cell(currentRow, 5).Value = "Procedencia";
                        worksheet.Cell(currentRow, 6).Value = "Estado";
                        foreach(Vaca vaca in vacas) {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = vaca.getId();
                            worksheet.Cell(currentRow, 2).Value = vaca.getPesoActual();
                            worksheet.Cell(currentRow, 3).Value = vaca.getCategoria().ToString();
                            worksheet.Cell(currentRow, 4).Value = vaca.getUltimaVezPesada();
                            worksheet.Cell(currentRow, 5).Value = vaca.getProcedencia();
                            worksheet.Cell(currentRow, 6).Value = vaca.getEstado().ToString();
                        }

                        using(var stream = new MemoryStream()) {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            File.WriteAllBytes(filePath, content);

                            MessageBox.Show("Archivo Guardado con Exito");
                        }
                    }
                }
            }
        }

        public static void ReidentificarVaca(string idInicial, string idFinal) {
            if(Persistencia.Vaca.Reidentificar(idInicial, idFinal)) {
                MessageBox.Show("Re-Identificado con Exito");
            }
            else {
                MessageBox.Show("No se encontró animal con el Id: " + idInicial);
            }
        }

        //Dada una lista de Vacas elimina repetidas y retorna la cantidad de repetidas que elimino
        public static int EliminarRepetidas(ref List<Vaca> vacas) {
            try {
                Dictionary<string, bool> conjuntoVacas = new Dictionary<string, bool>(vacas.Count);
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

        public static void LimpiarEliminadas() {
            try {
                Persistencia.Vaca.LimpiarEliminadas();
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RestaurarEliminadas() {
            try {
                Persistencia.Vaca.RestaurarEliminadas();
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void OrdenarListaVacas(ref List<Vaca> desaparecidas) {
            desaparecidas.Sort((x, y) => {
                int compararEstados = x.getEstado().CompareTo(y.getEstado());
                return compararEstados != 0 ? compararEstados : x.getProcedencia().CompareTo(y.getProcedencia());
            });
        }
    }
}
