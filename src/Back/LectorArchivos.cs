using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionGanado.src.Back {
    class LectorArchivos {
        //Dado un archivo csv retorna una lista con todas las vacas del archivo, recibe un bool matarVender que indica el formato del csv
        public static List<Vaca> VacasEnCsv(string filePath, bool matarVender) {
            try {
                List<Vaca> vacasCSV = new List<Vaca>();
                using(StreamReader reader = new StreamReader(filePath)) {
                    while(!reader.EndOfStream) {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        Vaca vaca = LeerLinea(values, matarVender);
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

        //Lee una linea y retorna los datos de la vaca en esa linea, recibe un bool matarVender que indica el formato del csv
        public static Vaca LeerLinea(string[] values, bool matarVender) {
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
    }
}
