// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.Extensions.Logging;
using AvaloniaAppBuilder = global::Avalonia.AppBuilder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Blazonia.Navigation;
using System.ComponentModel;

namespace Blazonia;

public static class AvaloniaAppBuilderExtensions
{
    public static AvaloniaAppBuilder UseAvaloniaBlazorBindings(this AvaloniaAppBuilder builder, Action<IServiceCollection> configureServices)
    {
        ArgumentNullException.ThrowIfNull(builder);

        // Use factories for performance.
        builder.AfterSetup(builder =>
        {
            IServiceProvider serviceProvider = null;

            var services = new ServiceCollection();

            configureServices?.Invoke(services);

            services.TryAddSingleton<IServiceProvider>(svcs => svcs.GetRequiredService<AvaloniaBlazorBindingsServiceProvider>());

            services.TryAddSingleton(new AvaloniaBlazorBindingsServiceProvider(() => serviceProvider));

            services.TryAddSingleton(svcs => new AvaloniaBlazorBindingsRenderer(svcs.GetRequiredService<AvaloniaBlazorBindingsServiceProvider>(), svcs.GetRequiredService<ILoggerFactory>()));

            services.TryAddSingleton<INavigation>(svcs => new BlazorNavigation(svcs.GetRequiredService<AvaloniaBlazorBindingsServiceProvider>()));

            services.AddLogging();

            serviceProvider = services.BuildServiceProvider();

            builder.With(serviceProvider);

            /*
            if (builder.Instance is IAvaloniaBlazorApplication blazorApplication)
            {
                blazorApplication.Initialize(serviceProvider);
            }
            */

        });

        return builder;
    }
}
