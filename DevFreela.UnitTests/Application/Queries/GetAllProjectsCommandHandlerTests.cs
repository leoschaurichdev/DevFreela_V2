using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]

        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            //Arrange
            var projects = new List<Project>
            {
                new Project("Nome de Teste 1", "Descrição de Teste 1", 2, 1, 23000),
                new Project("Nome de Teste 2", "Descrição de Teste 2", 2, 1, 24000),
                new Project("Nome de Teste 3", "Descrição de Teste 3", 2, 1, 25000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(x => x.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectsHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act

            var projectViewModelList = await getAllProjectsHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList.Data);
            Assert.Equal(projects.Count, projectViewModelList.Data.Count);

            projectRepositoryMock.Verify(x => x.GetAllAsync().Result, Times.Once());
        }
    }
}