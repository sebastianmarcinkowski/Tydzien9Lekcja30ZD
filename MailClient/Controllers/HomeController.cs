using MailClient.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MailClient.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[AllowAnonymous]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult SendMail(SendMailViewModel model)
		{
			if (!ModelState.IsValid)
				return View("Index", model);

			var recipients = ParseRecipments(model.To);

			foreach (var recipment in recipients)
			{
				//SendMail...
			}

			//If success

			TempData["message"] = Resources.Messages.SendMailConfirmation;

			return RedirectToAction("Index");
		}

		private List<string> ParseRecipments(string to)
		{
			var outputList = new List<string>(to.Trim().Split(','));

			return outputList
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.Distinct()
				.ToList();
		}
	}
}