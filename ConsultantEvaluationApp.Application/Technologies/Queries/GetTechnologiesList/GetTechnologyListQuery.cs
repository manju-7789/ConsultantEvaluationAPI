using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConsultantEvaluationApp.Application.Common.Exceptions;
using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluatonApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.Technologies.Queries.GetTechnologiesList
{
    public class GetTechnologyListQuery : IRequest<TechnologyListVM>
    {

    }

    public class GetTechnologyListHandler : IRequestHandler<GetTechnologyListQuery, TechnologyListVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTechnologyListHandler> _logger;
        public GetTechnologyListHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           // _logger = logger;
        }

        public async Task<TechnologyListVM> Handle(GetTechnologyListQuery request, CancellationToken cancellationToken)
        {

            var technologies = await _context.TechnologyAreas
                   .ProjectTo<TechnologyLookupDto>(_mapper.ConfigurationProvider)
                   .OrderBy(e => e.Name)
                   .ToListAsync(cancellationToken);

            var vm = new TechnologyListVM
            {
                Technologies = technologies
            };

            if (vm == null)
            {
               // _logger.LogWarning("Technologies List not found");
                throw new NotFoundException(nameof(TechnologyArea),request);
            }

            return vm;
        }
    }
}
