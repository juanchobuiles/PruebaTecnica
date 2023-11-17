using Core.Entities;
using MediatR;

namespace Core.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
