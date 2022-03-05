namespace QaxMMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        customer_Id = c.Int(),
                        sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_Id)
                .ForeignKey("dbo.Sale_Table", t => t.sale_Id)
                .Index(t => t.customer_Id)
                .Index(t => t.sale_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credits", "sale_Id", "dbo.Sale_Table");
            DropForeignKey("dbo.Credits", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Credits", new[] { "sale_Id" });
            DropIndex("dbo.Credits", new[] { "customer_Id" });
            DropTable("dbo.Credits");
        }
    }
}
