using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultantEvaluationApp.Application.EvaluationProcess.Commands;
using ConsultantEvaluationApp.Application.EvaluationProcess.Queries.GetAllEvaluationList;
using ConsultantEvaluationApp.Application.EvaluationProcess.Queries.GetEvaluationList;
using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultantEvaluationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<IList<EvaluationProcessVM>> Get(int id)
        {
            return await Mediator.Send(new GetEvaluationListQuery { EvaluationId = id });
        }

        [HttpGet]
        public async Task<IList<EvaluationProcessVM>> GetEvaluations()
        {
            return await Mediator.Send(new GetAllEvaluationListQuery());
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEvaluationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}