namespace ProjectSemIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Newss", "Tittle", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Newss", "Tittle", c => c.Int(nullable: false));
        }
    }
}
