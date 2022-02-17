using OA.Data;
using System.Collections.Generic;

namespace OA.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(string email);
        bool Save(T data);
        bool Delete(string email);
    }
}
