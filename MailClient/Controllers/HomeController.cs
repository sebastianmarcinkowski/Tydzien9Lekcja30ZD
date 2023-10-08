using EmailSender;
using MailClient.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MailClient.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
		Email _email = new Email(Startup.EmailConfiguration);

		public ActionResult Index()
		{
			ViewBag.Title = Resources.Titles.HomeIndexHeader;

			return View();
		}

		public async Task<ActionResult> SendMail(SendMailViewModel model, HttpPostedFileBase attachment)
		{
			if (!ModelState.IsValid)
				return View("Index", model);

			try
			{
				var recipients = ParseRecipments(model.To);

				foreach (var recipment in recipients)
				{
					await _email.Send(model.SenderName, model.Title, model.Content, recipment, attachment);
				}

				TempData["message"] = Resources.Messages.SendMailConfirmation;
			}
			catch (Exception error)
			{
				Logger.Error(
					error,
					"USER:" +
					User.Identity.Name +
					"|" +
					error.Message);

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