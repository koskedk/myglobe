using CSharpFunctionalExtensions;

namespace MyGlobe.Domain;

public class PatientId : ValueObject
{
    public int Pk { get; private set; }
    public int SiteCode { get; private set; }

    public PatientId(int pk, int siteCode)
    {
        Pk = pk;
        SiteCode = siteCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Pk;
        yield return SiteCode;
    }
}