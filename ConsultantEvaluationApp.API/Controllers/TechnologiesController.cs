using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultantEvaluationApp.Application.SubAreas.Commands;
using ConsultantEvaluationApp.Application.SubAreas.Commands.CreateSubAreaFeedback;
using ConsultantEvaluationApp.Application.SubAreas.Queries.GetTechSubAreaList;
using ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechnologyList;
using ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechRecommendation;
using ConsultantEvaluationApp.Application.Technologies.Queries.GetTechnologiesList;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultantEvaluationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<TechnologyListVM>> Get()
        {
            return await Mediator.Send(new GetTechnologyListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTechSubArea(int id)
        {
            var vm = await Mediator.Send(new GetTechSubAreaListQuery { TechId = id });

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTechnologyListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("AddTechSubAreas")]
        public async Task<ActionResult<int>> Create(CreateTechSubAreaListCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpPost]
        [Route("AddTechnologyNotes")]
        public async Task<ActionResult<int>> Create(CreateTechRecommendationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("AddSubAreFeedback")]
        public async Task<ActionResult<int>> Create(CreateSubAreaFeedbackCommand command)
        {
            return await Mediator.Send(command);
        }

    }

}