using Domain.Entities;

namespace Domain.Services.Interface
{
    public interface IUserService : IServiceBase
    {
        public User GetUser(int id);
    }
}
