using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specification
{
   public  class BrandWithTypeSpec : BaseSpecificationcs<Product>
    {
        
        public BrandWithTypeSpec(int id) :
            base(x=>x.ProductBrandId==id /*&& x.Name  == "Eyal best prodhhh"*/)
        {
 
        }


       
    }
}
