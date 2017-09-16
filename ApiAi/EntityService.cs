//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Internal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi
{
    /// <summary>
    /// The entities endpoint is used to create, retrieve, update, and delete developer-defined entity objects.
    /// </summary>
    public static class EntityService
    {
        /// <summary>
        /// Retrieves a list of all entities for the agent.
        /// </summary>
        public static IEnumerable<EntityResponseModel> GetList(ConfigModel config)
        {
            var result = Internal.RequestHelper.Send<EmptyRequestModel, EntityListRespoonseJsonModel>(null, Internal.Enums.ActionsEnum.Entities, HttpMethod.Get, config);
            return result.Entities.Select(x => new EntityResponseModel(x));
        }

        public static void GetEntity(ConfigModel config, string id)
        {
            var result = Internal.RequestHelper.Send<EntityRequestJsonModel, EntityResponseJsonModel>(new EntityRequestJsonModel { Id = id }, Internal.Enums.ActionsEnum.Entities, HttpMethod.Get, config);
        }
    }
}
