using Arthesanatus2021.Infra.Data.Context;

using System.Data.Entity.Migrations;

namespace Arthesanatus2021.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Arthesanatus2021Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
