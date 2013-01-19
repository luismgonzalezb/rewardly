using System.Data.Entity.ModelConfiguration;

namespace rewardly.Models.Mapping
{
	public class gameMap : EntityTypeConfiguration<game>
	{
		public gameMap()
		{
			// Primary Key
			this.HasKey(t => t.gameId);

			// Properties
			this.Property(t => t.name)
				.IsRequired()
				.HasMaxLength(50);

			// Table & Column Mappings
			this.ToTable("games");
			this.Property(t => t.gameId).HasColumnName("gameId");
			this.Property(t => t.name).HasColumnName("name");
		}
	}
}
