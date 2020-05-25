using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluatonApp.Domain.Entities
{
    public class TechAreaRecommendation
    {
        public int Id { get; set; }
        public string RecommendationNotes { get; set; }
        public int EvaluatorId { get; set; }
        public int TechId { get; set; }

        public virtual Evaluator Evaluator { get; set; }
        public virtual TechnologyArea Tech { get; set; }
    }
}
