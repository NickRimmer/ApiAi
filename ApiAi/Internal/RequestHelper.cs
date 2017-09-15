//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Internal.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi.Internal
{
    internal static class RequestHelper
    {
        public static void Send(object requestData, ActionsEnum action, HttpMethod method, ConfigModel config)
        {
            try
            {
                var httpRequestUrl = $"{ConfigModel.BaseUrl}/{action}";
                var httpRequest = (HttpWebRequest)WebRequest.Create(httpRequestUrl);

                httpRequest.Method = method.Method;
                httpRequest.ContentType = "application/json; charset=utf-8";
                httpRequest.Accept = "application/json";
                httpRequest.Headers.Add("Authorization", "Bearer " + GetToken(action, config));

                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                var jsonRequest = JsonConvert.SerializeObject(requestData, Formatting.None, jsonSettings);

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                    streamWriter.Close();
                }
            }
        }

        #region rainbow dust

        private static string GetToken(ActionsEnum action, ConfigModel config)
        {
            var result = string.Empty;

            switch (action)
            {
                case ActionsEnum.Entities:
                    result = config.AccesTokenDeveloper;
                    break;

                case ActionsEnum.Query:
                    result = config.AccesTokenClient;
                    break;
            }

            if (string.IsNullOrWhiteSpace(result))
                throw new OperationCanceledException("Requred token is not specifed");

            return result;
        }

        #endregion
    }
}
