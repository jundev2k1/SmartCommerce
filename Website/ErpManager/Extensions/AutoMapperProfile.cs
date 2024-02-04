using AutoMapper;
using Domain.Models;
using ErpManager.Web.ViewModels;

namespace ErpManager.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, LoginViewModel>();
        }
    }
}
