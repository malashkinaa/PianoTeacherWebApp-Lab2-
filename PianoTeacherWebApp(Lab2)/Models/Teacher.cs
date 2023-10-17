using Microsoft.EntityFrameworkCore;

namespace PianoTeacherWebApp_Lab2_.Models
{
	public class Teacher
	{
        public Teacher() 
		{
			Students = new List<Student>();
		}
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Student> Students { get; set; }

	}
}
