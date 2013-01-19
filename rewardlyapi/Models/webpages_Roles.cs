using System.Collections.Generic;

namespace rewardly.Models
{
	public class webpages_Roles
	{
		public webpages_Roles()
		{
			this.UserProfiles = new List<UserProfile>();
		}

		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public virtual ICollection<UserProfile> UserProfiles { get; set; }
	}
}
