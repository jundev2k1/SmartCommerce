using Persistence.Services;

namespace Persistence.Common
{
    public interface IServices
    {
        IUserService Users { get; }
    }
}
