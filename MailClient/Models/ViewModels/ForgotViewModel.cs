using System.ComponentModel.DataAnnotations;

namespace MailClient.Models
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}