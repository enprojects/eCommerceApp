using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification.Request
{

    public class ProductSpecParams : BaseSpecRequest
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

    }
}
