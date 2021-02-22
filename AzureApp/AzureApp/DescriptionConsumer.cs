using System;
using System.Collections.Generic;

#nullable disable

namespace AzureApp
{
    public partial class DescriptionConsumer
    {
        public int DescriptionId { get; set; }
        public int IdUser { get; set; }
        public int? ChallengesFinished { get; set; }
        public int? ChallengesCreated { get; set; }
        public int? ChallengesInUse { get; set; }

        public virtual Consumer IdUserNavigation { get; set; }
    }
}
