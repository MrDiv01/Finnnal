using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Member
{
	public class MemberRegisterViewModel
	{
		public string UsrName { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }

		public string Email { get; set; }
		public string FullName { get; set; }

	}
}
