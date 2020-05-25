using ConsultantEvaluationApp.Application.Mappings;
using ConsultantEvaluatonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.Technologies.Queries.GetTechnologiesList
{
    public class TechnologyLookupDto : IMapFrom<TechnologyArea>
    {
        public int TechId { get; set; }
        public string Name { get; set; }
    }
}
