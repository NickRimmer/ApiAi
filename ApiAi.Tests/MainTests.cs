//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Exceptions;
using ApiAi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi.Tests
{
    [TestClass]
    public class MainTests
    {
        private const string
            ClientAccessToken = "your_client_access_token",
            DeveloperAccessToken = "your_developer_access_token",
            ExampleEntityId = "your_exists_entity_id";

        [TestMethod]
        public void QueryTest()
        {
            try
            {
                var result = QueryService.SendRequest(new ConfigModel { AccesTokenClient = ClientAccessToken }, "some text");
                Assert.IsFalse(string.IsNullOrEmpty(result.SessionId));

            }catch(ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntitiesListTest()
        {
            try
            {
                var result = EntityService.GetEntities(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken });
                Assert.IsTrue(result.Any()); // fail you haven't any entities in the agent, it's ok (;
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntriesListTest()
        {
            try
            {
                var result = EntityService.GetEntries(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken }, ExampleEntityId);
                Assert.IsTrue(result.Entries.Any());
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntityCreateTest()
        {
            try
            {
                var NewEntityId = EntityService.CreateEntity(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken }, "test_entity_1", new Dictionary<string, string[]> {
                    { "test1", new[]{ "test 1", "test one" } },
                    { "test2", new[]{ "test 2", "test second" } }
                });
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntityUpdateTest()
        {
            try
            {
                EntityService.UpdateEntity(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken }, ExampleEntityId, "test_entity_1", new Dictionary<string, string[]> {
                    { "test1", new[]{ "test 1", "test one" } },
                    { "test2", new[]{ "test 2", "test second" } }
                });
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntityDeleteTest()
        {
            try
            {
                EntityService.DeleteEntity(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken }, ExampleEntityId);
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntriesAddTest()
        {
            try
            {
                EntityService.AddEntries(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken }, ExampleEntityId, new Dictionary<string, string[]> {
                    { "test3", new[]{ "test 3", "test three" } },
                    { "test4", new[]{ "test 4", "test four" } }
                });
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntriesUpdateTest()
        {
            try
            {
                EntityService.UpdateEntries(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken }, ExampleEntityId, new Dictionary<string, string[]> {
                    { "test1", new[]{ "test 1", "test one", "test before second" } },
                });
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EntriesDeleteTest()
        {
            try
            {
                EntityService.DeleteEntries(new ConfigModel { AccesTokenDeveloper = DeveloperAccessToken }, ExampleEntityId, "test1", "test2");
            }
            catch (ApiAiException ex)
            {
                // Use debug to check this "ex" value
                Assert.Fail();
            }
        }
    }
}
