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
        public string clientToken = "your_agent_token";

        [TestMethod]
        public void QueryTest()
        {
            try
            {
                QueryService.SendRequest(new ConfigModel { AccesTokenClient = clientToken }, "some text");
            }catch(ApiAiException ex)
            {
                // Use debug for check this "ex" value
            }
        }
    }
}
