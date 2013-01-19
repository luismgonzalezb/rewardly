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
			BaseClient client = new BaseClient(baseApiUrl, "Location", "GetCompanyLocations");
			List<CompanyPoints> result = client.Get<List<CompanyPoints>>(id);

			client = new BaseClient(baseApiUrl, "Company", "Getcompany");
			company company = client.Get<company>(id);

			return View(result);
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
