using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class locationMap : EntityTypeConfiguration<location>
	{
		public locationMap()
		{
			// Primary Key
			this.HasKey(t => t.locationId);

			// Properties
			this.Property(t => t.address)
				.IsRequired()
				.HasMaxLength(150);

			this.Property(t => t.address1)
				.HasMaxLength(150);

			this.Property(t => t.phone)
				.HasMaxLength(20);

			// Table & Column Mappings
			this.ToTable("locations");
			this.Property(t => t.locationId).HasColumnName("locationId");
			this.Property(t => t.venueId).HasColumnName("cuisineId");
			this.Property(t => t.address).HasColumnName("address");
			this.Property(t => t.address1).HasColumnName("address1");
			this.Property(t => t.phone).HasColumnName("phone");
			this.Property(t => t.locPicture).HasColumnName("locPicture");
			this.Property(t => t.pricePoint).HasColumnName("pricePoint");
		}
	}
}
