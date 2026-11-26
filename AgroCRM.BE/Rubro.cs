using System.Collections.Generic;

namespace AgroCRM.BE
{
    public class Rubro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Producto> Productos { get; set; } = new List<Producto>();
        public bool Activo { get; set; }
        public Rubro(string nombre)
        {
            Nombre = nombre;
            Activo = true;
        }
        public Rubro() { }
    }
}