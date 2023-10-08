using MailClient.Models.Domains;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MailClient.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			Mails = new Collection<MailEntity>();
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

			return userIdentity;
		}

		public ICollection<MailEntity> Mails { get; set; }
	}
}