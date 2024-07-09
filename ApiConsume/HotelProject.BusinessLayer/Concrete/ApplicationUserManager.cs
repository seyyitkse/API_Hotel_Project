using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.AuthDto;
using HotelProject.DtoLayer.Response.User;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ApplicationUserManager : IApplicationUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ApplicationUserManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserManagerResponse> LoginUserAsync(UserLoginDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            // Kullanıcıyı e-posta adresine göre bul
            var user = await _userManager.FindByEmailAsync(model.Mail);
            if (user == null)
            {
                // Kullanıcı bulunamazsa hata döndür
                return new UserManagerResponse
                {
                    Message = "Bu maile sahip bir kullanıcı bulunamadı!",
                    IsSuccess = false
                };
            }

            // Kullanıcının parolasını doğrula
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Giriş başarılı ise başarılı yanıt döndür
                return new UserManagerResponse
                {
                    Message = "Giriş başarılı!",
                    IsSuccess = true
                };
            }
            else
            {
                // Parola doğrulaması başarısız ise hata döndür
                return new UserManagerResponse
                {
                    Message = "Geçersiz şifre",
                    IsSuccess = false
                };
            }
        }

        public async Task<UserManagerResponse> RegisterUserAsync(UserAddDto model)
        {
            if (model == null)
                throw new NullReferenceException("Boş veriler var");

            if (model.Password != model.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "Girdiğiniz parolalar eşleşmiyor.",
                    IsSuccess = false,
                };
            }

            var existingUserByEmail = await _userManager.FindByEmailAsync(model.Mail);
            if (existingUserByEmail != null)
            {
                return new UserManagerResponse
                {
                    Message = "Bu e-posta adresiyle kayıtlı bir kullanıcı zaten var.",
                    IsSuccess = false
                };
            }

            var user = new AppUser
            {
                UserName = model.Mail,
                Email = model.Mail,
                Name = model.Name,
                Surname = model.Surname,
                City = model.City
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Kullanıcı oluşturma işlemi başarıyla gerçekleştirildi.",
                    IsSuccess = true,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }

            return new UserManagerResponse
            {
                Message = "Kullanıcı oluşturulamadı!",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }


        public void TDelete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
