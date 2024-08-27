namespace DelfostiChallenge.Core.Entities
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public int IdRol { get; set; }
        public RolEntity Rol { get; set; }
    }
}
