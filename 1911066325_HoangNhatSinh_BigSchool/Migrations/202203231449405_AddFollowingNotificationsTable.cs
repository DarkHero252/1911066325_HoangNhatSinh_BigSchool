namespace _1911066325_HoangNhatSinh_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingNotificationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FollowingNotifications",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Logger = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.FollowingNotifications");
        }
    }
}
