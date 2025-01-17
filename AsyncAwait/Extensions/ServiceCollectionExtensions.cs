namespace AsyncAwait.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SeedData(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseAsyncSeeding(async (context, store, cl) =>
            {
                var m = new User { Id = 1, Name = "Mafyou" };
                var s = new User { Id = 2, Name = "Salim" };
                var db = context.GetService<AppDbContext>();
                await db.Users.AddRangeAsync([m, s], cl);
                await db.SaveChangesAsync(cl);
            });
        });
        return services;
    }
}