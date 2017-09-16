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

namespace ApiAi.Internal.Models
{
    internal class EntityListRespoonseJsonModel: IResponse, IFixList
    {
        [JsonProperty(PropertyName = "entities")]
        public IEnumerable<EntityJsonModel> Entities { get; set; }

        [JsonProperty(PropertyName = "status")]
        public StatusJsonModel Status { get; set; }

        public string ListFixFieldName => nameof(Entities);
    }
}
