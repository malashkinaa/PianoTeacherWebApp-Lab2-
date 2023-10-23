using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PianoTeacherWebApp_Lab2_.Models;

namespace PianoTeacherWebApp_Lab2_.Data
{
    public class PianoTeacherDBContext : IdentityDbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        //public virtual DbSet<Student> Parent { get; set; }
        //public virtual DbSet<Teacher> Teacher { get; set; }

        public PianoTeacherDBContext(DbContextOptions<PianoTeacherDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Teacher>? Teacher { get; set; }

        public DbSet<Parent>? Parent { get; set; }

    }
}
