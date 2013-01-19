using System;

namespace rewardly.Models
{
	public class memberRedemption
	{
		public long memberRedemptionId { get; set; }
		public int UserId { get; set; }
		public int catalogId { get; set; }
		public Nullable<System.DateTime> datetime { get; set; }
		public Nullable<System.DateTime> expires { get; set; }
	}
}
