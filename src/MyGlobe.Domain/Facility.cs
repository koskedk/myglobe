using CSharpFunctionalExtensions;

namespace MyGlobe.Domain
{
    public class Facility : Entity<FacilityId>
    {
        public string Name { get; private set; }
        public ICollection<Patient> Patients { get; private set; } = new List<Patient>();

        private Facility()
        {
            
        }
        public Facility(FacilityId id, string name) : base(id)
        {
            Name = name;
        }
    }
}