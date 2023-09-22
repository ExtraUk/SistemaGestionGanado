using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SistemaGestionGanado.src.Persistencia {
    class Consultas {
        public static List<Back.Vaca> GanadoDesaparecido(DateTime fecha1, DateTime fecha2, DateTime fecha3, DateTime fecha4, string procedencia, List<Back.Categoria> categorias) {
            List<Back.Vaca> retorno = new List<Back.Vaca>();
            Back.Vaca vaca;
            try {
                var conn = new SqlConnection(Persistencia.CadenaDeConexion);
                conn.Open();
                if(categorias.Count > 0) {
                    foreach(Back.Categoria cat in categorias) {
                        SqlCommand cmd = new SqlCommand("GanadoDesaparecido", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@fechaPrimerPesada1", fecha1));
                        cmd.Parameters.Add(new SqlParameter("@fechaPrimerPesada2", fecha2));
                        cmd.Parameters.Add(new SqlParameter("@fechaSegundaPesada1", fecha3));
                        cmd.Parameters.Add(new SqlParameter("@fechaSegundaPesada2", fecha4));
                        cmd.Parameters.Add(new SqlParameter("@nombreProcedenciaVaca", procedencia));
                        cmd.Parameters.Add(new SqlParameter("@nombreCategoriaVaca", cat.ToString()));
                        using(SqlDataReader oReader = cmd.ExecuteReader()) {
                            retorno.AddRange(SQLReader(oReader));
                        }
                    }
                }
                else {
                    SqlCommand cmd = new SqlCommand("GanadoDesaparecido", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fechaPrimerPesada1", fecha1));
                    cmd.Parameters.Add(new SqlParameter("@fechaPrimerPesada2", fecha2));
                    cmd.Parameters.Add(new SqlParameter("@fechaSegundaPesada1", fecha3));
                    cmd.Parameters.Add(new SqlParameter("@fechaSegundaPesada2", fecha4));
                    cmd.Parameters.Add(new SqlParameter("@nombreProcedenciaVaca", procedencia));
                    cmd.Parameters.Add(new SqlParameter("@nombreCategoriaVaca", "null"));
                    using(SqlDataReader oReader = cmd.ExecuteReader()) {
                        retorno = SQLReader(oReader);
                    }
                }
                conn.Close();
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }

        private static List<Back.Vaca> SQLReader(SqlDataReader oReader) {
            List<Back.Vaca> retorno = new List<Back.Vaca>();
            Dictionary<string, bool> conjuntoVacas = new Dictionary<string, bool>();
            while(oReader.Read()) {
                string id = oReader["idVaca"].ToString();
                if(!conjuntoVacas.ContainsKey(id)) {
                    conjuntoVacas.Add(id, true);
                    Back.Vaca vaca = new Back.Vaca();
                    vaca.setId(id);
                    vaca.setEstado((Back.Estado)Enum.Parse(typeof(Back.Estado), oReader["estado"].ToString()));
                    vaca.setCategoria((Back.Categoria)Enum.Parse(typeof(Back.Categoria), oReader["nombreCategoria"].ToString()));
                    vaca.setProcedencia(oReader["nombreProcedencia"].ToString());
                    vaca.setUltimaVezPesada(DateTime.Parse(oReader["fechaPesada"].ToString()));
                    vaca.setPesoActual(float.Parse(oReader["pesoVaca"].ToString()));
                    retorno.Add(vaca);
                }
            }
            return retorno;
        }
    }
}
