namespace AsyncAwait.Infrastructure;

public class UserRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    public IEnumerable<User> GetUsers()
    {
        return _context.Users.ToList();
    }
}