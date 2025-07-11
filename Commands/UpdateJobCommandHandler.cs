using AutoMapper;
using MediatR;
using TeknorixTest.Dtos;
using TeknorixTest.Entities;
using TeknorixTest.Repository;

namespace TeknorixTest.Commands
{
    public class UpdateJobCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public CreateJobDto CreateJobDto { get; set; }
    }
    public class UpdateJobHandler(IRepository repo) : IRequestHandler<UpdateJobCommand, bool>
    {
        private readonly IRepository _repo = repo;

        public async Task<bool> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var existingJob = await _repo.GetByIdAsync<Job>(request.Id);
            if (existingJob == null)
                return false;

            var jobModel = request.CreateJobDto;

            existingJob.Title = jobModel.Title;
            existingJob.Description = jobModel.Description;
            existingJob.DepartmentId = jobModel.DepartmentId;
            existingJob.LocationId = jobModel.LocationId;
            existingJob.ClosingDate = jobModel.ClosingDate;

            _repo.Update(existingJob);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
