using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class memberVisitMap : EntityTypeConfiguration<memberVisit>
	{
		public memberVisitMap()
		{
			// Primary Key
			this.HasKey(t => t.memberVisitId);

			// Properties
			// Table & Column Mappings
			this.ToTable("memberVisits");
			this.Property(t => t.memberVisitId).HasColumnName("memberVisitId");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.locationId).HasColumnName("locationId");
			this.Property(t => t.datetime).HasColumnName("datetime");
		}
	}
}
