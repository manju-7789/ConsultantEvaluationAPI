using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluatonApp.Domain.Entities
{
    public class TechSubArea
    {
        public TechSubArea()
        {
            SubAreaFeedback = new HashSet<SubAreaFeedback>();
        }

        public int SubTechId { get; set; }
        public string Name { get; set; }
        public int TechId { get; set; }

        public virtual TechnologyArea Tech { get; set; }
        public virtual ICollection<SubAreaFeedback> SubAreaFeedback { get; set; }
    }
}
