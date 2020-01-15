﻿namespace MatchService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stadium", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stadium", "Name");
        }
    }
}
