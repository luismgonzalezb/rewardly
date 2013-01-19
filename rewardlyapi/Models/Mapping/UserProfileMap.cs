using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class UserProfileMap : EntityTypeConfiguration<UserProfile>
	{
		public UserProfileMap()
		{
			// Primary Key
			this.HasKey(t => t.UserId);

			// Properties
			this.Property(t => t.UserName)
				.IsRequired()
				.HasMaxLength(56);

			this.Property(t => t.FirstName)
				.HasMaxLength(50);

			this.Property(t => t.LastName)
				.HasMaxLength(50);

			this.Property(t => t.Email)
				.HasMaxLength(150);

			// Table & Column Mappings
			this.ToTable("UserProfile");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.UserName).HasColumnName("UserName");
			this.Property(t => t.FirstName).HasColumnName("FirstName");
			this.Property(t => t.LastName).HasColumnName("LastName");
			this.Property(t => t.Email).HasColumnName("Email");
		}
	}
}
