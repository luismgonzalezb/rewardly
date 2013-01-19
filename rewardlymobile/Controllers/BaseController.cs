using System.Configuration;
using System.Web.Mvc;

namespace rewardly.Controllers
{

	public class BaseController : Controller
	{

		public string baseApiUrl
		{
			get { return ConfigurationManager.AppSettings["ApiUrl"]; }
		}

	}
}
