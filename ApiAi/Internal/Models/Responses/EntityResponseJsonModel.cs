//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Internal.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi.Internal.Models.Responses
{
    internal class EntriesResponseJsonModel : IResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "entries")]
        public List<EntryJsonModel> Entries { get; set; }

        [JsonProperty(PropertyName = "isEnum")]
        public bool IsEnum { get; set; }

        [JsonProperty(PropertyName = "automatedExpansion")]
        public bool AutomatedExpansion { get; set; }

        [JsonProperty(PropertyName = "status")]
        private StatusJsonModel _status { get; set; }

        [JsonIgnore]
        public StatusJsonModel Status {
            get => (_status ?? new StatusJsonModel { Code = 200, ErrorDetails = "No status response" });
            set => _status = value;
        }
    }
}
