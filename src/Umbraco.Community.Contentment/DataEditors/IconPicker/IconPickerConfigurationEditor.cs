﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Core.IO;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Community.Contentment.DataEditors
{
    public class IconPickerConfigurationEditor : ConfigurationEditor
    {
        public const string Size = "size";

        public IconPickerConfigurationEditor()
            : base()
        {
            Fields.Add(new DefaultIconConfigurationField(string.Empty, SizeConfigurationField.Large));
            Fields.Add(new SizeConfigurationField());
            Fields.AddHideLabel();
        }

        internal class SizeConfigurationField : ConfigurationField
        {
            public const string Small = "small";
            public const string Large = "large";

            public SizeConfigurationField(string defaultSize = Large)
                : base()
            {
                var items = new[]
                {
                    new { name = nameof(Small), value = Small },
                    new { name = nameof(Large), value = Large }
                };

                Key = Size;
                Name = nameof(Size);
                Description = "Select the size of the icon picker. By default this is set to 'large'.<br><br>If 'small' is selected, the description and delete button will not be visible.";
                View = IOHelper.ResolveUrl(RadioButtonListDataEditor.DataEditorViewPath);
                Config = new Dictionary<string, object>
                {
                    { OrientationConfigurationField.Orientation, OrientationConfigurationField.Vertical },
                    { RadioButtonListConfigurationEditor.Items, items },
                    { RadioButtonListConfigurationEditor.DefaultValue, defaultSize }
                };
            }
        }
    }
}