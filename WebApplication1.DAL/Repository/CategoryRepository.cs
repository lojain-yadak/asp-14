using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;
using WebApplication1.DAL.Models;

namespace WebApplication1.DAL.Repository
{
    public class CategoryRepository : GenaricRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
     }
}