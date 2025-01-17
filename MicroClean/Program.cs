#region initialization MediatR & Data
// Add & build services
var services = new ServiceCollection()
    .AddMediatR(o =>
    {
        o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    })
    .AddScoped<UserRepository>()
    .SeedData();
var provider = services.BuildServiceProvider();

await Task.Delay(TimeSpan.FromSeconds(5)); // Wait a bit for the database to be seeded
await provider.GetRequiredService<AppDbContext>().Database.EnsureCreatedAsync();
#endregion

// This like an EndPoint. It's a query to get all users
var query = new GetUsersQuery();
var sender = provider.GetRequiredService<ISender>();
var users = await sender.Send(query);

// Print the users or just return them as API response
users.ToList().ForEach(u => Console.WriteLine(u.Name));