using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebApplication1.DAL.Models;

namespace WebApplication1.DAL.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenaricRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync(string[]? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
           
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Remove(entity);
           var affected= await _context.SaveChangesAsync();
            return affected>0;
        }
        public async Task<T> GetOne(Expression<Func<T, bool>> filter, string[]? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
             return await query.FirstOrDefaultAsync(filter);
            
        }
    }
}
