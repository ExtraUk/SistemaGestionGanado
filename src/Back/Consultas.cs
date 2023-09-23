using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionGanado.src.Back {
    class Consultas {
        public static void ExportarGanadoDesaparecido(DateTime fecha1, DateTime fecha2, DateTime fecha3, DateTime fecha4, string procedencia, List<Categoria> categorias) {
            List<Vaca> desaparecidas = Persistencia.Consultas.GanadoDesaparecido(fecha1, fecha2, fecha3, fecha4, procedencia, categorias);
            Vaca.GenerarXlsxListaVacas(desaparecidas, "DesaparecidasSistemaGestionGanado");
        }

        public static void ExportarGananciaGanado(DateTime fecha1, DateTime fecha2, DateTime fecha3, DateTime fecha4, string procedencia, List<Categoria> categorias) {
            List<List<Vaca>> vacas = Persistencia.Consultas.GananciaGanado(fecha1, fecha2, fecha3, fecha4, procedencia, categorias);
            if(vacas.Count == 2) {
                List<Vaca> rango1 = vacas[0], rango2 = vacas[1];
                if(rango1.Count > 0 && rango2.Count > 0) {
                    Dictionary<string, Vaca> dictRango2 = new Dictionary<string, Vaca>(rango2.Count);
                    foreach(Vaca vaca in rango2) {
                        if(!dictRango2.ContainsKey(vaca.getId())) dictRango2.Add(vaca.getId(), vaca);
                    }
                    List<Vaca> vacas1 = new List<Vaca>(), vacas2 = new List<Vaca>();
                    foreach(Vaca vaca in rango2) {
                        if(dictRango2.ContainsKey(vaca.getId())) {
                            vacas1.Add(vaca);
                            vacas2.Add(dictRango2[vaca.getId()]);
                        }
                    }
                    GenerarArchivosGananciaGanado(vacas1, vacas2, fecha1, fecha4, rango1.Count, rango2.Count);
                    return;
                }
            }
            MessageBox.Show("No se encontraron animales con los filtros solicitados");
        }

        public static void GenerarArchivosGananciaGanado(List<Vaca> vacas1, List<Vaca> vacas2, DateTime fecha1, DateTime fecha2, int ganadoInicial, int ganadoFinal) {
            int cantidadCategorias = Enum.GetValues(typeof(Categoria)).Length;
            int[] cantidadPorCategoria = new int[cantidadCategorias];
            float[] pesosPorCategoria = new float[cantidadCategorias];
            float[] pesosPorCategoriaPorDia = new float[cantidadCategorias];
            int diffDias = ((int)fecha2.Subtract(fecha1).TotalDays);
            for(int i=0; i<cantidadCategorias; i++) {
                cantidadPorCategoria[i] = 0;
                pesosPorCategoria[i] = 0;
                pesosPorCategoriaPorDia[i] = 0;
            }
            float gananciaTotal = GenerarXlsx(vacas1, vacas2, ref cantidadPorCategoria, ref pesosPorCategoria, ref pesosPorCategoriaPorDia);
            GenerarInforme(fecha1, fecha2, ganadoInicial, ganadoFinal, diffDias, cantidadPorCategoria, pesosPorCategoria, pesosPorCategoriaPorDia, gananciaTotal, vacas1.Count);
        }

        private static float GenerarXlsx(List<Vaca> vacas1, List<Vaca> vacas2, ref int[] cantidadPorCategoria, ref float[] pesosPorCategoria, ref float[] pesosPorCategoriaPorDia) {
            float gananciaTotal = 0;
            using(var saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                saveFileDialog.FileName = DateTime.Today.ToString("yyyy-MM-dd") + "-GananciaVacasSistemaGestionGanado";
                if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = saveFileDialog.FileName;

                    using(var workbook = new XLWorkbook()) {
                        var worksheet = workbook.Worksheets.Add("Output");
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Id";
                        worksheet.Cell(currentRow, 2).Value = "Peso Inicial";
                        worksheet.Cell(currentRow, 3).Value = "Peso Final";
                        worksheet.Cell(currentRow, 4).Value = "Fecha Inicial";
                        worksheet.Cell(currentRow, 5).Value = "Fecha Final";
                        worksheet.Cell(currentRow, 6).Value = "Procedencia Inicial";
                        worksheet.Cell(currentRow, 7).Value = "Procedencia Final";
                        worksheet.Cell(currentRow, 8).Value = "Categoria";
                        worksheet.Cell(currentRow, 9).Value = "Estado Actual";
                        worksheet.Cell(currentRow, 10).Value = "Diferencia de Peso";
                        for(int i = 0; i < vacas1.Count; i++) {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = vacas1[i].getId();
                            worksheet.Cell(currentRow, 2).Value = vacas1[i].getPesoActual();
                            worksheet.Cell(currentRow, 3).Value = vacas2[i].getPesoActual();
                            worksheet.Cell(currentRow, 4).Value = vacas1[i].getUltimaVezPesada();
                            worksheet.Cell(currentRow, 5).Value = vacas2[i].getUltimaVezPesada();
                            worksheet.Cell(currentRow, 6).Value = vacas1[i].getProcedencia();
                            worksheet.Cell(currentRow, 7).Value = vacas2[i].getProcedencia();
                            worksheet.Cell(currentRow, 8).Value = vacas1[i].getCategoria().ToString();
                            worksheet.Cell(currentRow, 9).Value = vacas1[i].getEstado().ToString();
                            float diff = vacas2[i].getPesoActual() - vacas1[i].getPesoActual();
                            worksheet.Cell(currentRow, 10).Value = diff;
                            int dias = ((int)vacas2[i].getUltimaVezPesada().Subtract(vacas1[i].getUltimaVezPesada()).TotalDays);
                            if(diff > 0) {
                                worksheet.Cell(currentRow, 10).Style.Fill.SetBackgroundColor(XLColor.Green);
                            }
                            else {
                                worksheet.Cell(currentRow, 10).Style.Fill.SetBackgroundColor(XLColor.Red);
                            }
                            cantidadPorCategoria[((int)vacas1[i].getCategoria())]++;
                            pesosPorCategoria[((int)vacas1[i].getCategoria())] += diff;
                            pesosPorCategoriaPorDia[((int)vacas1[i].getCategoria())] += diff / dias;
                            gananciaTotal += diff;
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
            return gananciaTotal;
        }

        private static void GenerarInforme(DateTime fecha1, DateTime fecha2, int ganadoInicial, int ganadoFinal, int diffDias, int[] cantidadPorCategoria, float[] pesosPorCategoria, float[] pesosPorCategoriaPorDia, float gananciaTotal, int cantidadGanadoTotal) {
            using(var saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.FileName = DateTime.Today.ToString("yyyy-MM-dd") + "-ResumenGananciaVacasSistemaGestionGanado";
                if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = saveFileDialog.FileName;
                    string content = "Resumen Ganancia de Ganado entre: " + fecha1.ToString("yyyy-MM-dd") + " y " + fecha2.ToString("yyyy-MM-dd") + " (" + diffDias + " dias)" +
                        "\nGanado en Rango Inicial: " + ganadoInicial +
                        "\nGanado en Rango Final: " + ganadoFinal +
                        "\nGanado en Ambos Rangos: " + cantidadGanadoTotal +
                        "\n" +
                        "\nGanancia Total: " + gananciaTotal + " Kg" +
                        "\nGanancia Total por Dia: " + gananciaTotal / diffDias + " Kg/dia" +
                        "\nPromedio de Ganancia Total por Dia por Animal: " + gananciaTotal / (diffDias * cantidadGanadoTotal) + " Kg/dia por animal" +
                        "\n";
                    foreach(Categoria categoria in Enum.GetValues(typeof(Categoria))) {
                        if(cantidadPorCategoria[((int)categoria)] > 0) {
                            content += "\n" + categoria.ToString() + ":" +
                                "\n    Ganancia Total: " + pesosPorCategoria[(int)categoria] + " Kg" +
                                "\n    Promedio Ganancia por Animal: " + pesosPorCategoria[(int)categoria]/ cantidadPorCategoria[((int)categoria)] +
                                "\n    Ganancia Total Por Dia: " + pesosPorCategoriaPorDia[(int)categoria] + " Kg/dia" +
                                "\n    Promedio de Ganancia Total por Dia por Animal: " + pesosPorCategoriaPorDia[(int)categoria] / cantidadPorCategoria[(int)categoria] + " Kg/dia por animal" +
                                "\n    Total de Animales: " + cantidadPorCategoria[((int)categoria)] + "\n";
                        }
                    }

                    using(var stream = new MemoryStream()) {
                        File.WriteAllText(filePath, content);
                        MessageBox.Show("Archivo Guardado con Exito");
                    }
                }
            }
        }
    }
}
