//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi
{
    public class ApiAiException : Exception
    {
        public string ResponseString { get; set; }

        public ApiAiException(string response, string message) : base(message) { ResponseString = response; }

        public ApiAiException(string response, string message, Exception innerException) : base(message, innerException) { ResponseString = response; }

        //public ApiAiException(string response, Exception innerException) : base(innerException.Message, innerException) { ResponseString = response; }

        //public ApiAiException(Exception innerException) : base(innerException.Message, innerException) { }
    }
}
