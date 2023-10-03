using System.ComponentModel.DataAnnotations;

namespace MailClient.Models
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}