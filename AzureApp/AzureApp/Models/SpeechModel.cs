using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace AzureApp.Models
{
    public class SpeechModel
    {
        public string Content { get; set; }

        public string SubscriptionKey { get; set; } = "< Subscription Key >";

        [DisplayName("Language Selection :")]
        public string LanguageCode { get; set; } = "NA";

        public List<SelectListItem> LanguagePreference { get; set; } = new List<SelectListItem>
        {
        new SelectListItem { Value = "NA", Text = "-Select-" },
        new SelectListItem { Value = "en-US", Text = "English (United States)"  },
        new SelectListItem { Value = "en-IN", Text = "English (India)"  },
        new SelectListItem { Value = "ta-IN", Text = "Tamil (India)"  },
        new SelectListItem { Value = "hi-IN", Text = "Hindi (India)"  },
        new SelectListItem { Value = "te-IN", Text = "Telugu (India)"  }
        };
    }
}
