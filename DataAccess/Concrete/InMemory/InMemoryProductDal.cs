using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;


        //Oracle,sql,postgres,mongoDb
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product{product_id=1,category_id=1,product_name="Bardak",unit_price=45,units_in_stock=15},
                new Product{product_id=2,category_id=1,product_name="Tabak",unit_price=85,units_in_stock=15},
                new Product{product_id=3,category_id=2,product_name="masa",unit_price=485,units_in_stock=15},
                new Product{product_id=4,category_id=2,product_name="Fare",unit_price=465,units_in_stock=15},
               
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LİNQ -->Language ıntegrated query
            Product productToDelete = _products.SingleOrDefault(p=>p.product_id == product.product_id); //p,_product'ın takma ismi
                                                                                                     //SingleOrDefault(), bir ürünü tek tek arar

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.category_id == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
           //gönderdiğim ürün id'sine sahip olan listedeki ürünü bul demek
            Product productToUpdate = _products.SingleOrDefault(p => p.product_id == product.product_id);
            productToUpdate.product_name = product.product_name;
            productToUpdate.category_id = product.category_id;
            productToUpdate.unit_price = product.unit_price;
            productToUpdate.units_in_stock = product.units_in_stock;
        }
    }
}
