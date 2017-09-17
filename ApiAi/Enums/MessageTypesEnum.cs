//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAi.Enums
{
    public enum MessageTypesEnum: byte
    {
        /// <summary>
        /// Text responses are available in all platforms. Your agent can send up to 10 sequential text messages in response to a user input (assuming no other message types are defined in the intent).
        /// </summary>
        Text = 0,

        /// <summary>
        /// The image message type lets your agent send images in integrations for Facebook Messenger, Kik, LINE, Skype, Slack, Telegram, and Viber.
        /// </summary>
        Image = 3,

        /// <summary>
        /// Cards consist of an image, a card title, a card subtitle, and interactive buttons (for sending user queries or opening links)
        /// </summary>
        Card = 1,

        /// <summary>
        /// Quick replies are displayed in messengers as clickable buttons with pre-defined user responses
        /// </summary>
        QuickReply = 2,

        /// You can send a custom payload to self-developed integrations. It won’t be processed by API.AI, so you'll need to handle it in your own business logic.
        CustomPayload = 4
    }
}
