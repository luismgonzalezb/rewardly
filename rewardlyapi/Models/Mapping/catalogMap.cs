using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class catalogMap : EntityTypeConfiguration<catalog>
	{
		public catalogMap()
		{
			// Primary Key
			this.HasKey(t => t.catalogId);

			// Properties
			this.Property(t => t.prizeDescription)
				.IsRequired();

			// Table & Column Mappings
			this.ToTable("catalog");
			this.Property(t => t.catalogId).HasColumnName("catalogId");
			this.Property(t => t.locationId).HasColumnName("locationId");
			this.Property(t => t.prizeDescription).HasColumnName("prizeDescription");
			this.Property(t => t.points).HasColumnName("points");
		}
	}
}
