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
            }

            return retorno;
        }
    }
}
