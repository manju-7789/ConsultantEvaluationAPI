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

namespace ConsultantEvaluationApp.Application.SubAreas.Queries.GetTechSubAreaList
{
    public class GetTechSubAreaListQuery : IRequest<TechSubAreaListVM>
    {
        public int TechId { get; set; }
    }

    public class GetTechSubAreaListHandler : IRequestHandler<GetTechSubAreaListQuery, TechSubAreaListVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTechSubAreaListHandler> _logger;
        public GetTechSubAreaListHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetTechSubAreaListHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TechSubAreaListVM> Handle(GetTechSubAreaListQuery request, CancellationToken cancellationToken)
        {

            var techSubAreas = await _context.TechSubAreas
                   .Where(t=>t.TechId == request.TechId)
                   .ProjectTo<TechSubAreaLookupDto>(_mapper.ConfigurationProvider)
                  // .OrderBy(e => e.Name)
                   .ToListAsync(cancellationToken);

            var vm = new TechSubAreaListVM
            {
                TechSubAreas = techSubAreas
            };

            if (vm == null)
            {
                _logger.LogWarning("Technology Sub Areas Not found with {Id}", request.TechId);
                throw new NotFoundException(nameof(TechSubArea), request);
            }

            return vm;
        }
    }
}
