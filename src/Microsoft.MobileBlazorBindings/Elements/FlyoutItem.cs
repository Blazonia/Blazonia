﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements.Handlers;
using XF = Xamarin.Forms;

namespace Microsoft.MobileBlazorBindings.Elements
{
    public class FlyoutItem : ShellItem
    {
        static FlyoutItem()
        {
            ElementHandlerRegistry.RegisterElementHandler<FlyoutItem>(
                renderer => new FlyoutItemHandler(renderer, new XF.FlyoutItem()));
        }

        public new XF.FlyoutItem NativeControl => ((FlyoutItemHandler)ElementHandler).FlyoutItemControl;
    }
}
