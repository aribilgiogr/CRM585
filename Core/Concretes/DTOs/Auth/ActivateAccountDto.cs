using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Concretes.DTOs.Auth
{
    public record ActivateAccountDto(string Email, string Token);
}
