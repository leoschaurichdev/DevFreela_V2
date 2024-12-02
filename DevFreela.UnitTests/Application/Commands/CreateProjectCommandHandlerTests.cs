using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;


namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            var projectRepository = new Mock<IProjectRepository>();

            var insertProjectCommand = new InsertProjectCommand
            {
                Title = "Título de Teste",
                Description = "Uma Descrição Dahora",
                TotalCost = 50000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var insertProjectHandler = new InsertProjectHandler(projectRepository.Object);
            var id = await insertProjectHandler.Handle(insertProjectCommand, new CancellationToken());


            projectRepository.Verify(x => x.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}