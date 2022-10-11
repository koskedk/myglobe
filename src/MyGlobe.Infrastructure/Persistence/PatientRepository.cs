using MyGlobe.Domain;

namespace MyGlobe.Infrastructure.Persistence
{
    public class PatientRepository:Repository<Patient,int>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}