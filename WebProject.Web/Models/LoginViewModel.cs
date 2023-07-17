using System.ComponentModel.DataAnnotations;

namespace WebProject.Web.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email Adresi boş Bırakılamaz")]
		[RegularExpression(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Hatalı Email")]
		//Emaildeki Karakterlerin controlünü yapar doğru razılıp yazılmadıgını Regex adı verilir
		public string Email { get; set; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Şifre Giriniz"),MaxLength(12, ErrorMessage = "12 Karakterden uzun olamaz")]
		public string Password { get; set; }

	}
}
