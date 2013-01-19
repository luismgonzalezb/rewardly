using System.Configuration;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace rewardly.Controllers
{

	[Authorize]
	public class BaseController : Controller
	{

		public int UserId
		{
			get { return WebSecurity.CurrentUserId; }
		}

		public string baseApiUrl
		{
			get { return ConfigurationManager.AppSettings["ApiUrl"]; }
		}

	}
}
