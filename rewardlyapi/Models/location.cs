
namespace rewardly.Models
{
	public class location
	{
		public int locationId { get; set; }
		public int companyId { get; set; }
		public int venueId { get; set; }
		public string address { get; set; }
		public string address1 { get; set; }
		public string phone { get; set; }
		public string locPicture { get; set; }
		public int pricePoint { get; set; }
	}
}
