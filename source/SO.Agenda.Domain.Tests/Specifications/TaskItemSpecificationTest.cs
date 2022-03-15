using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Domain.Service.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Domain.Tests.Specifications
{
    [TestClass]
    public class TaskItemSpecificationTest
    {
        public TaskItem TaskItem { get; set; }
        [TestMethod]
        public void TaskItem_Valid_True()
        {
            TaskItem = new TaskItem()
            {
                Id = new Guid(),
                Title = "ENTREVISTA - SORTE ONLINE",
                Description = "ENTREVISTA TÉCNICA COM SORTE ONLINE",
                DateTime = new DateTime(2022, 3, 18),
            };

            var stubRepo = MockRepository.GenerateStub<ITaskItemRepository>();
            stubRepo.Stub(s => s.GetByTitle(TaskItem.Title)).Return(null);

            var cliValidation = new TaskItemMustHaveUniqueTitle(stubRepo);
            Assert.IsTrue(cliValidation.IsSatisfiedBy("ENTREVISTA SO"));
        }
        [TestMethod]
        public void TaskItem_Valid_False()
        {
            TaskItem = new TaskItem()
            {
                Id = new Guid(),
                Title = "ENTREVISTA - SORTE ONLINE",
                Description = "ENTREVISTA TÉCNICA COM SORTE ONLINE",
                DateTime = new DateTime(2022, 3, 18),
            };

            var stubRepo = MockRepository.GenerateStub<ITaskItemRepository>();
            stubRepo.Stub(s => s.GetByTitle(TaskItem.Title)).Return(null);

            var cliValidation = new TaskItemMustHaveUniqueTitle(stubRepo);
            Assert.IsFalse(cliValidation.IsSatisfiedBy("ENTREVISTA - SORTE ONLINE"));
        }
    }
}
