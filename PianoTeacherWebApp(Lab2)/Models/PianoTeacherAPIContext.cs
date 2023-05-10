using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace PianoTeacherWebApp_Lab2_.Models
{
	public class PianoTeacherAPIContext : DbContext
	{
		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<Gender> Genders { get; set; }

		public PianoTeacherAPIContext(DbContextOptions<PianoTeacherAPIContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
