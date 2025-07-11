using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeknorixTest.Data;
using TeknorixTest.Dtos;

namespace TeknorixTest.Queries
{
    public class GetFilteredJobsQuery : IRequest<PaginatedJobResultDto>
    {
        public JobFilterDto Filter { get; set; }
    }

    public class GetFilteredJobsHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetFilteredJobsQuery, PaginatedJobResultDto>
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedJobResultDto> Handle(GetFilteredJobsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Jobs
                        .AsQueryable();

            if (!string.IsNullOrEmpty(request.Filter.Q))
                query = query.Where(j => j.Title.Contains(request.Filter.Q));

            if (request.Filter.LocationId.HasValue)
                query = query.Where(j => j.LocationId == request.Filter.LocationId.Value);

            if (request.Filter.DepartmentId.HasValue)
                query = query.Where(j => j.DepartmentId == request.Filter.DepartmentId.Value);

            var totalCount = await query.CountAsync(cancellationToken: cancellationToken);

            var job = await query
                .OrderBy(j => j.PostedDate) 
                .Skip((request.Filter.PageNo - 1) * request.Filter.PageSize)
                .Take(request.Filter.PageSize)
                .ToListAsync();
            var data = await (from q in query
                        join l in _context.Locations.AsQueryable() on q.LocationId equals l.Id
                        join d in _context.Departments.AsQueryable() on q.DepartmentId equals d.Id
                        select new JobListDto
                        {
                            Id = q.Id,
                            Code = q.Code,
                            Title = q.Title,
                            Location = l.Title,                         
                            Department = d.Title,                         
                            PostedDate = q.PostedDate,
                            ClosingDate = q.ClosingDate,

                        }).ToListAsync(cancellationToken: cancellationToken);

            return new PaginatedJobResultDto
            {
                TotalCount = totalCount,
                Jobs =data
            };
        }
    }

}
