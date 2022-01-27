using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchForum.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetN(int n);

        Task<T> GetById(int id);

        T Add(T item);

        Task<bool> Delete(T item);

        T Update(T item);
    }
}