using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGlobe.Domain;

namespace MyGlobe.Infrastructure.Persistence.Configuration;

public class PatientConfiguration:IEntityTypeConfiguration<Patient>
{
    
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        var pIdConverter = new ValueConverter<PatientId, PatientId>(
            to => new PatientId(to.Pk,to.SiteCode),
            from => new PatientId(from.Pk,from.SiteCode)
        );
        
        builder
            .Property(b => b.Id)
            .HasConversion(pIdConverter);
    }
}