using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

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
                            if(values[0].Length < 5) return null;
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
                            if(values[0].Length < 5) return null;
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

        public static List<Vaca> VacasEnXlsx(string filePath, bool muertaVendida) {
            List<Vaca> vacasEnXlsx = new List<Vaca>();
            try {
                using(var workbook = new XLWorkbook(filePath)) {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    foreach(var row in worksheet.RowsUsed()) {
                        string[] linea = new string[row.CellsUsed().Count()];
                        for(int i=0; i<linea.Length; i++) {
                            linea[i] = row.CellsUsed().ElementAt(i).Value.ToString();
                        }
                        Vaca vaca = LeerLinea(linea, muertaVendida);
                        if(vaca != null) {
                            vacasEnXlsx.Add(vaca);
                        }
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return vacasEnXlsx;
        }

        public static List<Vaca> VacasEnXls(string filePath, bool muertaVendida) {
            List<Vaca> vacasEnXls = new List<Vaca>();
            try {
                using(FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) { 
                    IWorkbook workbook = new HSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    foreach(IRow row in sheet) { 
                        string[] linea = new string[row.Cells.Count()];
                            for(int i = 0; i < linea.Length; i++) {
                                linea[i] = row.Cells[i].ToString();
                            }
                            Vaca vaca = LeerLinea(linea, muertaVendida);
                            if(vaca != null) {
                                vacasEnXls.Add(vaca);
                            }
                        }
                    }
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return vacasEnXls;
        }
    }
}
