//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi.Models
{
    public class QueryResponseMessageModel
    {
        internal QueryResponseMessageModel() { }

        internal QueryResponseMessageModel(Internal.Models.FulfillmentMessageJsonModel data)
        {
            MessageType = (MessageTypesEnum) data.Type;

            Text = data.Speech;

            ImageUrl = data.ImageUrl;

            Title = data.Title;
            SubTitle = data.Subtitle;

            //TODO buttons array

            Replies = data.Replies;

            Payload = data.Payload;
        }

        /// <summary>
        /// Response message type.
        /// </summary>
        public MessageTypesEnum MessageType { get; }

        /// <summary>
        /// Message type field.
        /// Agent's text reply. Line breaks are supported for Facebook Messenger, Kik, Slack, and Telegram one-click integrations.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Image type field.
        /// Public URL to the image file.
        /// </summary>
        public string ImageUrl { get; }

        /// <summary>
        /// Card message title or Quick reply message title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Card subtitle.
        /// </summary>
        public string SubTitle { get; }

        /// <summary>
        /// Quick replies message type.
        /// Array of strings corresponding to quick replies.
        /// </summary>
        public List<string> Replies { get; }

        /// <summary>
        /// Developer defined JSON. It is sent without modifications.
        /// </summary>
        public string Payload { get; }
    }
}
