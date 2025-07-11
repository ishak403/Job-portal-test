using AutoMapper;
using MediatR;
using TeknorixTest.Entities;
using TeknorixTest.Models;
using TeknorixTest.Repository;

namespace TeknorixTest.Queries
{
    public class GetAllLocationQuery : IRequest<List<LocationDto>>;
   
    public class GetAllLocationHandler(IRepository repository, IMapper mapper) : IRequestHandler<GetAllLocationQuery, List<LocationDto>>
    {
        private readonly IRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<LocationDto>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            var locations = await _repository.GetAllAsync<Location>();
            return _mapper.Map<List<LocationDto>>(locations);
        }
    }
}
