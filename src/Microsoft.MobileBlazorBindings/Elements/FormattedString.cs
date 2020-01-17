﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.MobileBlazorBindings.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings.Elements.Handlers;
using XF = Xamarin.Forms;

namespace Microsoft.MobileBlazorBindings.Elements
{
    public class FormattedString : Element
    {
        static FormattedString()
        {
            ElementHandlerRegistry
                .RegisterElementHandler<FormattedString>(renderer => new FormattedStringHandler(renderer, new XF.FormattedString()));
        }

        [Parameter] public RenderFragment Spans { get; set; }

        public new XF.FormattedString NativeControl => ((FormattedStringHandler)ElementHandler).FormattedStringControl;

        protected override RenderFragment GetChildContent() => Spans;
    }
}
