using ConsultantEvaluationApp.Application.Common.Exceptions;
using ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechnologyList;
using ConsultantEvaluatonApp.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.IntegrationTest.Technologies.Commands
{
    using static Testing;
    public class CreateTechnologyListTest
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateTechnologyListCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldRequireUniqueTitle()
        {
            await SendAsync(new CreateTechnologyListCommand
            {
                Name = "Dot Net"
            });

            var command = new CreateTechnologyListCommand
            {
                Name = "Dot Net"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoList()
        {

            var command = new CreateTechnologyListCommand
            {
                Name = "FrontEndFramework"
            };

            var id = await SendAsync(command);

            var list = await FindAsync<TechnologyArea>(id);

            list.Should().NotBeNull();
            list.Name.Should().Be(command.Name);
        }
    }
}
