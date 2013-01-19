using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLMSWeb.Helpers;
using rewardly.ViewModels;

namespace rewardly.Controllers
{
	[Authorize]
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{

			BaseClient client = new BaseClient(baseApiUrl, "Members", "GetUserCompanyPoints");
			List<CompanyPoints> result = client.Get<List<CompanyPoints>>(UserId);

			return View();
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
