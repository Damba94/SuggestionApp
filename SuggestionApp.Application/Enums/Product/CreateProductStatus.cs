using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Enums.Product
{
    public enum CreateProductStatus
    {
        Success,           
        AlreadyExists,     
        InvalidData,       
        Failure            
    }
}
