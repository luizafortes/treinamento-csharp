using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contracts
{
    public interface IBaseRepository<T>
        where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAll();
        T GetById(int id);
    }
}
