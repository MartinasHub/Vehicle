namespace Project.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicleMakes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[VehicleMake] (Name, Abrv) VALUES ('BMW', 'BMW')");
            Sql("INSERT INTO [dbo].[VehicleMake] (Name, Abrv) VALUES ('Ford', 'Ford')");
            Sql("INSERT INTO [dbo].[VehicleMake] (Name, Abrv) VALUES ('Volkswagen', 'Volkswagen')");

        }

        public override void Down()
        {
        }
    }
}
