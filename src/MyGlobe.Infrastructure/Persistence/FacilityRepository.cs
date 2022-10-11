using MyGlobe.Domain;

namespace MyGlobe.Infrastructure.Persistence
{
    public class FacilityRepository:Repository<Facility,FacilityId>, IFacilityRepository
    {
        public FacilityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}