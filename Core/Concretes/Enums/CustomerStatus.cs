namespace Core.Concretes.Enums
{
    public enum CustomerStatus
    {
        Potential = 1,
        Active = 2,
        Inactive = 3,
        Lost = 4
    }

    public enum OpportunityStage
    {
        Qualification = 1,
        NeedsAnalysis = 2,
        Proposal = 3,
        Negotiation = 4,
        ClosedWon = 5,
        ClosedLost = 6
    }

    public enum OpportunityStatus
    {
        Open = 1,
        Won = 2,
        Lost = 3
    }
}
