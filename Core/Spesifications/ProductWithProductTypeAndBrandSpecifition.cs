using Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spesifications
{
    public class ProductWithProductTypeAndBrandSpecifition : BaseSpesifications<Product>
    {
        public ProductWithProductTypeAndBrandSpecifition()
        {
            AddInclude(x => x.ProductBrands);
            AddInclude(x => x.ProductType);
        }
        public ProductWithProductTypeAndBrandSpecifition(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrands);
            AddInclude(x => x.ProductType);
        }
    }
}
