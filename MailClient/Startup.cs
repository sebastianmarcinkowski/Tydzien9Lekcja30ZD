using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MailClient.Startup))]
namespace MailClient
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
