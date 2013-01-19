using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class memberGameMap : EntityTypeConfiguration<memberGame>
	{
		public memberGameMap()
		{
			// Primary Key
			this.HasKey(t => t.memberGamesId);

			// Properties
			// Table & Column Mappings
			this.ToTable("memberGames");
			this.Property(t => t.memberGamesId).HasColumnName("memberGamesId");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.locationGameId).HasColumnName("locationGameId");
		}
	}
}
