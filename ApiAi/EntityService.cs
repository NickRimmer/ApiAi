//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Internal.Models;
using ApiAi.Internal.Models.Requests;
using ApiAi.Internal.Models.Responses;
using ApiAi.Models;
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
        public static IEnumerable<EntityResponseModel> GetEntities(ConfigModel config)
        {
            var result = Internal.RequestHelper.Send<EmptyRequestModel, EntityListRespoonseJsonModel>(null, Internal.Enums.ActionsEnum.Entities, HttpMethod.Get, config);
            return result.Entities.Select(x => new EntityResponseModel(x));
        }

        /// <summary>
        /// Retrieves the specified entity.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="id">is the ID of the entity to retrieve. You can specify the entity by its name instead of its ID</param>
        /// <returns></returns>
        public static EntriesCollectionResponseModel GetEntries(ConfigModel config, string id)
        {
            var result = Internal.RequestHelper.Send<EntriesRequestJsonModel, EntriesResponseJsonModel>(new EntriesRequestJsonModel { Id = id }, Internal.Enums.ActionsEnum.Entities, HttpMethod.Get, config);
            return new EntriesCollectionResponseModel(result);
        }

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="name">The name of the entity.</param>
        /// <param name="entries">An array of entry objects, which contain reference values and synonyms (strings array).</param>
        /// <returns>ID of created entity</returns>
        public static string CreateEntity(ConfigModel config, string name, Dictionary<string, string[]> entries)
        {
            var result = Internal.RequestHelper.Send<EntityCreateRequestJsonModel, EntityCreateResponseModel>(new EntityCreateRequestJsonModel { Name = name, Entries = entries.Select(x => new EntryJsonModel { Value = x.Key, Synonyms = x.Value.ToList() }).ToList() }, Internal.Enums.ActionsEnum.Entities, HttpMethod.Post, config);
            return result.Id;
        }
    }
}
