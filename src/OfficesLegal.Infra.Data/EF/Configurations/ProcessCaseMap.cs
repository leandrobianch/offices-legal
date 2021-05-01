using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfficesLegal.Infra.Data.EF.Configurations
{
    public class ProcessCaseMap : IEntityTypeConfiguration<Domain.ProcessCases.ProcessCase>
    {
        public void Configure(EntityTypeBuilder<Domain.ProcessCases.ProcessCase> builder)
        {
            builder.ToTable("TB_PROCESS_CASE");
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id)
                .HasColumnName("ID_PROCESS_CASE")
                .HasComment("Primary key table");
            builder.Property(k => k.CaseNumber)
                .HasColumnName("CASE_NUMBER")
                .IsRequired()
                .HasComment(@"that represents the case number according to the National Council of Justice
                            (CNJ) standard.It has the format: NNNNNNN - NN.NNNN.N.NN.NNNN, where N can be any positive
                            integer");
            builder.Property(k => k.CourtName)
            .HasColumnName("COURT_NAME")
            .IsRequired()
            .HasComment(@"that represents the name of the court of origin of the case. Example: Supreme
                          Federal Court.
                         ");
            builder.Property(k => k.NameOfTheResponsible)
            .HasColumnName("NAME_OF_THE_RESPONSIBLE")
            .IsRequired()
            .HasComment("representing the name of the lawyer responsible for the case.");
            builder.Property(k => k.RegistrationDate)
           .HasColumnName("REGISTRATION_DATE")
           .IsRequired()
           .HasComment("Date on which the case was registered in the system.");
        }
    }
}
