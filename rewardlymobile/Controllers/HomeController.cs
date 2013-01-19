using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using BusinessLMSWeb.Helpers;
using rewardly.Models;
using rewardly.ViewModels;
using WebMatrix.WebData;

namespace rewardly.Controllers
{
	[Authorize]
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			BaseClient client = new BaseClient(baseApiUrl, "Members", "GetUserCompanyPoints");
			List<CompanyPoints> result = client.Get<List<CompanyPoints>>(WebSecurity.CurrentUserId);
			return View(result);
		}

		public ActionResult LocationsList(int id)
		{

			//TODO: SEND GEO DATA TO API OR SOLVE IT HERE
			BaseClient client = new BaseClient(baseApiUrl, "Location", "GetCompanyLocations");
			List<location> result = client.Get<List<location>>(id);

			client = new BaseClient(baseApiUrl, "Members", "GetPoints");
			NameValueCollection parms = new NameValueCollection() {
					{ "UserId", WebSecurity.CurrentUserId.ToString() }, 
					{ "CompanyId", id.ToString() } 
				};
			CompanyPoints company = client.Get<CompanyPoints>(parms);
			ViewBag.CompanyLogo = company.companyLogo;
			ViewBag.MemberPoints = company.points;

			return View(result);
		}

		public ActionResult LocationDetails(int id)
		{
			BaseClient client = new BaseClient(baseApiUrl, "Location", "Getlocation");
			location loc = client.Get<location>(id);

			client = new BaseClient(baseApiUrl, "Members", "GetPoints");
			NameValueCollection parms = new NameValueCollection() {
					{ "UserId", WebSecurity.CurrentUserId.ToString() }, 
					{ "CompanyId", id.ToString() } 
				};
			CompanyPoints company = client.Get<CompanyPoints>(parms);
			ViewBag.CompanyLogo = company.companyLogo;
			ViewBag.MemberPoints = company.points;

			return View(loc);
		}

		public ActionResult RewardCatalog(int id)
		{
			BaseClient client = new BaseClient(baseApiUrl, "Rewards", "GetLocationCatalog");
			List<catalog> result = client.Get<List<catalog>>(id);

			client = new BaseClient(baseApiUrl, "Members", "GetPoints");
			NameValueCollection parms = new NameValueCollection() {
					{ "UserId", WebSecurity.CurrentUserId.ToString() }, 
					{ "CompanyId", id.ToString() } 
				};
			CompanyPoints company = client.Get<CompanyPoints>(parms);
			ViewBag.CompanyLogo = company.companyLogo;
			ViewBag.MemberPoints = company.points;


			return View(result);
		}

	}
}
