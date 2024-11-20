using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.UsersQueries.GetAllUsers
{
    public class GetAllUserQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {

    }
}