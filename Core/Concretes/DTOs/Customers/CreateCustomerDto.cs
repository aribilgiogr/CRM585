using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Core.Concretes.DTOs.Customers
{
    public record CreateCustomerDto(string Name, bool Individual, string? AssignedUserId, string LeadId, string? TaxNumber = null, string? TaxOffice = null, string? Address = null, string? City = null);
}
