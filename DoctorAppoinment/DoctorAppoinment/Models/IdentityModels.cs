using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DoctorAppoinment.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<DoctorInfo> DoctorInfoes { get; set; }
        public DbSet<CountryInfo> CountryInfoes { get; set; }
        public DbSet<DistrictInfo> DistrictInfoes { get; set; }
        public DbSet<ThanaInfo> ThanaInfoes { get; set; }
        public DbSet<PatientInfo> PatientInfoes { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<DoctorAppoinment> DoctorAppoinments { get; set; }
        public DbSet<CategoryInfo> CategoryInfoes { get; set; }
        public DbSet<SubcategoryInfo> SubcategoryInfoes { get; set; }
        public DbSet<DiagnosticTestInfo> DiagnosticTestInfoe { get; set; }
        public DbSet<MedicineGroup> MedicineGroupInfoes { get; set; }
        public DbSet<medicineInfo> MedicineInfoes { get; set; }
    }
}