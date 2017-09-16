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
    internal class StatusJsonModel
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "errorType")]
        public string ErrorType { get; set; }

        [JsonProperty(PropertyName = "errorId")]
        public string ErrorId { get; set; }

        [JsonProperty(PropertyName = "errorDetails")]
        public string ErrorDetails { get; set; }
    }
}
