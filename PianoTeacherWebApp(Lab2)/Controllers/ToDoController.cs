using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PianoTeacherWebApp_Lab2_.Controllers
{
	public class ToDoController : Controller
	{
		// GET: ToDo
		public ActionResult Index()
		{
			return View();
		}

		// GET: ToDo/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ToDo/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ToDo/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ToDo/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ToDo/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ToDo/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ToDo/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
