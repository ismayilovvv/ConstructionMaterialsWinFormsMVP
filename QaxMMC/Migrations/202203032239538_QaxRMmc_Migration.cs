namespace QaxMMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QaxRMmc_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConstructionMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        En = c.Single(),
                        Uzunluq = c.Single(),
                        Hundurluk = c.Single(),
                        Eded = c.Int(),
                        Kub = c.Single(),
                        Kvadrat = c.Single(),
                        Nomre = c.Short(),
                        Nov = c.String(),
                        date = c.DateTime(nullable: false),
                        Mebleg = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Lastname = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        RegisterAddress = c.String(),
                        BornAddress = c.String(),
                        PassportSeriaNumber = c.String(),
                        PassportFIN = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Company = c.String(),
                        CompanyAddress = c.String(),
                        VOEN = c.String(),
                        Bank = c.String(),
                        AccountNumber = c.String(),
                        Account = c.String(),
                        Code = c.String(),
                        Swift = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sale_Table",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        saleDate = c.DateTime(nullable: false),
                        sum = c.Single(nullable: false),
                        Ad = c.String(nullable: false),
                        En = c.Single(),
                        Uzunluq = c.Single(),
                        Hundurluk = c.Single(),
                        Miqdar = c.Int(),
                        Kub = c.Single(),
                        Kvadrat = c.Single(),
                        Nomre = c.Short(),
                        Nov = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sale_Table");
            DropTable("dbo.Customers");
            DropTable("dbo.ConstructionMaterials");
        }
    }
}
