//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi
{
    public enum CodesEnum: short
    {
        /// <summary>
        /// Request was successful (HTTP code 200)
        /// </summary>
        [AmbientValue(200), Description("success")]
        Success,

        /// <summary>
        /// A resource is deprecated and will be removed in the future. (HTTP code 200)
        /// </summary>
        [AmbientValue(200), Description("deprecated")]
        Deprecated,

        /// <summary>
        /// Some required parameter is missing or has the wrong value.
        /// </summary>
        [AmbientValue(400), Description("bad_request")]
        BadRequest,

        /// <summary>
        /// Internal authorization failed. It might mean missing or wrong credentials.
        /// </summary>
        [AmbientValue(401), Description("unauthorized")]
        Unauthorized,

        /// <summary>
        /// URI is not valid or the resource ID does not correspond to an existing resource.
        /// </summary>
        [AmbientValue(404), Description("not_found")]
        NotFound,

        /// <summary>
        /// HTTP method not allowed, such as attempting to use a POST request with an endpoint that only accepts GET requests, or vice versa.
        /// </summary>
        [AmbientValue(405), Description("not_allowed")]
        NotAllowed,

        /// <summary>
        /// Can be returned if uploaded files have some errors.
        /// </summary>
        [AmbientValue(406), Description("not_acceptable")]
        NotAcceptable,

        /// <summary>
        /// 	The request could not be completed due to a conflict with the current state of the resource. This code is only returned in situations where it is expected that the user might be able to resolve the conflict and resubmit the request. For example, deleting an entity that is used in an intent will return this error.
        /// </summary>
        [AmbientValue(409), Description("conflict")]
        Conflict,

        /// <summary>
        /// Too many requests were sent in the short amount of time.
        /// </summary>
        [AmbientValue(429), Description("too_many_requests")]
        TooManyRequests
    }
}
