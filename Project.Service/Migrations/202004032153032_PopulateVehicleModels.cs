namespace Project.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicleModels : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[VehicleModel](MakeId,Name,Abrv) VALUES (1, '128','BMW')");
            Sql("INSERT INTO [dbo].[VehicleModel](MakeId,Name,Abrv) VALUES (1, '325', 'BMW')");
            Sql("INSERT INTO [dbo].[VehicleModel](MakeId,Name,Abrv) VALUES (1, 'X5', 'BMW')");
        }
        
        public override void Down()
        {
        }
    }
}
