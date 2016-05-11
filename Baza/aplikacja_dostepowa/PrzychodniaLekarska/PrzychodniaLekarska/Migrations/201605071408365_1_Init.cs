namespace PrzychodniaLekarska.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1_Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pacjent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        MailAddress = c.String(),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                        Pesel = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pacjent");
        }
    }
}
