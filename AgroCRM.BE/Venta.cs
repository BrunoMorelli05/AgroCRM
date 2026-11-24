using System;
using System.Collections.Generic;

namespace AgroCRM.BE
{
    public class Venta
    {
        public int ID { get; set; }
        public Cliente Cliente { get; set; }
        public List<Detalle_Venta> Detalles { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public Venta(int id, DateTime fecha, decimal monto, Cliente cliente)
        {
            ID = id;
            Fecha = fecha;
            Monto = monto;
            Cliente = cliente;
        }
        public Venta() { }
    }
}