using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.DAL.DTOs.Response
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public List<CategoryTranslationResponse> Translations { get; set; }
    }
}
