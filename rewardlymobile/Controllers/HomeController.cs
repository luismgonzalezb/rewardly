using System.Collections.Generic;
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

			client = new BaseClient(baseApiUrl, "Company", "Getcompany");
			company company = client.Get<company>(id);
			ViewBag.CompanyLogo = company.companyLogo;

			return View(result);
		}

		public ActionResult LocationDetails(int id)
		{
			BaseClient client = new BaseClient(baseApiUrl, "Location", "Getlocation");
			location loc = client.Get<location>(id);

			client = new BaseClient(baseApiUrl, "Company", "Getcompany");
			company company = client.Get<company>(loc.companyId);
			ViewBag.CompanyLogo = company.companyLogo;

			return View(loc);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
