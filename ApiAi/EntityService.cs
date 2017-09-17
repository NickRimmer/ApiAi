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
        /// <param name="config">Agent connection configuration</param>
        /// </summary>
        public static IEnumerable<EntityResponseModel> GetEntities(ConfigModel config)
        {
            var result = Internal.RequestHelper.Send<EmptyModel, EntityListRespoonseJsonModel>(null, Internal.Enums.ActionsEnum.Entities, HttpMethod.Get, config);
            return result.Entities.Select(x => new EntityResponseModel(x));
        }

        /// <summary>
        /// Retrieves the specified entity.
        /// </summary>
        /// <param name="config">Agent connection configuration</param>
        /// <param name="entityId">Is the ID of the entity to retrieve. You can specify the entity by its name instead of its ID</param>
        /// <returns></returns>
        public static EntriesCollectionResponseModel GetEntries(ConfigModel config, string entityId)
        {
            var result = Internal.RequestHelper.Send<EmptyModel, EntriesResponseJsonModel>(null, Internal.Enums.ActionsEnum.Entities, HttpMethod.Get, config, new[] { entityId });
            return new EntriesCollectionResponseModel(result);
        }

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="config">Agent connection configuration</param>
        /// <param name="name">The name of the entity.</param>
        /// <param name="entries">An array of entry objects, which contain reference values and synonyms (strings array).</param>
        /// <returns>ID of created entity</returns>
        public static string CreateEntity(ConfigModel config, string name, Dictionary<string, string[]> entries)
        {
            var result = Internal.RequestHelper.Send<EntityCreateRequestJsonModel, EntityCreateResponseModel>(new EntityCreateRequestJsonModel { Name = name, Entries = entries.Select(x => new EntryJsonModel { Value = x.Key, Synonyms = x.Value.ToList() }).ToList() }, Internal.Enums.ActionsEnum.Entities, HttpMethod.Post, config);
            return result.Id;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="config">Agent connection configuration</param>
        /// <param name="entityId">Is the ID of the entity to update. You can specify the entity by its name instead of its ID.</param>
        /// <param name="name">The name of the entity.</param>
        /// <param name="entries">An array of entry objects, which contain reference values and synonyms (strings array).</param>
        public static void UpdateEntity(ConfigModel config, string entityId, string name, Dictionary<string, string[]> entries)
        {
            Internal.RequestHelper.Send<EntityUpdateRequestJsonModel, EmptyModel>(new EntityUpdateRequestJsonModel { Id = entityId, Name = name, Entries = entries.Select(x => new EntryJsonModel { Value = x.Key, Synonyms = x.Value.ToList() }).ToList() }, Internal.Enums.ActionsEnum.Entities, HttpMethod.Put, config);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="config">Agent connection configuration</param>
        /// <param name="entityId">Is the ID of the entity to delete. You can specify the entity by its name instead of its ID.</param>
        public static void DeleteEntity(ConfigModel config, string entityId)
        {
            Internal.RequestHelper.Send<EmptyModel, EmptyModel>(null, Internal.Enums.ActionsEnum.Entities, HttpMethod.Delete, config, new[] { entityId });
        }

        /// <summary>
        /// Adds entries to the specified entity.
        /// </summary>
        /// <param name="config">Agent connection configuration</param>
        /// <param name="entityId">Is the ID of the entity to which the entries will be added. You can specify the entity by its name instead of its ID.</param>
        /// <param name="entries">An array of entry objects, which contain reference values and synonyms (strings array).</param>
        public static void AddEntries(ConfigModel config, string entityId, Dictionary<string, string[]> entries)
        {
            Internal.RequestHelper.Send<EntryJsonModel[], EmptyModel>(entries.Select(x => new EntryJsonModel { Value = x.Key, Synonyms = x.Value.ToList() }).ToArray(), Internal.Enums.ActionsEnum.Entities, HttpMethod.Post, config, new[] {  entityId, "entries" });
        }

        /// <summary>
        /// Updates specified entity entries.
        /// </summary>
        /// <param name="config">Agent connection configuration</param>
        /// <param name="entityId">Is the ID of the entity to which the entries will be added. You can specify the entity by its name instead of its ID.</param>
        /// <param name="entries"></param>
        public static void UpdateEntries(ConfigModel config, string entityId, Dictionary<string, string[]> entries)
        {
            Internal.RequestHelper.Send<EntryJsonModel[], EmptyModel>(entries.Select(x => new EntryJsonModel { Value = x.Key, Synonyms = x.Value.ToList() }).ToArray(), Internal.Enums.ActionsEnum.Entities, HttpMethod.Put, config, new[] { entityId, "entries" });
        }

        /// <summary>
        /// Deletes entity entries.
        /// </summary>
        /// <param name="config">Agent connection configuration</param>
        /// <param name="entityId">Is the ID of the entity to which the entries will be added. You can specify the entity by its name instead of its ID.</param>
        /// <param name="entries">An array of strings corresponding to the reference values of entity entries to be deleted.</param>
        public static void DeleteEntries(ConfigModel config, string entityId, params string[] entries)
        {
            Internal.RequestHelper.Send<string[], EmptyModel>(entries, Internal.Enums.ActionsEnum.Entities, HttpMethod.Delete, config, new[] { entityId, "entries" });
        }
    }
}
