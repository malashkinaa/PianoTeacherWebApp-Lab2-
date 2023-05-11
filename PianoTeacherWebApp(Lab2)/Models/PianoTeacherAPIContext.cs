using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PianoTeacherWebApp_Lab2_.Models;

namespace PianoTeacherWebApp_Lab2_.Models
{
	public class PianoTeacherAPIContext : DbContext
	{
		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<Gender> Genders { get; set; }
		//public virtual DbSet<Student> Parent { get; set; }
		//public virtual DbSet<Teacher> Teacher { get; set; }

		public PianoTeacherAPIContext(DbContextOptions<PianoTeacherAPIContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<PianoTeacherWebApp_Lab2_.Models.Teacher>? Teacher { get; set; }

		public DbSet<PianoTeacherWebApp_Lab2_.Models.Parent>? Parent { get; set; }

	}
}
