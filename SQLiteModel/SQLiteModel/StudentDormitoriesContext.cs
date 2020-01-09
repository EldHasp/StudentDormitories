using System.Data.Entity;

namespace SQLiteModel
{
    public class StudentDormitoriesContext : DbContext
    {
        public StudentDormitoriesContext() : base("DefaultConnection")
        {
        }
        public DbSet<RoomBD> Rooms { get; set; }
        public DbSet<DormitoryBD> Dormitories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Room>().ToTable("Rooms");
        //    modelBuilder.Entity<Dormitory>().ToTable("Dormitories");
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
