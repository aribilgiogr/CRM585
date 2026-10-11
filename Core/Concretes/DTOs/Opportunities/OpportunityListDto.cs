using Core.Concretes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Concretes.DTOs.Opportunities
{
    public class OpportunityListDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Value { get; set; }
        public string Currency { get; set; } = null!;
        public OpportunityStage Stage { get; set; }
        public OpportunityStatus Status { get; set; }
    }
}
