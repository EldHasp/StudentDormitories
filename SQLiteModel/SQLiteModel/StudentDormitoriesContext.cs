using System.Data.Entity;

namespace SQLiteModel
{
    public class StudentDormitoriesContext : DbContext
    {
        public StudentDormitoriesContext() : base("DefaultConnection") { }
        public StudentDormitoriesContext(string connectionName) : base(connectionName) { }

        public DbSet<RoomBD> Rooms { get; set; }
        public DbSet<DormitoryBD> Dormitories { get; set; }
    }
}
