//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi.Internal.Models
{
    internal class MetadataJsonModel
    {
        [JsonProperty(PropertyName = "intentId")]
        public string IntentId { get; set; }

        [JsonProperty(PropertyName = "webhookUsed")]
        public string WebhookUsed { get; set; }

        [JsonProperty(PropertyName = "webhookForSlotFillingUsed")]
        public string WebhookForSlotFillingUsed { get; set; }

        [JsonProperty(PropertyName = "webhookResponseTime")]
        public double WebhookResponseTime { get; set; }

        [JsonProperty(PropertyName = "intentName")]
        public string IntentName { get; set; }
    }
}
