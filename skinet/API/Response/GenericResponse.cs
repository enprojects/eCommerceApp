using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Response
{
    public class GenericResponse<T> 
    {

         
        public IEnumerable<T> Data{ get; set; }
        public int Count { get; set; }
        public int  PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
