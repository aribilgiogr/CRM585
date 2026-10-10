using Core.Concretes.Enums;

namespace Core.Concretes.DTOs.Customers
{
    public record CustomerListItemDto(string Id, string Name, bool Individual, CustomerStatus Status, string? AssignedUserId, string? AssignedUserName, int ActivityCount, int OpportunityCount);
}
