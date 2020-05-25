using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.SubAreas.Queries.GetTechSubAreaList
{
    public class TechSubAreaListVM
    {
        public IList<TechSubAreaLookupDto> TechSubAreas { get; set; }
    }
}
