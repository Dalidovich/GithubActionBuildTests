using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GithubActionBuildTests.Domain.Models;

namespace GithubActionBuildTests.DAL
{
    public class CalculatorConfig : IEntityTypeConfiguration<SummaryCalc>
    {
        public const string Table_name = "SummaryCalcs";

        public void Configure(EntityTypeBuilder<SummaryCalc> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_summary_id");

            builder.Property(e => e.MethodName)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("method_name");

            builder.Property(e => e.FirstNum)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("first_num");

            builder.Property(e => e.SecondNum)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("second_num");
        }
    }
}
