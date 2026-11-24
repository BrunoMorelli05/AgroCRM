using System.Collections.Generic;

namespace AgroCRM.BE
{
    public class Rubro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Producto> Productos { get; set; }
        public Rubro(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }
        public Rubro() { }
    }
}