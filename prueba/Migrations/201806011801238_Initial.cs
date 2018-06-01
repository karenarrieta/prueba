namespace prueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "TypeId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "TypeId", c => c.Int(nullable: false));
        }
    }
}
