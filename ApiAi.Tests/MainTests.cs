//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

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
        public string clientToken = "your_client_token ";

        [TestMethod]
        public void QueryTest()
        {
            try
            {
                var result = QueryService.SendRequest(new ConfigModel { AccesTokenClient = clientToken }, "some text");
                Assert.IsFalse(string.IsNullOrEmpty(result.SessionId));

            }catch(ApiAiException ex)
            {
                // Use debug to check this "ex" value
            }
        }
    }
}
