using System.ComponentModel.DataAnnotations;

namespace Straßenkarte.Models.ViewModels
{
	public class AdminUserViewModel
	{
		public string Id{ get; set; }
		[Display(Name = "E-Posta")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız.")]
		[EmailAddress(ErrorMessage = "Lütfen geçerli bir {0} giriniz!")]
		public string Email { get; set; }
		[Display(Name = "Kullanıcı Adı")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız.")]
		public string Username { get; set; }
		[Display(Name = "Parola")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Parola Tekrarı")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız.")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password),ErrorMessage = "Parolalar uyuşmuyor")]
		public string RePassword { get; set; }
		public string Category { get; set; }
		[Display(Name = "Telefon Numarası")]
		[Required(ErrorMessage ="{0} alanını boş bırakmayınız.")]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }


	}
}
