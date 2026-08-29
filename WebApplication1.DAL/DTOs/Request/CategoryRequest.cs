using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.DAL.DTOs.Request
{
    public class CategoryRequest
    {
        public List<CategoryTranslationRequest> Translations { get; set; }
    }
}
