using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace PianoTeacherWebApp_Lab2_.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int GenderId { get; set; }
		public int Age { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
        public string AdditionalInfo { get; set; }

		public int TeacherId { get; set; }

		public int ParentId { get; set; }
	}
}
