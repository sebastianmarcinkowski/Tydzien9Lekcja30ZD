using System.ComponentModel.DataAnnotations;

namespace MailClient.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Pole E-mail jest wymagane.")]
		[Display(Name = "E-mail")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Pole Hasło jest wymagane.")]
		[DataType(DataType.Password)]
		[Display(Name = "Hasło")]
		public string Password { get; set; }

		[Display(Name = "Zapamiętaj mnie")]
		public bool RememberMe { get; set; }
	}
}