using Core.Specification.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductWithTypeAndBrandSpecCount : ProductWithTypeAndBrandSpec
    {
        public ProductWithTypeAndBrandSpecCount(ProductSpecParams productParams)
            : base(productParams)
        {
            IsPagingEnable = false;
        }
    }
}
