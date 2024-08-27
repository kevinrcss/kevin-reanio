namespace DelfostiChallenge.Core.Entities
{
    public class RolEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ICollection<UsuarioEntity> Usuarios { get; set; }
    }
}
