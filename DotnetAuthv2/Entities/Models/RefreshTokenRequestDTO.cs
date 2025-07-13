namespace DotnetAuthv2.Entities.Models
{
    public class RefreshTokenRequestDTO
    {
        public required Guid UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
