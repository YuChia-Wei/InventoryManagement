using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InventoryManagement.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 新增一個entity
        /// </summary>
        /// <param name="entity"></param>
        (bool result, string message) Create(T entity);

        /// <summary>
        /// 刪除單一entity
        /// </summary>
        /// <param name="entity"></param>
        (bool result, string message) Delete(T entity);

        /// <summary>
        /// 取得單一 entity
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T GetSingle(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Lookups all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IEnumerable<T> LookUpAll();

        /// <summary>
        /// 搜尋
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 更新一個entity
        /// </summary>
        /// <param name="entity"></param>
        (bool result, string message) Update(T entity);
    }
}