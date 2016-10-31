using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Repository.Abstract {
    public interface IRepository<T>: IDisposable {
        void Add(T item);
        void Edit(T item);
        T Delete(string id);
        T FindById(string id);
        IEnumerable<T> Get();
    }
}
