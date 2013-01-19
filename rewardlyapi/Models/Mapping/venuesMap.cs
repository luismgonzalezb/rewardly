using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class venuesMap : EntityTypeConfiguration<venue>
	{
		public venuesMap()
		{
			// Primary Key
			this.HasKey(t => t.venueId);

			// Properties
			this.Property(t => t.name)
				.IsRequired()
				.HasMaxLength(50);

			// Table & Column Mappings
			this.ToTable("venues");
			this.Property(t => t.venueId).HasColumnName("venueId");
			this.Property(t => t.name).HasColumnName("name");
		}
	}
}
