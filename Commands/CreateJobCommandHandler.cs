using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeknorixTest.Dtos;
using TeknorixTest.Entities;
using TeknorixTest.Exceptions;
using TeknorixTest.Repository;

namespace TeknorixTest.Commands
{
    public class CreateJobCommand:IRequest<int>
    {
        public CreateJobDto CreateJobDto { get; set; }
    }
    public class CreateJobHandler(IRepository repo,IMapper mapper) : IRequestHandler<CreateJobCommand, int>
    {
        private readonly IRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var CreateJobDto = request.CreateJobDto;

            var locationExists = await _repo.LocationExistsAsync(CreateJobDto.LocationId);
            var departmentExists = await _repo.DepartmentExistsAsync(CreateJobDto.DepartmentId);

            if (!locationExists || !departmentExists)
            {
                throw new ValidationException("Invalid LocationId or DepartmentId.");
            }

            var CreateJob = new CreateJobDto
            {               
                Title = CreateJobDto.Title,
                Description = CreateJobDto.Description,
                DepartmentId = CreateJobDto.DepartmentId,
                LocationId = CreateJobDto.LocationId,
                ClosingDate = CreateJobDto.ClosingDate
            };
            var jobEntity = _mapper.Map<Job>(CreateJob);

            var PostedDate = DateTime.UtcNow;

            var lastJob = await _repo.GetLastJobAsync();
            int lastNumber = 0;

            if (lastJob != null && lastJob.Code?.StartsWith("Job-") == true)
            {
                int.TryParse(lastJob.Code.Split('-')[1], out lastNumber);
            }

            var Code = $"Job-{(lastNumber + 1).ToString("D3")}";
            jobEntity.PostedDate = PostedDate;
            jobEntity.Code = Code;
            await _repo.AddAsync(jobEntity);
            return jobEntity.Id;
        }
    }
}
