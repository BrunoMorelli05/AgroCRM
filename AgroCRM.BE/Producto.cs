using System.Collections.Generic;

namespace AgroCRM.BE
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public List<Rubro> Rubros { get; set; }
        public Producto(int id, string nombre, int stock, decimal precio)
        {
            ID = id;
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
        }
        public Producto() { }
    }
}