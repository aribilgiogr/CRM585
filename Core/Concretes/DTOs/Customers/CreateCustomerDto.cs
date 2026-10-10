using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Core.Concretes.DTOs.Customers
{
    public record CreateCustomerDto(string Name, string? TaxNumber, string? TaxOffice, string? Address, string? City, bool Individual, string? AssignedUserId);
}
