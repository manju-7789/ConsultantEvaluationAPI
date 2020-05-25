using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluatonApp.Domain.Entities
{
    public class SubAreaFeedback
    {
        public int Id { get; set; }
        public string FeedbackNotes { get; set; }
        public int EvaluatorId { get; set; }
        public int SubTechId { get; set; }

        public virtual Evaluator Evaluator { get; set; }
        public virtual TechSubArea SubTech { get; set; }
    }
}
