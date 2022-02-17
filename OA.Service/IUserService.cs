using OA.Data;
using System.Collections.Generic;

namespace OA.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUser();
        User GetUser(string email);
        bool SaveUser(User user);
        bool DeleteUser(string email);
    }
}
