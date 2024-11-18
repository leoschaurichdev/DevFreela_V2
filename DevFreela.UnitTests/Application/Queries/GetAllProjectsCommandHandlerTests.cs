using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome do teste", "Outra descrição", 1, 2, 3000),
                new Project("Nome do teste 2", "Outra descrição 2", 1, 2, 4000),
                new Project("Nome do teste 3", "Outra descrição 3", 1, 2, 5000)
            };

            var projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.GetAllAsync().Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepository);

            // Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList.Data);
            Assert.Equal(projects.Count, projectViewModelList.Data.Count);

            await projectRepository.Received(1).GetAllAsync();
        }
    }
}
