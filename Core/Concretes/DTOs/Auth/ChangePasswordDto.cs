using System.Security.Claims;

namespace Core.Concretes.DTOs.Auth
{
    public record ChangePasswordDto(ClaimsPrincipal User, string OldPassword, string NewPassword);
}
