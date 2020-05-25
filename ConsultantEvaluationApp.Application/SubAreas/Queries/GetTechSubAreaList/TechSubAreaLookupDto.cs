using ConsultantEvaluationApp.Application.Mappings;
using ConsultantEvaluatonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.SubAreas.Queries.GetTechSubAreaList
{
    public class TechSubAreaLookupDto :IMapFrom<TechSubArea>
    {
        public int SubTechId { get; set; }
        public string Name { get; set; }
        public int TechId { get; set; }
    }
}
