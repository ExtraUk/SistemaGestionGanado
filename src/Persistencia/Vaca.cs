using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SistemaGestionGanado.src.Persistencia {
    class Vaca {
        public static bool Agregar(Back.Vaca vaca) {
            bool retorno = true;
            try {
                var conn = new SqlConnection(Persistencia.CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("VacaAgregar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idVaca", vaca.getId()));
                cmd.Parameters.Add(new SqlParameter("@pesoVaca", vaca.getPesoActual()));
                cmd.Parameters.Add(new SqlParameter("@fechaPesadaVaca", vaca.getUltimaVezPesada()));
                cmd.Parameters.Add(new SqlParameter("@nombreCategoriaVaca", vaca.getCategoria().ToString()));
                cmd.Parameters.Add(new SqlParameter("@nombreProcedenciaVaca", vaca.getProcedencia()));
                cmd.Parameters.Add(new SqlParameter("@estadoVaca", vaca.getEstado().ToString()));

                int rtn = cmd.ExecuteNonQuery();

                if(rtn <= 0) {
                    retorno = false;
                }

                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }
            return retorno;
        }

        public static bool Remover(Back.Vaca vaca) {
            bool retorno = true;
            try {
                var conn = new SqlConnection(Persistencia.CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("VacaRemover", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idVaca", vaca.getId()));

                int rtn = cmd.ExecuteNonQuery();

                if(rtn <= 0) {
                    retorno = false;
                }

                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }
            return retorno;
        }

        public static bool MatarVender(Back.Vaca vaca) {
            bool retorno = true;
            try {
                var conn = new SqlConnection(Persistencia.CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("VacaMatarVender", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idVaca", vaca.getId()));
                cmd.Parameters.Add(new SqlParameter("@fechaPesadaVaca", vaca.getUltimaVezPesada()));
                cmd.Parameters.Add(new SqlParameter("@estado", vaca.getEstado().ToString()));
                cmd.Parameters.Add(new SqlParameter("@nombreCategoriaVaca", vaca.getCategoria().ToString()));
                cmd.Parameters.Add(new SqlParameter("@nombreProcedenciaVaca", vaca.getProcedencia()));

                int rtn = cmd.ExecuteNonQuery();

                if(rtn <= 0) {
                    retorno = false;
                }

                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }
            return retorno;
        }

        public static List<Back.Vaca> TraerTodas() {
            List<Back.Vaca> retorno = new List<Back.Vaca>();
            Back.Vaca vaca;

            try {
                var conn = new SqlConnection(Persistencia.CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("VacaTraerTodas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using(SqlDataReader oReader = cmd.ExecuteReader()) {
                    Dictionary<string, bool> conjuntoVacas = new Dictionary<string, bool>();
                    while(oReader.Read()) {
                        string id = oReader["idVaca"].ToString();
                        if(!conjuntoVacas.ContainsKey(id)) {
                            conjuntoVacas.Add(id, true);
                            vaca = new Back.Vaca();
                            vaca.setId(id);
                            vaca.setEstado((Back.Estado)Enum.Parse(typeof(Back.Estado), oReader["estado"].ToString()));
                            vaca.setCategoria((Back.Categoria)Enum.Parse(typeof(Back.Categoria), oReader["nombreCategoria"].ToString()));
                            vaca.setProcedencia(oReader["nombreProcedencia"].ToString());
                            vaca.setUltimaVezPesada(DateTime.Parse(oReader["fechaPesada"].ToString()));
                            vaca.setPesoActual(float.Parse(oReader["pesoVaca"].ToString()));
                            retorno.Add(vaca);
                        }
                    }

                    conn.Close();
                }

            }
            catch(Exception ex) {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }
    }
}
