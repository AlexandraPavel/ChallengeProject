using System;
using System.Collections.Generic;

#nullable disable

namespace AzureApp
{
    public partial class Status
    {
        public Status()
        {
            EnrolledInChallenges = new HashSet<EnrolledInChallenge>();
        }

        public int StatusId { get; set; }
        public string Value { get; set; }

        public virtual ICollection<EnrolledInChallenge> EnrolledInChallenges { get; set; }
    }
}
