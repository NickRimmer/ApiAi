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
    /// <summary>
    /// Alternative value for enums
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class AlternativeValueAttribute: Attribute
    {
        public IEnumerable<object> Values { get; set; }

        public AlternativeValueAttribute(params object[] value)
        {
            Values = value;
        }
    }

    /// <summary>
    /// Helper for extract alternative value of enum
    /// </summary>
    internal static class AlternativeValue
    {
        private static AlternativeValueAttribute GetAttribute(Enum origin)
        {
            var originInfo = origin.GetType().GetMember(origin.ToString()).First();
            return (AlternativeValueAttribute) Attribute.GetCustomAttribute(originInfo, typeof(AlternativeValueAttribute));
        }

        public static string GetAlternativeString(this Enum origin)
        {
            return GetAttribute(origin).Values.FirstOrDefault()?.ToString();
        }

        public static IEnumerable<string> GetAlternativeStrings(this Enum origin)
        {
            return GetAttribute(origin).Values.Select(x=>x.ToString());
        }
    }
}
