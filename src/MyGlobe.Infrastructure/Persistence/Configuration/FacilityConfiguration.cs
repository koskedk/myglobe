using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGlobe.Domain;

namespace MyGlobe.Infrastructure.Persistence.Configuration;

public class FacilityConfiguration:IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        var facIdConverter = new ValueConverter<FacilityId, FacilityId>(
            to =>new FacilityId(to.SiteCode),
            from => new FacilityId(from.SiteCode)
        );
        
        builder
            .Property(b => b.Id)
            .HasConversion(facIdConverter);
    }
}