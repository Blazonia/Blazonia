using Android.App;
using Android.Runtime;
using Avalonia.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Android;

[Application]
public class Application : AvaloniaAndroidApplication<App>
{
    protected Application(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
    }
}
