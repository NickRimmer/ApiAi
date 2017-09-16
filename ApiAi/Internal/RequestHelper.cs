//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Internal.Enums;
using ApiAi.Internal.Interfaces;
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
        public static TResponse Send<TRequest, TResponse>(TRequest requestData, ActionsEnum action, HttpMethod method, ConfigModel config)
            where TResponse : IResponse
        {
            try
            {
                var httpRequestUrl = $"{ConfigModel.BaseUrl}/{action.GetAlternativeString()}?v={ConfigModel.VersionCode}";
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

                return GetResponseObject<TResponse>(httpRequest.GetResponse() as HttpWebResponse);
            }
            catch (ApiAiException) { throw; }
            catch (System.Net.WebException ex)
            {
                try {
                    return GetResponseObject<TResponse>(ex.Response as HttpWebResponse);
                }
                catch (ApiAiException) { throw; }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception) { throw; }
        }

        #region rainbow dust

        private static TResponse GetResponseObject<TResponse>(HttpWebResponse httpResponse) where TResponse : IResponse
        {
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                try
                {
                    var response = JsonConvert.DeserializeObject<TResponse>(result);

                    if (response == null)
                        throw new ApiAiException(result, "Unexpected null response");

                    if (response?.Status?.Code >= 400)
                        throw new ApiAiException(result, $"Response code is: {response.Status.Code}, message: {response.Status.ErrorDetails}");

                    return response;
                }catch(Newtonsoft.Json.JsonReaderException ex)
                {
                    throw new ApiAiException(result, "Unexpected JSON model", ex);
                }
            }
        }

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
