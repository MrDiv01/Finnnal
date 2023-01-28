using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models
{
	public class Work
	{
		public int Id { get; set; }
		public string Image { get; set; }
		[NotMapped]
		public IFormFile ImageFile { get; set; }
		public string Description { get; set; }
		public int JobId { get; set; }
		public Job Jobs { get; set; }
	}
}
