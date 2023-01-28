using FinalExam.Data;
using FinalExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class JobController : Controller
	{
		private readonly ApplicationDbContext _applicationDbContext;
		public JobController(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public IActionResult Index()
		{
			List<Job> jobs = _applicationDbContext.Jobs.ToList();
			return View(jobs);
		}
		[HttpGet]
		public  IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public  IActionResult Create(Job job)
		{
			_applicationDbContext.Jobs.Add(job);
			_applicationDbContext.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Update(int Id)
		{
			Job job = _applicationDbContext.Jobs.Find(Id);
			return View(job);
		}
		[HttpPost]
		public IActionResult Update(Job job)
		{
			Job Upjob = _applicationDbContext.Jobs.Find(job.Id);
			Upjob.Name = job.Name;
			_applicationDbContext.SaveChanges();
			return RedirectToAction("Index");

		}
		public IActionResult Delete(int Id)
		{
			Job job = _applicationDbContext.Jobs.Find(Id);
			_applicationDbContext.Jobs.Remove(job);
			_applicationDbContext.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
