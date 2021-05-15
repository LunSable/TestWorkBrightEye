namespace TestWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTwoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SortNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number_Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SortNumbers");
        }
    }
}
