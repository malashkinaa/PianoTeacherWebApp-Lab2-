using Microsoft.EntityFrameworkCore;
using PianoTeacherWebApp_Lab2_.Controllers;
using PianoTeacherWebApp_Lab2_.Models;

namespace PianoWebAppTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var options = new DbContextOptionsBuilder<PianoTeacherAPIContext>().UseMemoryCache
			.Options;

			dbContext = new ApplicationDbContext(options);

			GendersController genders = new GendersController();
		}
	}
}