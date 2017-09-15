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
    /// <summary>
    /// API.AI supported languages
    /// </summary>
    public enum LanguagesEnum
    {
        /// <summary>
        /// Brazilian Portuguese
        /// </summary>
        [AmbientValue("pt-BR")]
        Brazilian,

        /// <summary>
        /// Chinese (Cantonese)
        /// </summary>
        [AmbientValue("zh-HK")]
        ChineseCantonese,

        /// <summary>
        /// Chinese (Simplified)
        /// </summary>
        [AmbientValue("zh-CN")]
        ChineseSimplified,

        /// <summary>
        /// Chinese (Traditional)
        /// </summary>
        [AmbientValue("zh-TW")]
        ChineseTraditional,

        /// <summary>
        /// English
        /// </summary>
        [AmbientValue("en")]
        English,

        /// <summary>
        /// Dutch
        /// </summary>
        [AmbientValue("nl")]
        Dutch,

        /// <summary>
        /// French
        /// </summary>
        [AmbientValue("fr")]
        French,

        /// <summary>
        /// German
        /// </summary>
        [AmbientValue("de")]
        German,

        /// <summary>
        /// Italian
        /// </summary>
        [AmbientValue("it")]
        Italian,

        /// <summary>
        /// Japanese
        /// </summary>
        [AmbientValue("ja")]
        Japanese,

        /// <summary>
        /// Korean
        /// </summary>
        [AmbientValue("ko")]
        Korean,

        /// <summary>
        /// Portuguese
        /// </summary>
        [AmbientValue("pt")]
        Portuguese,

        /// <summary>
        /// Russian
        /// </summary>
        [AmbientValue("ru")]
        Russian,

        /// <sumSpanishmary>
        /// 
        /// </summary>
        [AmbientValue("es")]
        Spanish,

        /// <summary>
        /// Ukrainian
        /// </summary>
        [AmbientValue("uk")]
        Ukrainian
    }
}
