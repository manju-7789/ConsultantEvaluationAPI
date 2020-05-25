using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluatonApp.Domain.Entities
{
    public class TechnologyArea
    {
        public TechnologyArea()
        {
            EvaluationTechnology = new HashSet<EvaluationTechnology>();
            TechAreaRecommendation = new HashSet<TechAreaRecommendation>();
            TechSubArea = new HashSet<TechSubArea>();
        }

        public int TechId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EvaluationTechnology> EvaluationTechnology { get; set; }
        public virtual ICollection<TechAreaRecommendation> TechAreaRecommendation { get; set; }
        public virtual ICollection<TechSubArea> TechSubArea { get; set; }

    }
}
