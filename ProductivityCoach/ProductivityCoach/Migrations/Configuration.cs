namespace ProductivityCoach.Migrations
{
    using ProductivityCoach.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductivityCoach.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProductivityCoach.Models.ApplicationDbContext";
        }

        protected override void Seed(ProductivityCoach.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            var user = new ApplicationUser()
            {
                UserName = "ESimpson",
                Email = "ejsimpson0228@gmail.com"
            };

            userMgr.Create(user, "Password123#");

            var user2 = new ApplicationUser()
            {
                UserName = "ASimpson",
                Email = "aesimpson1128@gmail.com"
            };

            userMgr.Create(user2, "Password123#");
        }
    }
}
