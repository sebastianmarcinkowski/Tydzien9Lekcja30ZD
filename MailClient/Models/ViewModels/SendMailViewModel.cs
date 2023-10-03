using System.ComponentModel.DataAnnotations;

namespace MailClient.Models.ViewModels
{
	public class SendMailViewModel
	{

		[Required(ErrorMessage = "Pole Nadawca jest wymagane.")]
		[Display(Name = "Nadawca")]
		public string SenderName { get; set; }

		[Required(ErrorMessage = "Pole Odbiorca / Odbiorcy jest wymagane.")]
		[Display(Name = "Odbiorca / Odbiorcy")]
		public string To { get; set; }

		[Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
		[Display(Name = "Tytuł")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Pole Treść jest wymagane.")]
		[Display(Name = "Treść")]
		public string Content { get; set; }
	}
}