using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class locationGameMap : EntityTypeConfiguration<locationGame>
	{
		public locationGameMap()
		{
			// Primary Key
			this.HasKey(t => t.locationGameId);

			// Properties
			// Table & Column Mappings
			this.ToTable("locationGames");
			this.Property(t => t.locationGameId).HasColumnName("locationGameId");
			this.Property(t => t.gameId).HasColumnName("gameId");
			this.Property(t => t.locationId).HasColumnName("locationId");
			this.Property(t => t.points).HasColumnName("points");
		}
	}
}
