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

namespace ApiAi.Internal.Models.Responses
{
    internal class QueryResponseResultJsonModel
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "actionIncomplete")]
        public bool ActionIncomplete { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Dictionary<string,string> Parameters { get; set; }

        [JsonProperty(PropertyName = "contexts")]
        public List<ContextJsonModel> Contexts { get; set; }

        [JsonProperty(PropertyName = "fulfillment")]
        public FulfillmentJsonModel Fulfillment { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float Score { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public MetadataJsonModel Metadata { get; set; }

        [JsonProperty(PropertyName = "speech")]
        public string Speech { get; set; }
    }
}
