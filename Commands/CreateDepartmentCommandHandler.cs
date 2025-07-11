using MediatR;
using TeknorixTest.Dtos;
using TeknorixTest.Entities;
using TeknorixTest.Models;
using TeknorixTest.Repository;

namespace TeknorixTest.Commands
{
    public class CreateDepartmentCommand:IRequest<int>
    {
        public required CreateDepartmentDto Department { get; set; }
    }
    public class CreateDepartmentHandler(IRepository repo) : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IRepository _repo = repo;

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {

            var department = new Department
            {
                
                Title = request.Department.Title,
               
            };

            await _repo.AddAsync(department);
            return department.Id;
        }
    }
}
