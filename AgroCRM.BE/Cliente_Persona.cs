namespace AgroCRM.BE
{
    public class Cliente_Persona : Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public Cliente_Persona(int id, string telefono, string email, string necesidades, string nombre, string apellido, string dni) : base(id, telefono, email, necesidades)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
        }
        public Cliente_Persona()
        {
        }
    }
}