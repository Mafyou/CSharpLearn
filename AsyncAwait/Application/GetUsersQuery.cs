namespace AsyncAwait.Application;

public record GetUsersQuery : IRequest<IEnumerable<User>>;