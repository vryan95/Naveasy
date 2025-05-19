using Microsoft.Maui.LifecycleEvents;
using Naveasy.Core;
using Naveasy.Core.Processors;

namespace Naveasy.Extensions;

public static class ContainerProvider
{
    public static IServiceProvider Current { get; set; }
}

public class NavigatorFrameworkAppBuilder
{
    private readonly MauiAppBuilder _mauiAppBuilder;

    internal NavigatorFrameworkAppBuilder(MauiAppBuilder builder)
    {
        _mauiAppBuilder = builder;
        RegisterServices();
        
        _mauiAppBuilder.ConfigureContainer(new DefaultServiceProviderFactory());
    }

    private void RegisterServices()
    {
        _mauiAppBuilder.Services
            .AddSingleton<IPageFactory, PageFactory>()
            .AddSingleton<IApplicationProvider, ApplicationProvider>()
            .AddSingleton<IPageScopeService>(sp => new PageScopeService(sp.CreateScope()))
            .AddSingleton<INavigationService, NavigationService>()
            .AddSingleton<IPageNavigationProcessor, RootPageNavigationProcessor>()
            .AddSingleton<IPageNavigationProcessor, NavigationPageNavigationProcessor>()
            .AddSingleton<IPageNavigationProcessor, FlyoutPageNavigationProcessor>()
            ;
    }
}