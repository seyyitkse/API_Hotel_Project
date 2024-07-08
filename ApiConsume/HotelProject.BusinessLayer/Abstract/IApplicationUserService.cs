using HotelProject.DtoLayer.AuthDto;
using HotelProject.DtoLayer.Response.User;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IApplicationUserService:IGenericService<AppUser>
    {
        Task<UserManagerResponse> RegisterUserAsync(UserAddDto model);
    }
}
