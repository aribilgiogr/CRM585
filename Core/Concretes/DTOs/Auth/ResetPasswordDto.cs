namespace Core.Concretes.DTOs.Auth
{
    public record ResetPasswordDto(string Email, string Password, string Token);
}
