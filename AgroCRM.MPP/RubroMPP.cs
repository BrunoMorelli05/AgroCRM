using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroCRM.DAL;
using AgroCRM.BE;
using System.Data;
using System.Collections;
namespace AgroCRM.MPP
{
    public class RubroMPP
    {
        private Acceso acceso = new Acceso();
        public bool RegistrarRubros(Rubro rubro)
        {
            try
            {
                string consulta = "SP_RegistrarRubros";
                Hashtable hashdatos = new Hashtable();
                hashdatos.Add("@Nombre", rubro.Nombre);
                return acceso.Escribir(consulta, hashdatos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el rubro: " + ex.Message);
            }
        }
        public bool EliminarRubros(int idRubro)
        {
            try
            {
                string consulta = "SP_EliminarRubros";
                Hashtable hashdatos = new Hashtable();
                hashdatos.Add("@IdRubro", idRubro);
                return acceso.Escribir(consulta, hashdatos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rubro: " + ex.Message);
            }
        }
        public bool ModificarRubros(Rubro rubro)
        {
            try
            {
                string consulta = "SP_ModificarRubros";
                Hashtable hashdatos = new Hashtable();
                hashdatos.Add("@IdRubro", rubro.ID);
                hashdatos.Add("@Nombre", rubro.Nombre);
                return acceso.Escribir(consulta, hashdatos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el rubro: " + ex.Message);
            }
        }
        public bool ReactivarRubros(int IdRubro)
        {
            try
            {
                string consulta = "SP_AltaRubros";
                Hashtable hashdatos = new Hashtable();
                hashdatos.Add("@IdRubro", IdRubro);
                return acceso.Escribir(consulta, hashdatos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al reactivar el rubro: " + ex.Message);
            }
        }
        public List<Rubro> ListarRubros(string filtro = null)
        {
            try
            {
                Hashtable hashdatos = new Hashtable();
                if (!string.IsNullOrWhiteSpace(filtro))
                    hashdatos.Add("@Nombre", filtro);
                DataTable tabla = acceso.Leer("SP_ListarRubros", hashdatos);
                List<Rubro> rubros = new List<Rubro>();
                foreach (DataRow fila in tabla.Rows)
                {
                    rubros.Add(MapearFila(fila));
                }
                return rubros;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los rubros: " + ex.Message);
            }
        }
        public Rubro BuscarRubroPorId(int idRubro)
        {
            try
            {
                Hashtable hashdatos = new Hashtable();
                hashdatos.Add("@IdRubro", idRubro);
                DataTable tabla = acceso.Leer("SP_BuscarRubroPorId", hashdatos);
                return tabla.Rows.Count > 0 ? MapearFila(tabla.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el rubro por ID: " + ex.Message);
            }
        }
        public Rubro BuscarRubroPorNombre(string nombre)
        {
            try
            {
                Hashtable hashdatos = new Hashtable();
                hashdatos.Add("@Nombre", nombre);
                DataTable tabla = acceso.Leer("SP_BuscarRubroPorNombre", hashdatos);
                return tabla.Rows.Count > 0 ? MapearFila(tabla.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el rubro por nombre: " + ex.Message);
            }
        }
        private Rubro MapearFila(DataRow fila)
        {
            try
            {
                Rubro rubro = new Rubro
                {
                    Nombre = fila["Nombre"].ToString(),
                    Activo = Convert.ToBoolean(fila["Activo"])
                };
                rubro.ID = Convert.ToInt32(fila["IdRubro"]);
                return rubro;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear la fila a un objeto Rubro: " + ex.Message);
            }
        }
    }
}