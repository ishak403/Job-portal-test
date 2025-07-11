using MediatR;
using TeknorixTest.Entities;
using TeknorixTest.Models;
using TeknorixTest.Repository;

namespace TeknorixTest.Commands
{
    public class UpdateLocationCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public CreateLocationDto Locationdto { get; set; }
    }
    public class UpdateLocationHandler(IRepository repo) : IRequestHandler<UpdateLocationCommand, bool>
    {
        private readonly IRepository _repo = repo;

        public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var existingLocation = await _repo.GetByIdAsync<Location>(request.Id);
            if (existingLocation == null)
                return false;

            var location = request.Locationdto;

            existingLocation.Title = location.Title;
            existingLocation.City = location.City;
            existingLocation.State = location.State;     
            existingLocation.Country = location.Country;
            existingLocation.Zip = location.Zip;
          
            _repo.Update(existingLocation);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
