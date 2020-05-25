using AutoMapper;
using ConsultantEvaluationApp.Application.Common.Exceptions;
using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.Queries.GetAllEvaluationList
{
    public class GetAllEvaluationListQuery : IRequest<IList<EvaluationProcessVM>>
    {

    }

    public class GetAllEvaluationListQueryHandler : IRequestHandler<GetAllEvaluationListQuery, IList<EvaluationProcessVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEvaluationListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
             _context = context;
            _mapper = mapper;
        }

        public async Task<IList<EvaluationProcessVM>> Handle(GetAllEvaluationListQuery request, CancellationToken cancellationToken)
        {

            var evaluations = await _context.EvaluationProcesses.Include(i => i.Evaluators).Include(x=>x.EvaluationTechnologies).ToListAsync();

            if (evaluations == null)
            {
                throw new NotFoundException(nameof(ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess));
            }

            return _mapper.Map<List<EvaluationProcessVM>>(evaluations); ;
        }
    }
}
