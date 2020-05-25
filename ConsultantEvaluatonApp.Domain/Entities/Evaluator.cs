using ConsultantEvaluatonApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluatonApp.Domain.Entities
{
   public class Evaluator : AuditableEntity
    {
        public Evaluator()
        {
            SubAreaFeedback = new HashSet<SubAreaFeedback>();
            TechAreaRecommendation = new HashSet<TechAreaRecommendation>();

        }

        public int EvaluatorId { get; set; }
        public string EvaluatorEmail { get; set; }
        public bool IsSubmitted { get; set; }
        public int EvaluationId { get; set; }

        public virtual EvaluationProcess Evaluation { get; set; }
        public virtual ICollection<SubAreaFeedback> SubAreaFeedback { get; set; }
        public virtual ICollection<TechAreaRecommendation> TechAreaRecommendation { get; set; }
    }
}
