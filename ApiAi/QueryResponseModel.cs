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
    public class QueryResponseModel
    {
        internal QueryResponseModel(Internal.Models.QueryResponseJsonModel data) {
            Id = data.Id;
            Timestamp = DateTime.Parse(data.Timestamp);
            Source = data.Result.Source;
            Action = data.Result.Action;
            IsIncomplete = data.Result.ActionIncomplete;
            Parameters = data.Result.Parameters;
            Contexts = data.Result.Contexts.Select(x => new QueryResponseContextModel(x));

            if (data.Result.Fulfillment?.Messages != null)
                Messages = data.Result.Fulfillment?.Messages.Select(x => new QueryResponseMessageModel(x)).ToList();

            if(!string.IsNullOrEmpty(data.Result.Fulfillment?.Speech))
            {
                if (Messages == null) Messages = new List<QueryResponseMessageModel>();
                ((List<QueryResponseMessageModel>)Messages).Add(new QueryResponseMessageModel() { Text = data.Result.Fulfillment?.Speech });
            }

            Score = data.Result.Score;
            IntentId = data.Result.Metadata.IntentId;
            WebhookUsed = data.Result.Metadata.WebhookUsed;
            WebhookForSlotFillingUsed = data.Result.Metadata.WebhookForSlotFillingUsed;
            WebhookResponseTime = data.Result.Metadata.WebhookResponseTime;
            IntentName = data.Result.Metadata.IntentName;

            SessionId = data.SessionId;
        }

        /// <summary>
        /// Unique identifier of the result.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Date and time of the request in UTC timezone.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Source of the answer. Could be "agent" if the response was retrieved from the agent.
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// An action to take.
        /// Example: turn on
        /// </summary>
        public string Action { get; }

        /// <summary>
        /// True if the triggered intent has required parameters and not all the required parameter values have been collected.
        /// False if all required parameter values have been collected or if the triggered intent doesn't containt any required parameters.
        /// </summary>
        public bool IsIncomplete { get; }

        /// <summary>
        /// Dictionary consisting of "parameter_name":"parameter_value" pairs. 
        /// Example: {"device": "computer"}
        /// </summary>
        public Dictionary<string, string> Parameters { get; }

        /// <summary>
        /// Array of context objects with the fields "Name", "Parameters", "Lifespan".
        /// </summary>
        public IEnumerable<QueryResponseContextModel> Contexts { get; }

        /// <summary>
        /// Text to be pronounced to the user / shown on the screen.
        /// </summary>
        //public string Speech { get; }

        /// <summary>
        /// Array of messages
        /// </summary>
        public IEnumerable<QueryResponseMessageModel> Messages { get; }

        /// <summary>
        /// Matching score for the intent. Number between 0 and 1.
        /// </summary>
        public float Score { get; }

        /// <summary>
        /// ID of the intent that produced this result.
        /// </summary>
        public string IntentId { get; }

        /// <summary>
        /// Indicates wheather webhook functionaly is enabled in the triggered intent.
        /// </summary>
        public string WebhookUsed { get; }

        /// <summary>
        /// Indicates wheather in the triggered intent webhook functionaly is enabled for required parameters.
        /// </summary>
        public string WebhookForSlotFillingUsed { get; }

        /// <summary>
        /// Webhook response time in milliseconds.
        /// </summary>
        public double WebhookResponseTime { get; }

        /// <summary>
        /// Name of the intent that produced this result.
        /// </summary>
        public string IntentName { get; }

        /// <summary>
        /// Just a session ID (=
        /// </summary>
        public string SessionId { get; }
    }
}
