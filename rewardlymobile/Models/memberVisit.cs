
namespace rewardly.Models
{
	public class memberVisit
	{
		public long memberVisitId { get; set; }
		public int UserId { get; set; }
		public int locationId { get; set; }
		public System.DateTime datetime { get; set; }
	}
}
