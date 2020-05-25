using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluatonApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechnologyList
{
   public class CreateTechnologyListCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateTechnologyListCommandHandler : IRequestHandler<CreateTechnologyListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTechnologyListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTechnologyListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TechnologyArea
            {
                Name = request.Name
            };

            _context.TechnologyAreas.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.TechId;
        }
    }
}
