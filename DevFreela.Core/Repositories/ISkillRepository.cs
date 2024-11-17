using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<Skill?> GetDetailsById(int id);
        Task<int> Add(Skill user);
    }
}