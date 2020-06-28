namespace ProjectSemIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Bank_BankId", "dbo.Banks");
            DropIndex("dbo.Customers", new[] { "Bank_BankId" });
            DropColumn("dbo.Customers", "Bank_BankId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Bank_BankId", c => c.Int());
            CreateIndex("dbo.Customers", "Bank_BankId");
            AddForeignKey("dbo.Customers", "Bank_BankId", "dbo.Banks", "BankId");
        }
    }
}
