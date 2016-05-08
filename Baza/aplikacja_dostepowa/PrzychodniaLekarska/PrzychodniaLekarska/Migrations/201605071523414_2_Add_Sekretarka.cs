namespace PrzychodniaLekarska.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2_Add_Sekretarka : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sekretarka",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        MailAddress = c.String(),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sekretarka");
        }
    }
}
