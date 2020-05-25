using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.Commands
{
    public class CreateEvaluationCommand : IRequest<int>
    {
        public CreateEvaluationCommand()
        {
            EvaluationTechnologies = new HashSet<EvaluationTechnologyVM>();
            Evaluators = new HashSet<EvaluatorVM>();
        }

        public int EvaluationId { get; set; }
        public string Title { get; set; }

        public string Owner { get; set; }

        public string Consultant { get; set; }

        public string Status { get; set; }

        public ICollection<EvaluatorVM> Evaluators { get; set; }

        public ICollection<EvaluationTechnologyVM> EvaluationTechnologies { get; set; }
    }
}
