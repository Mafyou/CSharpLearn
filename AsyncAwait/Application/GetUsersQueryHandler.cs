namespace AsyncAwait.Application;

public class GetUsersQueryHandler(UserRepository Repo) : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    public Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Repo.GetUsers());
    }
}