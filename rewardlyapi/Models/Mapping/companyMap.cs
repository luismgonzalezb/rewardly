using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class companyMap : EntityTypeConfiguration<company>
	{
		public companyMap()
		{
			// Primary Key
			this.HasKey(t => t.companyId);

			// Properties
			this.Property(t => t.companyName)
				.IsRequired()
				.HasMaxLength(100);

			this.Property(t => t.companyPhone)
				.IsRequired()
				.HasMaxLength(20);

			// Table & Column Mappings
			this.ToTable("companies");
			this.Property(t => t.companyId).HasColumnName("companyId");
			this.Property(t => t.companyName).HasColumnName("companyName");
			this.Property(t => t.companyPhone).HasColumnName("companyPhone");
			this.Property(t => t.companyLogo).HasColumnName("companyLogo");
		}
	}
}
