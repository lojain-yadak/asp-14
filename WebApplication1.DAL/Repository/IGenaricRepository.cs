using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebApplication1.DAL.Models;

namespace WebApplication1.DAL.Repository
{
    public interface IGenaricRepository<T> where T : class
    {
         Task<List<T>> GetAllAsync(string[]? include = null);
        Task<T> CreateAsync(T entity);
        Task<T> GetOne(Expression<Func<T, bool>> filter, string[]? includes = null);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
