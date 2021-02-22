using System;
using System.Collections.Generic;

#nullable disable

namespace AzureApp
{
    public partial class EnrolledInChallenge
    {
        public int EnrollingId { get; set; }
        public int ChallengeId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int? NumberDays { get; set; }

        public virtual Challenge Challenge { get; set; }
        public virtual Status Status { get; set; }
        public virtual Consumer User { get; set; }
    }
}
