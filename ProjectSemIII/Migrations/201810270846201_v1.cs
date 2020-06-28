namespace ProjectSemIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password = c.String(nullable: false, maxLength: 256, unicode: false),
                        FullName = c.String(nullable: false, maxLength: 60),
                        Address = c.String(maxLength: 512),
                        Sex = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Role = c.Int(nullable: false),
                        Avartar = c.String(),
                        UIDcode = c.String(),
                        DateCreate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Newss",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.Int(nullable: false),
                        Desciption = c.String(maxLength: 516),
                        Content = c.String(storeType: "ntext"),
                        Image = c.String(),
                        Keyword = c.String(maxLength: 250),
                        DateWirite = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Adss",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        AdsLink = c.String(),
                        Description = c.String(storeType: "ntext"),
                        Location = c.Int(nullable: false),
                        StatusOn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 250),
                        AuthorPhone = c.String(maxLength: 50),
                        AuthorEmail = c.String(maxLength: 150, unicode: false),
                        AuthorAddress = c.String(),
                        AuthorInfor = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.String(nullable: false, maxLength: 5),
                        BookName = c.String(nullable: false, maxLength: 250),
                        CategoryId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        PublishingYear = c.Int(),
                        Sale = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Description = c.String(storeType: "ntext"),
                        BookImage1 = c.String(maxLength: 512),
                        BookImage2 = c.String(maxLength: 512),
                        BookImage3 = c.String(maxLength: 512),
                        StatusAvarible = c.Int(nullable: false),
                        StatusOn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.BookName, unique: true, name: "Ix_Book")
                .Index(t => t.CategoryId)
                .Index(t => t.PublisherId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 150),
                        CatgoryIdParent = c.Int(nullable: false),
                        Note = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BookId = c.String(maxLength: 5),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        SubTotal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        TransitionId = c.Int(nullable: false),
                        ShippingId = c.Int(nullable: false),
                        Note = c.String(),
                        DateOrder = c.DateTime(nullable: false),
                        TotalPayment = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ShippingMethods", t => t.ShippingId, cascadeDelete: true)
                .ForeignKey("dbo.TransitionMethods", t => t.TransitionId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TransitionId)
                .Index(t => t.ShippingId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password = c.String(nullable: false, maxLength: 256, unicode: false),
                        FullName = c.String(nullable: false, maxLength: 60),
                        Address = c.String(maxLength: 512),
                        Sex = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EMoney = c.Single(),
                        Avartar = c.String(),
                        UIDcode = c.String(),
                        Bank_BankId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Banks", t => t.Bank_BankId)
                .Index(t => t.Bank_BankId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        BankName = c.String(nullable: false, maxLength: 250),
                        StringBankSevice = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 250),
                        BankPhone = c.String(),
                        BankEmail = c.String(),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.ListBankEBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        AcBank = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.MessageTransitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Description = c.String(),
                        Amount = c.Single(nullable: false),
                        AccountHoder = c.Single(nullable: false),
                        TimeTrans = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ShippingMethods",
                c => new
                    {
                        ShippingId = c.Int(nullable: false, identity: true),
                        ShippingName = c.String(nullable: false, maxLength: 60),
                        Cost = c.Single(nullable: false),
                        Description = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.ShippingId);
            
            CreateTable(
                "dbo.TransitionMethods",
                c => new
                    {
                        TransitionId = c.Int(nullable: false, identity: true),
                        TransitionName = c.String(nullable: false, maxLength: 60),
                        Description = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.TransitionId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(nullable: false, maxLength: 150),
                        PublisherPhone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 150, unicode: false),
                        PublisherAddress = c.String(maxLength: 250),
                        Note = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            CreateTable(
                "dbo.Slideshows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Image4 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "TransitionId", "dbo.TransitionMethods");
            DropForeignKey("dbo.Orders", "ShippingId", "dbo.ShippingMethods");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MessageTransitions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Bank_BankId", "dbo.Banks");
            DropForeignKey("dbo.ListBankEBook", "BankId", "dbo.Banks");
            DropForeignKey("dbo.OrderDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Newss", "AdminId", "dbo.Admins");
            DropIndex("dbo.MessageTransitions", new[] { "CustomerId" });
            DropIndex("dbo.ListBankEBook", new[] { "BankId" });
            DropIndex("dbo.Customers", new[] { "Bank_BankId" });
            DropIndex("dbo.Orders", new[] { "ShippingId" });
            DropIndex("dbo.Orders", new[] { "TransitionId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "BookId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Books", "Ix_Book");
            DropIndex("dbo.Newss", new[] { "AdminId" });
            DropTable("dbo.Slideshows");
            DropTable("dbo.Publishers");
            DropTable("dbo.TransitionMethods");
            DropTable("dbo.ShippingMethods");
            DropTable("dbo.MessageTransitions");
            DropTable("dbo.ListBankEBook");
            DropTable("dbo.Banks");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Adss");
            DropTable("dbo.Newss");
            DropTable("dbo.Admins");
        }
    }
}
