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
    internal class EntryJsonModel
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "synonyms")]
        public List<string> Synonyms { get; set; }
    }
}
