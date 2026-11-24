using System.Collections.Generic;
namespace AgroCRM.BE
{
    public abstract class Cliente
    {
        public int ID { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Necesidades { get; set; }
        public List<Rubro> Rubros { get; set; }
        public Cliente(int id, string telefono, string email, string necesidades)
        {
            ID = id;
            Telefono = telefono;
            Email = email;
            Necesidades = necesidades;
        }
        public Cliente() { }
    }
}