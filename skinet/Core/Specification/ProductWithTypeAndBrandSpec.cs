using Core.Entities;
using Core.Specification.Request;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Core.Specification
{
    public class ProductWithTypeAndBrandSpec : BaseSpecificationcs<Product>
    {

        public ProductWithTypeAndBrandSpec(ProductSpecParams productParams)
            :base(x=> (string.IsNullOrEmpty(productParams.Search) || x.Name.Contains(productParams.Search)) &&
                      (!productParams.BrandId.HasValue ||  x.ProductBrandId == productParams.BrandId))
        {
            Expression<Func<Product, object>> func = (x) => x.Name;
            AddOrderBy(func);

            switch (productParams.Sort)
            {
                case "price":
                    func = (x) => x.Price;
                    break;
            }

            if (productParams.Order == "desc")
            {
                AddOrderByDesc(func);
            }
          
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

            PageNumber = productParams.PageIndex;
            NumberOfRows = productParams.PageSize;
        }

        public ProductWithTypeAndBrandSpec(int id) :
            base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }


}
