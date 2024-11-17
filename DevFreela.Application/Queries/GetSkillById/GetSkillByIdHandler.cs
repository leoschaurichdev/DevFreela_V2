using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.SkillQueries.GetSkillById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdQuery, ResultViewModel<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _context;
        private readonly ISkillRepository _repository;
        public GetSkillByIdHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<SkillViewModel>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetDetailsById(request.Id);

            if (skills == null)
            {
                return ResultViewModel<SkillViewModel>.Error("Habilidade não encontrada!");
            }

            var model = SkillViewModel.FromEntity(skills);

            return ResultViewModel<SkillViewModel>.Success(model);
        }
    }
}