using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGanado.src.Back {
    public class Categoria {
        private String nombre;

        public Categoria(String pNombre) {
            this.nombre = pNombre;
        }

        public String getNombre() {
            return this.nombre;
        }

        public void setNombre(String pNombre) {
            this.nombre = pNombre;
        }
    }
}
