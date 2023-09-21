using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGanado.src.Back {
    public class Vaca {
        private string id;
        private float pesoActual;
        private DateTime ultimaVezPesada;
        private Categoria categoria;
        private string procedencia;
        private Estado estado;
        private List<DateTime> fechasPesada;
        private List<float> pesos;
        private List<string> procedencias;
        private List<Estado> estados;

        public Vaca(string id, float peso, DateTime fecha, Categoria cat, string proc, Estado estado) {
            this.id = id;
            this.pesoActual = peso;
            this.ultimaVezPesada = fecha;
            this.categoria = cat;
            this.procedencia = proc;
            this.fechasPesada = new List<DateTime>();
            this.fechasPesada.Add(fecha);
            this.pesos = new List<float>();
            this.pesos.Add(peso);
            this.procedencias = new List<string>();
            this.procedencias.Add(proc);
            this.estado = estado;
            this.estados = new List<Estado>();
            this.estados.Add(estado);
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

    }
}
