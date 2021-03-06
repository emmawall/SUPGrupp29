using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Grupp29.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string listName { get; set; }

        public string DisplayName { get; set; }

        public string ProfileImg { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<RoomList> RoomLists{ get; set;}

		//public System.Data.Entity.DbSet<Grupp29.Models.PlantList> PlantLists { get; set; }

		public DbSet<PlantList> PlantLists { get; set; }

		//public System.Data.Entity.DbSet<Grupp29.Models.Forum> Fora { get; set; }

        public DbSet<Forum> Fora { get; set; }

		//public System.Data.Entity.DbSet<Grupp29.Models.ForumPostCategory> ForumPostCategories { get; set; }
        public DbSet<ForumPostCategory> ForumPostCategories { get; set; }
		
        //public System.Data.Entity.DbSet<Grupp29.Models.ForumPostComment> ForumPostComments { get; set; }
        public DbSet<ForumPostComment> ForumPostComments { get; set; }

		public System.Data.Entity.DbSet<Grupp29.Models.PlantCategory> PlantCategories { get; set; }

        //public System.Data.Entity.DbSet<Grupp29.Models.ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<PlantRoom> PlantRooms { get; set; }

        public System.Data.Entity.DbSet<Grupp29.Models.FAQ> FAQs { get; set; }
    }
}