using Core.Concretes.DTOs.Customers;
using System.Security.Claims;

namespace Core.Abstracts.IServices
{
    public interface ICustomerService
    {
        IEnumerable<CustomerListItemDto> GetCustomers(ClaimsPrincipal user);
        Task<CustomerDetailDto?> GetCustomerByIdAsync(string customerId);
    }
}
