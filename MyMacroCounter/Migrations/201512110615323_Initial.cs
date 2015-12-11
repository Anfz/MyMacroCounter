namespace MyMacroCounter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MacroTypes",
                c => new
                    {
                        MacroTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CaloriePerGram = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MacroTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MacroTypes");
        }
    }
}
