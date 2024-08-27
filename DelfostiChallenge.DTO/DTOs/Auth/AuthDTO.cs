namespace DelfostiChallenge.DTO.DTOs.Auth
{
    public class AuthDTO
    {
        public string Token { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public DateTime? TokenExpiration { get; set; }
    }
}
