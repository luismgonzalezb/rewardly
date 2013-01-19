using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class memberCompanyMap : EntityTypeConfiguration<memberCompany>
	{
		public memberCompanyMap()
		{
			// Primary Key
			this.HasKey(t => t.memberCompanyId);

			// Properties
			// Table & Column Mappings
			this.ToTable("memberCompany");
			this.Property(t => t.memberCompanyId).HasColumnName("memberCompanyId");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.companyId).HasColumnName("companyId");
			this.Property(t => t.points).HasColumnName("points");
		}
	}
}
