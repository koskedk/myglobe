using CSharpFunctionalExtensions;

namespace MyGlobe.Domain
{
    public enum Gender {Male,Female }
    public class Patient : Entity<PatientId>
    {
        public string FullName { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public FacilityId FacilityId   { get; private set; }

        private Patient()
        {
        }

        public Patient(PatientId id, string fullName, Gender gender, DateTime birthDate, FacilityId facilityId) : base(id)
        {
            FullName = fullName;
            Gender = gender;
            BirthDate = birthDate;
            FacilityId = facilityId;
        }
    }
}