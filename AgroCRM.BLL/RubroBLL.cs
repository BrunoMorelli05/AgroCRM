using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroCRM.MPP;
using AgroCRM.BE;
namespace AgroCRM.BLL
{
    public class RubroBLL
    {
        private RubroMPP rubroMPP = new RubroMPP();
        private void Validar(Rubro rubro)
        {
            if (rubro == null || string.IsNullOrWhiteSpace(rubro.Nombre)) throw new Exception("El nombre del rubro es obligatorio");
            rubro.Nombre = rubro.Nombre.Trim();
            if (rubro.Nombre.Length > 50) throw new Exception("El nombre no puede superar los 50 caracteres.");
        }
        public bool RegistrarRubros(Rubro rubro)
        {
            Validar(rubro);
            Rubro existente = rubroMPP.BuscarRubroPorNombre(rubro.Nombre);
            if (existente == null)
                return rubroMPP.RegistrarRubros(rubro);
            if (!existente.Activo)
                return rubroMPP.ReactivarRubros(existente.ID);
            throw new Exception("Ya existe un rubro con ese nombre.");
        }
        public bool ModificarRubros(Rubro rubro)
        {
            Validar(rubro);
            Rubro idExistente = rubroMPP.BuscarRubroPorId(rubro.ID);
            if (idExistente == null || !idExistente.Activo) throw new Exception("El rubro no existe o esta inactivo");
            Rubro nombreExistente = rubroMPP.BuscarRubroPorNombre(rubro.Nombre);
            if (nombreExistente != null && nombreExistente.ID != idExistente.ID) throw new Exception("Ya existe un rubro con ese nombre.");
            return rubroMPP.ModificarRubros(rubro);
        }
        public bool EliminarRubros(Rubro rubro)
        {
            Validar(rubro);
            Rubro idExistente = rubroMPP.BuscarRubroPorId(rubro.ID);
            if (idExistente == null || !idExistente.Activo) throw new Exception("El rubro no existe o esta inactivo");
            return rubroMPP.EliminarRubros(rubro.ID);
        }
        public List<Rubro> ListarRubros(string filtro = null)
        {
            if (!string.IsNullOrWhiteSpace(filtro)) filtro.Trim();
            return rubroMPP.ListarRubros(filtro);
        }
    }
}
 