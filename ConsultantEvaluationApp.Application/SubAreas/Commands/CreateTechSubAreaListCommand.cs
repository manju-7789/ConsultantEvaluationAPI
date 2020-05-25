using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluatonApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.SubAreas.Commands
{
    public class CreateTechSubAreaListCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int TechId { get; set; }
    }

    public class CCreateTechSubAreaListCommandHandler : IRequestHandler<CreateTechSubAreaListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CCreateTechSubAreaListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTechSubAreaListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TechSubArea
            {
                Name = request.Name,
                TechId = request.TechId
            };

            _context.TechSubAreas.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.SubTechId;
        }
    }
}
