using Microsoft.AspNetCore.Http;
using System.IO;

namespace FinalExam.Helper
{
	public class FiileManage
	{
		public static string SaveFile(string path, string folderpath,IFormFile formFile)
		{
			string FileName = formFile.FileName;
			FileName = FileName.Length > 64 ? FileName.Substring(FileName.Length - 64, 64) : FileName;
			FileName = Guid.NewGuid().ToString() + FileName;
			string pathh = Path.Combine(path, folderpath, FileName);
			using (FileStream filestream = new FileStream(pathh, FileMode.Create))
			{
				formFile.CopyTo(filestream);
			}
			return FileName;
		}
		public static void DeleteFile(string path, string folderpath, string formFile)
		{
			string deletePath = Path.Combine(path, folderpath, formFile);
			if (System.IO.File.Exists(deletePath))
			{
				System.IO.File.Delete(deletePath);
			}
		}
	}
}
