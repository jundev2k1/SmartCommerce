using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.User
{
    public interface IUserRepository
    {
        public UserModel[] Search(Dictionary<string, string> searchParams);

        public UserModel? Get(string userId);

        public UserModel? GetByUserName(string username);

        public UserModel[] GetAll();

        public bool Insert(UserModel model);

        public bool Update(UserModel model);

        public bool Delete(string userId);
    }
}
