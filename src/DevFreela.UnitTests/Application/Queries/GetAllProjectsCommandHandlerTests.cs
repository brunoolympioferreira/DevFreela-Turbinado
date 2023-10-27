﻿using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new PaginationResult<Project>
            {
                Data = new List<Project> {
                    new Project("Nome Do Teste 1", "Descricao De Teste 1", 1, 2, 10000),
                    new Project("Nome Do Teste 2", "Descricao De Teste 2", 1, 2, 20000),
                    new Project("Nome Do Teste 3", "Descricao De Teste 3", 1, 2, 30000)
                }
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery { Query = "", Page = 1 };
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act
            var paginationProjectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(paginationProjectViewModelList);
            Assert.NotEmpty(paginationProjectViewModelList.Data);
            Assert.Equal(projects.Data.Count, paginationProjectViewModelList.Data.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result, Times.Once);
        }
    }
}
