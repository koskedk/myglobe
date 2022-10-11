using System.Linq;
using MyGlobe.Domain;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using MyGlobe.Infrastructure.Persistence;

namespace MyGlobe.Infrastructure.Tests.Persistence;

[TestFixture]
public class FacilityRepositoryTests
{
    private IFacilityRepository _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = TestInitializer.ServiceProvider.GetService<IFacilityRepository>();
    }

    [Test]
    public void should_Add()
    {
        var facId = new FacilityId(1);
        var fac = new Facility(new FacilityId(1), "Demo");
        
        _repository.Add(fac);
        _repository.Save();

        var ctx = TestInitializer.ServiceProvider.GetService<ApplicationDbContext>();
        Assert.True(ctx.Facilities.Any());
    }
}