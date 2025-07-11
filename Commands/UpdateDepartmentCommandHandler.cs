using MediatR;
using TeknorixTest.Dtos;
using TeknorixTest.Entities;
using TeknorixTest.Models;
using TeknorixTest.Repository;

namespace TeknorixTest.Commands
{
    public class UpdateDepartmentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public CreateDepartmentDto Department { get; set; }
    }
    public class UpdateDepartmentHandler(IRepository repo) : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly IRepository _repo = repo;

        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var existingDepartment = await _repo.GetByIdAsync<Department>(request.Id);
            if (existingDepartment == null)
                return false;

            var department = request.Department;

            existingDepartment.Title = department.Title;

            _repo.Update(existingDepartment);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
