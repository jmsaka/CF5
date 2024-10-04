namespace Products.Catalogs.Infrastructure.IoC;

public static class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpsertProductCommandHandler).Assembly));
    }
}
