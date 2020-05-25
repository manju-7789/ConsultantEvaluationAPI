using AutoMapper;
using ConsultantEvaluationApp.Application.Common.Exceptions;
using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.Queries.GetEvaluationList
{
    public class GetEvaluationListQuery :IRequest<IList<EvaluationProcessVM>>
    {
        public int EvaluationId { get; set; }
    }

    public class GetEvaluationListQueryHandler : IRequestHandler<GetEvaluationListQuery, IList<EvaluationProcessVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEvaluationListQueryHandler> _logger;
        public GetEvaluationListQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetEvaluationListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger ??
               throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IList<EvaluationProcessVM>> Handle(GetEvaluationListQuery request, CancellationToken cancellationToken)
        {

            var result = new List<EvaluationProcessVM>();
            var evaluations = await _context.EvaluationProcesses
                .Include(i => i.Evaluators)
                .Include(x => x.EvaluationTechnologies)
                .Where(i => i.EvaluationId == request.EvaluationId).ToListAsync();

            if (evaluations == null)
            {
                _logger.LogWarning("Evaluation Process List not found");
                throw new NotFoundException(nameof(ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess), request.EvaluationId);
            }

            return _mapper.Map<List<EvaluationProcessVM>>(evaluations); 
        }
    }
}
