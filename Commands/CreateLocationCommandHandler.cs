using MediatR;
using TeknorixTest.Entities;
using TeknorixTest.Models;
using TeknorixTest.Repository;

namespace TeknorixTest.Commands
{
    public class CreateLocationCommand:IRequest<int>
    {
        public CreateLocationDto Location { get; set; }
    }
    public class CreateLocationHandler(IRepository repo) : IRequestHandler<CreateLocationCommand, int>
    {
        private readonly IRepository _repo = repo;

        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {

            var location = new Location
            {            
                Title = request.Location.Title,
                City = request.Location.City,
                State = request.Location.State,
                Country = request.Location.Country,
                Zip = request.Location.Zip
            };

            await _repo.AddAsync(location);
            return location.Id;
        }
    }
}
