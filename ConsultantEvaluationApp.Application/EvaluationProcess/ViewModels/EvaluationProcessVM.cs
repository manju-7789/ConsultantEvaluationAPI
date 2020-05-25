using ConsultantEvaluationApp.Application.Mappings;
using ConsultantEvaluatonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels
{
    public class EvaluationProcessVM : IMapFrom<ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess>
    {
        public int EvaluationId { get; set; }
        public string Title { get; set; }

        public string Owner { get; set; }

        public string Consultant { get; set; }

        public string Status { get; set; }

        public ICollection<EvaluatorVM> Evaluators { get; set; }

        public ICollection<EvaluationTechnologyVM> EvaluationTechnologies { get; set; }
    }
}
