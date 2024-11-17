using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {

    }
}