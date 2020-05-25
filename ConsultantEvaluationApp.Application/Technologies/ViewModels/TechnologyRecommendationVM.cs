using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using ConsultantEvaluationApp.Application.Technologies.Queries.GetTechnologiesList;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.Technologies.ViewModels
{
   public class TechnologyRecommendationVM
    {
        public int Id { get; set; }
        public string RecommendationNotes { get; set; }
        public int EvaluatorId { get; set; }
        public int TechId { get; set; }

    }
}
