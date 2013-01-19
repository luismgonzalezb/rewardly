using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class memberRedemptionMap : EntityTypeConfiguration<memberRedemption>
	{
		public memberRedemptionMap()
		{
			// Primary Key
			this.HasKey(t => t.memberRedemptionId);

			// Properties
			// Table & Column Mappings
			this.ToTable("memberRedemptions");
			this.Property(t => t.memberRedemptionId).HasColumnName("memberRedemptionId");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.catalogId).HasColumnName("catalogId");
			this.Property(t => t.datetime).HasColumnName("datetime");
			this.Property(t => t.expires).HasColumnName("expires");
			this.Property(t => t.code).HasColumnName("code");
			this.Property(t => t.redemed).HasColumnName("redemed");
		}
	}
}
