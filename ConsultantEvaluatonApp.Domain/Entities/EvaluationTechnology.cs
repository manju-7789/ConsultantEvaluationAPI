using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluatonApp.Domain.Entities
{
    public class EvaluationTechnology
    {

        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int TechId { get; set; }

        public virtual EvaluationProcess Evaluation { get; set; }
        public virtual TechnologyArea TechnologyArea { get; set; }
    }
}
