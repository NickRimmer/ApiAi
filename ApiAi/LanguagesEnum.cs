//  
// Copyright (c) 2017 Nick Rimmer. All rights reserved.  
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  
//

using ApiAi.Internal.Attributes;
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
        [AlternativeValue("pt-BR")]
        Brazilian,

        /// <summary>
        /// Chinese (Cantonese)
        /// </summary>
        [AlternativeValue("zh-HK")]
        ChineseCantonese,

        /// <summary>
        /// Chinese (Simplified)
        /// </summary>
        [AlternativeValue("zh-CN")]
        ChineseSimplified,

        /// <summary>
        /// Chinese (Traditional)
        /// </summary>
        [AlternativeValue("zh-TW")]
        ChineseTraditional,

        /// <summary>
        /// English
        /// </summary>
        [AlternativeValue("en")]
        English,

        /// <summary>
        /// Dutch
        /// </summary>
        [AlternativeValue("nl")]
        Dutch,

        /// <summary>
        /// French
        /// </summary>
        [AlternativeValue("fr")]
        French,

        /// <summary>
        /// German
        /// </summary>
        [AlternativeValue("de")]
        German,

        /// <summary>
        /// Italian
        /// </summary>
        [AlternativeValue("it")]
        Italian,

        /// <summary>
        /// Japanese
        /// </summary>
        [AlternativeValue("ja")]
        Japanese,

        /// <summary>
        /// Korean
        /// </summary>
        [AlternativeValue("ko")]
        Korean,

        /// <summary>
        /// Portuguese
        /// </summary>
        [AlternativeValue("pt")]
        Portuguese,

        /// <summary>
        /// Russian
        /// </summary>
        [AlternativeValue("ru")]
        Russian,

        /// <sumSpanishmary>
        /// 
        /// </summary>
        [AlternativeValue("es")]
        Spanish,

        /// <summary>
        /// Ukrainian
        /// </summary>
        [AlternativeValue("uk")]
        Ukrainian
    }
}
