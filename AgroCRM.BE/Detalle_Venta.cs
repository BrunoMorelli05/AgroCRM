namespace AgroCRM.BE
{
    public class Detalle_Venta
    {
        public int ID { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public Detalle_Venta(int id, Producto producto, int cantidad, decimal subtotal)
        {
            ID = id;
            Producto = producto;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }
        public Detalle_Venta() { }
    }
}