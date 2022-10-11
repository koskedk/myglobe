using CSharpFunctionalExtensions;

namespace MyGlobe.Domain
{
    public class FacilityId:ValueObject
    {
        public int SiteCode { get; private set; }

        public FacilityId(int siteCode)
        {
            SiteCode = siteCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SiteCode;
        }
    }
}