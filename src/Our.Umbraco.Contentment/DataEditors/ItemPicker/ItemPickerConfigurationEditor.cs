﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Core.IO;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.Contentment.DataEditors
{
    public class ItemPickerConfigurationEditor : ConfigurationEditor
    {
        public const string AllowDuplicates = "allowDuplicates";
        public const string DisableSorting = Constants.Conventions.ConfigurationEditors.DisableSorting;
        public const string HideLabel = Constants.Conventions.ConfigurationEditors.HideLabel;
        public const string Items = Constants.Conventions.ConfigurationEditors.Items;

        public ItemPickerConfigurationEditor()
            : base()
        {
            var listFields = new[]
            {
                 new ConfigurationField
                {
                    Key = "icon",
                    Name = "Icon",
                    View = IOHelper.ResolveUrl(IconPickerDataEditor.DataEditorViewPath)
                },
                new ConfigurationField
                {
                    Key = "name",
                    Name = "Name",
                    View = "textbox"
                },
                new ConfigurationField
                {
                    Key = "value",
                    Name = "Value",
                    View = "textbox"
                },
            };

            Fields.Add(
                Items,
                nameof(Items),
                "Configure the items for the item picker.",
                IOHelper.ResolveUrl(DataTableDataEditor.DataEditorViewPath),
                new Dictionary<string, object>()
                {
                    { DataTableConfigurationEditor.FieldItems, listFields },
                    { DataTableConfigurationEditor.MaxItems, 0 },
                    { DataTableConfigurationEditor.DisableSorting, Constants.Values.False },
                    { DataTableConfigurationEditor.RestrictWidth, Constants.Values.True },
                    { DataTableConfigurationEditor.UsePrevalueEditors, Constants.Values.False }
                });

            Fields.AddMaxItems();
            Fields.Add(new AllowDuplicatesConfigurationField());
            Fields.AddDisableSorting();
            Fields.AddHideLabel();
        }

        internal class AllowDuplicatesConfigurationField : ConfigurationField
        {
            public AllowDuplicatesConfigurationField()
                : base()
            {
                Key = AllowDuplicates;
                Name = "Allow duplicates?";
                Description = "Select to allow the editor to select duplicate items.";
                View = "boolean";
            }
        }
    }
}