using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Dtos.ProductService
{
    public class GetAllProductsResult
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
    }
}
