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

namespace ApiAi.Internal.Models.Requests
{
    internal class QueryRequestJsonModel
    {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "event")]
        public EventJsonModel Event { get; set; }

        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        [JsonProperty(PropertyName = "contexts")]
        public ContextJsonModel Contexts { get; set; }

        [JsonProperty(PropertyName = "resetContexts")]
        public bool ResetContexts { get; set; }

        [JsonProperty(PropertyName = "entities")]
        public EntityJsonModel Entities { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "location")]
        public LocationJsonModel Location { get; set; }

        [JsonProperty(PropertyName = "originalRequest")]
        public OriginalRequestJsonModel OriginalRequest { get; set; }
    }
}
