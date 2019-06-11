namespace _07EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCityToStuden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "City");
        }
    }
}
