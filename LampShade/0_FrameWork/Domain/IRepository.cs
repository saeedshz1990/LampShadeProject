using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_FrameWork.Domain
{

    //TKey===>its type Id and T===> its type entity
    public interface IRepository <TKey , T> where T : class
    {
        T Get(TKey id);
        List<T> Get();
        void Create(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
