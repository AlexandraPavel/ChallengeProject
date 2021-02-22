using System;
using System.Collections.Generic;

#nullable disable

namespace AzureApp
{
    public partial class Credential
    {
        public int CredentialsId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Consumer User { get; set; }
    }
}
