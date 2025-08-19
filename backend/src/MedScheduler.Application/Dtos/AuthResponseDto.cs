namespace MedScheduler.Application.Dtos
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public string Role { get; set; } = null!;
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
    }
}

