namespace Arthesanatus2021.AppMvc.Migrations
{
    using System.Data.Entity.Migrations;

    using Arthesanatus2021.AppMvc.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

    }
}
