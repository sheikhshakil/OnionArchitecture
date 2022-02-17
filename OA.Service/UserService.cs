using OA.Data;
using OA.Repo;
using System.Collections.Generic;

namespace OA.Service
{
    public class UserService : IUserService
    {
        private Repository<User> repo;
        public UserService()
        {
            repo = new Repository<User>("users");
        }

        public IEnumerable<User> GetAllUser()
        {
            return repo.GetAll();
        }

        public User GetUser(string email)
        {
            return repo.Get(email);
        }

        public bool SaveUser(User user)
        {
            return repo.Save(user);
        }

        public bool DeleteUser(string email)
        {
            return repo.Delete(email);
        }
    }
}
