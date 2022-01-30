using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchForum.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetN(int n);

        T GetById(int id);

        T Add(T item);

        bool Delete(T item);

        T Update(T item);
    }
}