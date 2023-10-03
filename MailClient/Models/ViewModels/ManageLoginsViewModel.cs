using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace MailClient.Models
{
	public class ManageLoginsViewModel
	{
		public IList<UserLoginInfo> CurrentLogins { get; set; }
		public IList<AuthenticationDescription> OtherLogins { get; set; }
	}
}
