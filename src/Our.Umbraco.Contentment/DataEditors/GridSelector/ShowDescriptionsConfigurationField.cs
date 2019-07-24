﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.Contentment.DataEditors
{
    internal class ShowDescriptionsConfigurationField : ConfigurationField
    {
        public const string ShowDescriptions = "showDescriptions";

        public ShowDescriptionsConfigurationField()
            : base()
        {
            Key = ShowDescriptions;
            Name = "Show descriptions?";
            Description = "Enable to display the item's description on the card, (if available).";
            View = "views/propertyeditors/boolean/boolean.html";
            Config = new Dictionary<string, object>
            {
                { "default", Constants.Values.True }
            };
        }
    }
}
