using System.Collections.Generic;

namespace rewardly.Models
{
	public class UserProfile
	{
		public UserProfile()
		{
			this.webpages_Roles = new List<webpages_Roles>();
		}

		public int UserId { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
	}
}
