using FinalExam.Data;
using FinalExam.Helper;
using FinalExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class WorkController : Controller
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly IWebHostEnvironment _env;

		public WorkController(ApplicationDbContext applicationDbContext,IWebHostEnvironment env)
		{
			_applicationDbContext = applicationDbContext;
			_env = env;
		}
		public IActionResult Index()
		{
			List<Work> works = _applicationDbContext.Works.Include(x => x.Jobs).ToList();
			return View(works);
		}
		public IActionResult Create()
		{
			ViewBag.Job = _applicationDbContext.Jobs.ToList();
			return View();
		}
		[HttpPost]
		public IActionResult Create(Work work)
		{

			ViewBag.Job = _applicationDbContext.Jobs.ToList();
				work.Image = FiileManage.SaveFile(_env.WebRootPath, "aploads/workersimages", work.ImageFile);
			_applicationDbContext.Works.Add(work);
			_applicationDbContext.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Update(int Id)
		{
			ViewBag.Job = _applicationDbContext.Jobs.ToList();
			Work work = _applicationDbContext.Works.Find(Id);
			return View(work);
		}
		[HttpPost]
		public IActionResult Update(Work work)
		{
			ViewBag.Job = _applicationDbContext.Jobs.ToList();
			Work upwork = _applicationDbContext.Works.Find(work.Id);
			if (work.ImageFile != null)
			{
				string name = FiileManage.SaveFile(_env.WebRootPath, "aploads/workersimages", work.ImageFile);
				upwork.Image = name;
			}
			upwork.JobId = work.JobId;
			upwork.Image = work.Image;
			upwork.Description = work.Description;
			_applicationDbContext.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int Id)
		{
			Work workwork = _applicationDbContext.Works.Find(Id);
			_applicationDbContext.Works.Remove(workwork);
			_applicationDbContext.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
