//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Internal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi
{
    public class EntityResponseModel
    {
        internal EntityResponseModel(EntityJsonModel data)
        {
            Id = data.Id;
            Name = data.Name;
            Count = data.Count;
            Preview = data.Preview;
        }

        /// <summary>
        /// ID of the entity.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Name of the entity.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The total number of synonyms in the entity.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// A string that contains summary information about the entity.
        /// </summary>
        public string Preview { get; }
    }
}
