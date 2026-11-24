namespace AgroCRM.BE
{
    public class Cliente_Empresa : Cliente
    {
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public Cliente_Empresa(int id, string telefono, string email, string necesidades, string razonsocial, string cuit) : base(id, telefono, email, necesidades)
        {
            RazonSocial = razonsocial;
            CUIT = cuit;
        }
        public Cliente_Empresa()
        {
        }
    }
}