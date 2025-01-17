namespace MicroClean.Application;

public record GetUsersQuery : IRequest<IEnumerable<User>>;