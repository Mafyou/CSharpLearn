namespace MicroClean.Infrastructure;

public class UserRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
}