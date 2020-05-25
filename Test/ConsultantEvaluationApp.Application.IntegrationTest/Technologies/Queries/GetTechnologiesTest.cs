using ConsultantEvaluationApp.Application.Technologies.Queries.GetTechnologiesList;
using ConsultantEvaluatonApp.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.IntegrationTest.Technologies.Queries
{
    using static Testing;
    public class GetTechnologiesTest
    {

        [Test]
        public async Task ShouldGetAllListsAndItems()
        {

            await AddAsync(new TechnologyArea
            {
                Name = "DotNet",

            });


            var query = new GetTechnologyListQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Technologies.First().Name.Should().NotBeNull();
        }
    }
}
