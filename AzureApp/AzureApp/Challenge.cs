using System;
using System.Collections.Generic;

#nullable disable

namespace AzureApp
{
    public partial class Challenge
    {
        public Challenge()
        {
            EnrolledInChallenges = new HashSet<EnrolledInChallenge>();
        }

        public int ChallengeId { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginningDate { get; set; }
        public int NumberOfDays { get; set; }

        public virtual Consumer Owner { get; set; }
        public virtual ICollection<EnrolledInChallenge> EnrolledInChallenges { get; set; }
    }
}
