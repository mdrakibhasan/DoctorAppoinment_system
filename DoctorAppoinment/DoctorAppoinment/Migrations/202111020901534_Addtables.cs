namespace DoctorAppoinment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(),
                        Code = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CountryInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiagnosticTestInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(),
                        CategoryInfoId = c.String(),
                        SubcategoryInfoId = c.String(),
                        Code = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                        CategoryInfo_Id = c.Int(),
                        SubcategoryInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryInfoes", t => t.CategoryInfo_Id)
                .ForeignKey("dbo.SubcategoryInfoes", t => t.SubcategoryInfo_Id)
                .Index(t => t.CategoryInfo_Id)
                .Index(t => t.SubcategoryInfo_Id);
            
            CreateTable(
                "dbo.SubcategoryInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(),
                        CategoryInfoId = c.String(),
                        Code = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                        CategoryInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryInfoes", t => t.CategoryInfo_Id)
                .Index(t => t.CategoryInfo_Id);
            
            CreateTable(
                "dbo.DistrictInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        Code = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorAppoinments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                        FatherName = c.String(),
                        AppoinmentNo = c.String(),
                        AppoinmentDate = c.DateTime(nullable: false),
                        SerialNo = c.String(),
                        DoctorInfoId = c.Int(nullable: false),
                        Address = c.String(),
                        Gender = c.String(),
                        PatientHistory = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.Int(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInfoes", t => t.DoctorInfoId, cascadeDelete: true)
                .Index(t => t.DoctorInfoId);
            
            CreateTable(
                "dbo.DoctorInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(nullable: false),
                        MobileNo = c.String(),
                        Email = c.String(),
                        DistrictInfoID = c.Int(nullable: false),
                        ThanaInfoId = c.Int(nullable: false),
                        Address = c.String(),
                        CountryInfoId = c.Int(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.Int(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryInfoes", t => t.CountryInfoId, cascadeDelete: true)
                .ForeignKey("dbo.DistrictInfoes", t => t.DistrictInfoID, cascadeDelete: true)
                .ForeignKey("dbo.ThanaInfoes", t => t.ThanaInfoId, cascadeDelete: true)
                .Index(t => t.CountryInfoId)
                .Index(t => t.DistrictInfoID)
                .Index(t => t.ThanaInfoId);
            
            CreateTable(
                "dbo.ThanaInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(),
                        Code = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicineGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddBy = c.Int(nullable: false),
                        AddDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.Int(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.medicineInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MedicineGroupId = c.Int(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.Int(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicineGroups", t => t.MedicineGroupId, cascadeDelete: true)
                .Index(t => t.MedicineGroupId);
            
            CreateTable(
                "dbo.PatientInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(nullable: false),
                        MobileNo = c.String(),
                        Email = c.String(),
                        DistrictInfoId = c.Int(nullable: false),
                        ThanaInfoId = c.Int(nullable: false),
                        Address = c.String(),
                        Address2 = c.String(),
                        CountryInfoId = c.Int(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        PatientHistory = c.String(),
                        AddBy = c.Int(),
                        AddDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.Int(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryInfoes", t => t.CountryInfoId, cascadeDelete: true)
                .ForeignKey("dbo.DistrictInfoes", t => t.DistrictInfoId, cascadeDelete: true)
                .ForeignKey("dbo.ThanaInfoes", t => t.ThanaInfoId, cascadeDelete: true)
                .Index(t => t.CountryInfoId)
                .Index(t => t.DistrictInfoId)
                .Index(t => t.ThanaInfoId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PatientInfoes", "ThanaInfoId", "dbo.ThanaInfoes");
            DropForeignKey("dbo.PatientInfoes", "DistrictInfoId", "dbo.DistrictInfoes");
            DropForeignKey("dbo.PatientInfoes", "CountryInfoId", "dbo.CountryInfoes");
            DropForeignKey("dbo.medicineInfoes", "MedicineGroupId", "dbo.MedicineGroups");
            DropForeignKey("dbo.DoctorAppoinments", "DoctorInfoId", "dbo.DoctorInfoes");
            DropForeignKey("dbo.DoctorInfoes", "ThanaInfoId", "dbo.ThanaInfoes");
            DropForeignKey("dbo.DoctorInfoes", "DistrictInfoID", "dbo.DistrictInfoes");
            DropForeignKey("dbo.DoctorInfoes", "CountryInfoId", "dbo.CountryInfoes");
            DropForeignKey("dbo.DiagnosticTestInfoes", "SubcategoryInfo_Id", "dbo.SubcategoryInfoes");
            DropForeignKey("dbo.SubcategoryInfoes", "CategoryInfo_Id", "dbo.CategoryInfoes");
            DropForeignKey("dbo.DiagnosticTestInfoes", "CategoryInfo_Id", "dbo.CategoryInfoes");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.PatientInfoes", new[] { "ThanaInfoId" });
            DropIndex("dbo.PatientInfoes", new[] { "DistrictInfoId" });
            DropIndex("dbo.PatientInfoes", new[] { "CountryInfoId" });
            DropIndex("dbo.medicineInfoes", new[] { "MedicineGroupId" });
            DropIndex("dbo.DoctorAppoinments", new[] { "DoctorInfoId" });
            DropIndex("dbo.DoctorInfoes", new[] { "ThanaInfoId" });
            DropIndex("dbo.DoctorInfoes", new[] { "DistrictInfoID" });
            DropIndex("dbo.DoctorInfoes", new[] { "CountryInfoId" });
            DropIndex("dbo.DiagnosticTestInfoes", new[] { "SubcategoryInfo_Id" });
            DropIndex("dbo.SubcategoryInfoes", new[] { "CategoryInfo_Id" });
            DropIndex("dbo.DiagnosticTestInfoes", new[] { "CategoryInfo_Id" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PatientInfoes");
            DropTable("dbo.medicineInfoes");
            DropTable("dbo.MedicineGroups");
            DropTable("dbo.ThanaInfoes");
            DropTable("dbo.DoctorInfoes");
            DropTable("dbo.DoctorAppoinments");
            DropTable("dbo.DistrictInfoes");
            DropTable("dbo.SubcategoryInfoes");
            DropTable("dbo.DiagnosticTestInfoes");
            DropTable("dbo.CountryInfoes");
            DropTable("dbo.CategoryInfoes");
        }
    }
}
