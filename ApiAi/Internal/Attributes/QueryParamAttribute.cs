//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi.Internal.Attributes
{
    internal class QueryParamAttribute : Attribute
    {
        public QueryParamAttribute(int order = 0)
        {
            Order = order;
        }

        public int Order { get; }
    }

    internal static class QueryParam
    {
        public static int GetOrder(Type t, string propertyName)
        {
            var originInfo = t.GetMember(propertyName).First();
            var attr = Attribute.GetCustomAttribute(originInfo, typeof(QueryParamAttribute)) as QueryParamAttribute;

            return attr?.Order ?? -1;
        }
    }
}
