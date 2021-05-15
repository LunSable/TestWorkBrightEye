namespace TestWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Numbers",
                c => new
                    {
                        NumberId = c.Int(nullable: false, identity: true),
                        Number_Rand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Numbers");
        }
    }
}
