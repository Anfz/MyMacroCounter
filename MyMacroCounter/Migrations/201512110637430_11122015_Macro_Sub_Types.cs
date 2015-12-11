namespace MyMacroCounter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11122015_Macro_Sub_Types : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MacroSubTypes",
                c => new
                    {
                        MacroSubTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MacroTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MacroSubTypeId)
                .ForeignKey("dbo.MacroTypes", t => t.MacroTypeId, cascadeDelete: true)
                .Index(t => t.MacroTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MacroSubTypes", "MacroTypeId", "dbo.MacroTypes");
            DropIndex("dbo.MacroSubTypes", new[] { "MacroTypeId" });
            DropTable("dbo.MacroSubTypes");
        }
    }
}
