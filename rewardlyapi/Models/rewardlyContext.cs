using System.Data.Entity;
using rewardly.Models.Mapping;

namespace rewardly.Models
{
	public class rewardlyContext : DbContext
	{
		static rewardlyContext()
		{
			Database.SetInitializer<rewardlyContext>(null);
		}

		public rewardlyContext()
			: base("Name=rewardlydb")
		{
		}

		public DbSet<catalog> catalogs { get; set; }
		public DbSet<company> companies { get; set; }
		public DbSet<venue> venues { get; set; }
		public DbSet<game> games { get; set; }
		public DbSet<locationGame> locationGames { get; set; }
		public DbSet<location> locations { get; set; }
		public DbSet<memberGame> memberGames { get; set; }
		public DbSet<memberRedemption> memberRedemptions { get; set; }
		public DbSet<memberVisit> memberVisits { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<webpages_Membership> webpages_Membership { get; set; }
		public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
		public DbSet<webpages_Roles> webpages_Roles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new catalogMap());
			modelBuilder.Configurations.Add(new companyMap());
			modelBuilder.Configurations.Add(new venuesMap());
			modelBuilder.Configurations.Add(new gameMap());
			modelBuilder.Configurations.Add(new locationGameMap());
			modelBuilder.Configurations.Add(new locationMap());
			modelBuilder.Configurations.Add(new memberGameMap());
			modelBuilder.Configurations.Add(new memberRedemptionMap());
			modelBuilder.Configurations.Add(new memberVisitMap());
			modelBuilder.Configurations.Add(new UserProfileMap());
			modelBuilder.Configurations.Add(new webpages_MembershipMap());
			modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
			modelBuilder.Configurations.Add(new webpages_RolesMap());
		}
	}
}
