using EmailSender;
using MailClient.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MailClient.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		Email _email = new Email(Startup.EmailConfiguration);

		public ActionResult Index()
		{
			ViewBag.Title = Resources.Titles.HomeIndexHeader;

			return View();
		}

		public async Task<ActionResult> SendMail(SendMailViewModel model)
		{
			if (!ModelState.IsValid)
				return View("Index", model);

			try
			{
				var recipients = ParseRecipments(model.To);

				foreach (var recipment in recipients)
				{
					await _email.Send(model.SenderName, model.Title, model.Content, recipment);
				}

				TempData["message"] = Resources.Messages.SendMailConfirmation;
			}
			catch (Exception error)
			{
				// Error logging...

				TempData["message"] = Resources.Messages.SendMailError;

				return RedirectToAction("Index");
			}

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