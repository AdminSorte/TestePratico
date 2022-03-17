using Moq;
using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Domain.Service.Specifications;
using System;
using System.Collections.Generic;
using Xunit;

namespace SO.Agenda.Domain.Tests.Specifications
{

    public class TaskItemSpecificationTest
    {
        public TaskItem TaskItem { get; set; }
        [Fact]
        public void TaskItem_Valid_True()
        {
            List<TaskItem> taskItems = new List<TaskItem>();
            taskItems.Add(new TaskItem()
            {
                Id = 2,
                Title = "ENTREVISTA - SORTE ONLINE",
                Description = "ENTREVISTA TÉCNICA COM SORTE ONLINE",
                DateTime = new DateTime(2022, 3, 18),
            });

            var stubRepo = new Mock<ITaskItemRepository>();

            stubRepo.Setup(repo => repo.Get(x => x.Title == "ENTREVISTA - SORTE ONLINE" 
            && x.Id == 2).Result).Returns(taskItems);


            var cliValidation = new TaskItemMustHaveUniqueTitle(stubRepo.Object);
            Assert.True(cliValidation.IsSatisfiedBy("ENTREVISTA SO", 3));
        }
        [Fact]
        public void TaskItem_Valid_False()
        {
            List<TaskItem> taskItems = new List<TaskItem>();
            taskItems.Add(new TaskItem()
            {
                Id = 2,
                Title = "ENTREVISTA - SORTE ONLINE",
                Description = "ENTREVISTA TÉCNICA COM SORTE ONLINE",
                DateTime = new DateTime(2022, 3, 18),
            });

            var stubRepo = new Mock<ITaskItemRepository>();

            stubRepo.Setup(repo => repo.Get(x => x.Title == "ENTREVISTA - SORTE ONLINE"
            && x.Id == 2).Result).Returns(taskItems);


            var cliValidation = new TaskItemMustHaveUniqueTitle(stubRepo.Object);
            Assert.False(cliValidation.IsSatisfiedBy("ENTREVISTA - SORTE ONLINE", 2));
        }
    }
}
