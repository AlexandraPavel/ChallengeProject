using System;
using System.Collections.Generic;

#nullable disable

namespace AzureApp
{
    public partial class Consumer
    {
        public Consumer()
        {
            Challenges = new HashSet<Challenge>();
            Credentials = new HashSet<Credential>();
            DescriptionConsumers = new HashSet<DescriptionConsumer>();
            EnrolledInChallenges = new HashSet<EnrolledInChallenge>();
        }

        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string LinkProfilePhoto { get; set; }

        public virtual ICollection<Challenge> Challenges { get; set; }
        public virtual ICollection<Credential> Credentials { get; set; }
        public virtual ICollection<DescriptionConsumer> DescriptionConsumers { get; set; }
        public virtual ICollection<EnrolledInChallenge> EnrolledInChallenges { get; set; }
    }
}
