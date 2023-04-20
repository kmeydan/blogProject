using Microsoft.AspNetCore.Identity;

namespace Straßenkarte.CustomValidation
{
	public class IdentityErrorDescriberCustom:IdentityErrorDescriber
	{
		//User
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
				{ Code = "PasswordRequiresDigit", Description = "Parolanız minimum 1 adet Sayı içermelidir." };
		}
		
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError
				{ Code = "DuplicateEmail", Description = $"{email} Bu E-Posta adresi kullanılmaktadır." };
		}
		public override IdentityError InvalidEmail(string email)
		{
			return new IdentityError
				{ Code = "InvalidEmail", Description = $"{email} Bu E-Posta adresi geçersiz!" };
		}

		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError
				{ Code = "DuplicateUserName", Description = $"{userName} Bu Kullanıcı Adı mevcut!" };
		}

		public override IdentityError InvalidUserName(string userName)
		{
			return new IdentityError
				{ Code = "InvalidUserName", Description = $"{userName} Bu Kullanıcı Adı geçersiz!" };
		}

		//Password
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
				{ Code = "PasswordTooShort", Description = $"Şifreniz en az {length} karakter olmalıdır." };
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError { Code = "PasswordRequiresLower", Description = "Şifreniz de en az 1 adet küçük harf olmalıdır" };
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError { Code = "PasswordRequiresUpper", Description = "Şifrenizde en az 1 adet büyük harf bulundurmalısınız." };
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError { Code = "PasswordRequiresNonAlphanumeric", Description = "Şifrenizde en az 1 adet özel karakter kullanmalısınız" };
		}
	}
}
