namespace MyWorkoutLog.UI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyWorkoutLog.UI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyWorkoutLog.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyWorkoutLog.UI.Models.ApplicationDbContext context)
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var testUser = new ApplicationUser()
            {
                UserName = "test@test.com",
                Email = "test@test.com"
            };

            userMgr.Create(testUser, "123456789");
        }
    }
}
