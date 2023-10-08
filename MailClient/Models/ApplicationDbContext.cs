using MailClient.Models.Domains;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MailClient.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public DbSet<MailEntity> Mails { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MailEntity>()
				.HasKey(x => x.MailId);

			modelBuilder.Entity<ApplicationUser>()
				.HasMany(x => x.Mails);

			base.OnModelCreating(modelBuilder);
		}
	}
}