using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public List<CategoryTranslation> Translations { get; set; }
    }
}
