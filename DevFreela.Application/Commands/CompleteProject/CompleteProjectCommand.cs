using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.CompleteProject
{
    public class CompleteProjectCommand : IRequest<ResultViewModel>

    {
        public CompleteProjectCommand(int id)
        {
            Id = Id;
        }
        public int Id { get; set; }

        
    }
}
