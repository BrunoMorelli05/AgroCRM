using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

//Capa de acceso a datos
namespace AgroCRM.DAL
{
    public class Acceso
    {
        private SqlConnection conexion;
        private string cadenaconexion = @"Data Source=.\SQLEXPRESS01;Initial Catalog=AgroCRM;Integrated Security=True";
        private SqlCommand cmd;
        public void Abrir()
        {
            conexion = new SqlConnection(cadenaconexion);
            conexion.Open();
        }
        public void Cerrar()
        {
            if (conexion != null && conexion.State != ConnectionState.Closed)
                conexion.Close();
        }
        public DataTable Leer(string consulta, Hashtable hashdatos)
        {
            DataTable tabla = new DataTable();
            try
            {
                Abrir();
                cmd = new SqlCommand(consulta, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if(hashdatos != null)
                {
                    foreach (string datos in hashdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(datos, hashdatos[datos]);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                return tabla;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general: " + ex.Message);
            }
            finally
            {
                Cerrar();
            }
        }
        public bool LeerEscalar(string consulta, Hashtable hashdatos)
        {
            try
            {
                Abrir();
                cmd = new SqlCommand(consulta, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (hashdatos != null)
                {
                    foreach (string datos in hashdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(datos, hashdatos[datos]);
                    }
                }
                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                return resultado > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general: " + ex.Message);
            }
            finally
            {
                Cerrar();
            }
        }
        public bool Escribir(string consulta, Hashtable hashdatos)
        {
            SqlTransaction transaction = null;
            try
            {
                Abrir();
                transaction = conexion.BeginTransaction();
                cmd = new SqlCommand(consulta, conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                if (hashdatos != null)
                {
                    foreach (string datos in hashdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(datos, hashdatos[datos]);
                    }
                }
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw new Exception("Error de SQL Server al guardar los datos " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw new Exception("Error al guardar los datos: " + ex.Message, ex);
            }
            finally
            {
                Cerrar();
            }
    }
    }
}