using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetSkillById
{
    public class GetSkillByIdQuery : IRequest<ResultViewModel<SkillViewModel>>
    {
        public GetSkillByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}