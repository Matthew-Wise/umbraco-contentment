﻿/* Copyright © 2020 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.PropertyEditors.ValueConverters;
using Umbraco.Web.Templates;

namespace Umbraco.Community.Contentment.DataEditors
{
    public sealed class TextInputValueConverter : TextStringValueConverter
    {
        public TextInputValueConverter(HtmlLocalLinkParser linkParser, HtmlUrlParser urlParser)
            : base(linkParser, urlParser)
        { }

        public override bool IsConverter(IPublishedPropertyType propertyType) => propertyType.EditorAlias.InvariantEquals(TextInputDataEditor.DataEditorAlias);
    }
}
