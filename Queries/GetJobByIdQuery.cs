using AutoMapper;
using MediatR;
using TeknorixTest.Dtos;
using TeknorixTest.Entities;
using TeknorixTest.Exceptions;
using TeknorixTest.Models;
using TeknorixTest.Repository;

namespace TeknorixTest.Queries
{
    public class GetJobByIdQuery : IRequest<JobDto>
    {
        public int Id { get; set; }
    }
   
    public class GetJobByIdQueryHandler(IRepository repository, IMapper mapper) : IRequestHandler<GetJobByIdQuery, JobDto>
    {
        private readonly IRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<JobDto> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _repository.GetByIdAsync<Job>(request.Id) ?? throw new ValidationException("Invalid Job ID.");
            var jobDto = _mapper.Map<JobDto>(job);

            if (job.LocationId > 0)
            {
                var location = await _repository.GetByIdAsync<Location>(job.LocationId);
                jobDto.LocationDto = _mapper.Map<LocationDto>(location);
            }

            if (job.DepartmentId > 0)
            {
                var department = await _repository.GetByIdAsync<Department>(job.DepartmentId);
                jobDto.DepartmentDto = _mapper.Map<DepartmentDto>(department);
            }

            return jobDto;
        }
    }
}
