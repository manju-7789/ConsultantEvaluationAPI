using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.Technologies.Queries.GetTechnologiesList
{
    public class TechnologyListVM
    {
        public IList<TechnologyLookupDto> Technologies { get; set; }
    }
}
