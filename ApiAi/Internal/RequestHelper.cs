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
            var httpRequestUrl = $"{ConfigModel.BaseUrl}/{action.GetAlternativeString()}?v={ConfigModel.VersionCode}";

            try
            {
                if(method!= HttpMethod.Post)
                {
                    var queryString = string.Empty;
                    if (requestData != null)
                    {
                        var tmp = requestData.GetType().GetProperties();
                        throw new NotImplementedException();
                    }
                }

                var httpRequest = (HttpWebRequest)WebRequest.Create(httpRequestUrl);

                httpRequest.Method = method.Method;
                httpRequest.ContentType = "application/json; charset=utf-8";
                httpRequest.Accept = "application/json";
                httpRequest.Headers.Add("Authorization", "Bearer " + GetToken(action, config));

                if (method == HttpMethod.Post)
                {
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

                return GetResponseObject<TResponse>(httpRequest.GetResponse() as HttpWebResponse);
            }
            catch (ApiAiException ex) { ex.RequestedUrl = $"[{method.ToString()}] {httpRequestUrl}"; throw ex; }
            catch (System.Net.WebException ex)
            {
                try {
                    return GetResponseObject<TResponse>(ex.Response as HttpWebResponse);
                }
                catch (ApiAiException ex2) { ex2.RequestedUrl = $"[{method.ToString()}] {httpRequestUrl}"; throw ex2; }
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
                    TResponse response;

                    //if(typeof(IFixList).GetType().IsAssignableFrom(typeof(TResponse)))
                    if(typeof(TResponse).GetInterface(nameof(IFixList)) != null)
                    {
                        response = (TResponse)Activator.CreateInstance(typeof(TResponse));
                        var listFieldInfo = typeof(TResponse).GetProperty((response as IFixList).ListFixFieldName);

                        var list = JsonConvert.DeserializeObject(result, listFieldInfo.PropertyType);
                        listFieldInfo.SetValue(response, list);

                        response.Status = new Models.StatusJsonModel
                        {
                            Code = 200,
                            ErrorDetails = "Fixed list"
                        };
                    }
                    else
                        response = JsonConvert.DeserializeObject<TResponse>(result);

                    if (response == null)
                        throw new ApiAiException(result, "Unexpected null response");

                    if (response?.Status?.Code >= 400)
                        throw new ApiAiException(result, $"Response code is: {response.Status.Code}, message: {response.Status.ErrorDetails}");

                    return response;
                }
                catch (JsonSerializationException ex) { throw new ApiAiException(result, "Unexpected JSON model", ex); }
                catch (JsonReaderException ex) { throw new ApiAiException(result, "Unexpected JSON model", ex); }
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
