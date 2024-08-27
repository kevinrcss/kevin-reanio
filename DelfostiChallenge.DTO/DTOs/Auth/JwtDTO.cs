namespace DelfostiChallenge.DTO.DTOs.Auth
{
    public class JwtDTO
    {
        public string Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
    }
}
