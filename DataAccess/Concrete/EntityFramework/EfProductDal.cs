using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        //IProductDal içindeki tüm operasyonlar, EfEntityRepositoryBase<Product,NorthwindContext> içinde tanımlıdır.
        //O zaman IProductDal' a ne gerek var gibi düşünülebilir ama Producta'a özel operasyonlar IProductDal içinde tanımlayacağız
        public List<ProductDetailDto> GetProductDetails()
        {
            //join işlemi
            using (NorthwindContext context= new NorthwindContext())
            {
                var result = from p in context.products
                             join c in context.categories
                             on p.category_id equals c.category_id
                             select new ProductDetailDto {
                                 product_id = p.product_id,
                                 product_name = p.product_name, 
                                 category_name = c.category_name, 
                                 units_in_stock = p.units_in_stock
                             };
                return result.ToList();
            }
        }
    }
}
