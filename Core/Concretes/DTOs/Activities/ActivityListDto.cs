using Core.Concretes.Enums;

namespace Core.Concretes.DTOs.Activities
{
    public class ActivityListDto
    {
        public string Id { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AssignedUserId { get; set; }
        public string? AssignedUserName { get; set; }
        public ActivityType Type { get; set; }
    }
}
