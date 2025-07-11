using AutoMapper;
using MediatR;
using TeknorixTest.Entities;
using TeknorixTest.Models;
using TeknorixTest.Repository;

namespace TeknorixTest.Queries
{
    public class GetAllDepartmentQuery : IRequest<List<DepartmentDto>>;
   
    public class GetAllDepartmentHandler(IRepository repository, IMapper mapper) : IRequestHandler<GetAllDepartmentQuery, List<DepartmentDto>>
    {
        private readonly IRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var locations = await _repository.GetAllAsync<Department>();
            return _mapper.Map<List<DepartmentDto>>(locations);
        }
    }
}
