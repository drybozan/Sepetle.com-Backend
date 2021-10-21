using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal iProductDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal iProductDal,ICategoryService icategoryService) //kendinden başka bir Dal classını enjekte etmez ama başka bir classın servisini enjekte edebilir
        {
            this.iProductDal = iProductDal;
            _categoryService = icategoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))] //aspect
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //en altta yazılan iş kurallarını çalıştıracak
           IResult result= BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.category_id), 
                              CheckIfProductNameExist(product.product_name),
                              CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result; //kurallara uymayanı döndür
            }

            iProductDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(iProductDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(iProductDal.GetAll(p => p.category_id == id));
        }

        [CacheAspect]
        //[PerformanceAspect(5)] //bu metotun çalışması 5 sn yi geçince beni uyar
        public IDataResult<Product> GetById(int productId)
        {
            //Thread.Sleep(5000);
            return new SuccessDataResult<Product>(iProductDal.Get(p => p.product_id == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(double min, double max)
        {
            return new SuccessDataResult<List<Product>>(iProductDal.GetAll(p => p.unit_price >= min && p.unit_price <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(iProductDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")] //bu servisin get ile başlayan tüm metotların datalrını bellekten uçur
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.category_id).Success)
            {
                iProductDal.Update(product);

                return new SuccessResult("Ürün bilgileri güncellendi");
            }

            return new ErrorResult();
           
           
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            iProductDal.Update(product);
            iProductDal.Add(product);
            return new SuccessResult("Ürün güncellendi.");
        }

        //birden fazla mettota kullanacak operasyonlar burda en alta yazılır
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = iProductDal.GetAll(p => p.category_id == categoryId).Count;
            if(result >= 15)
            {
                return new ErrorResult("Bu kategoride en fazla 15 ürün üzerinde işlem yapabilirsiniz.");
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = iProductDal.GetAll(p => p.product_name == productName).Any();//bu şarta uygun data varsa getir, işlevini görür Any()
            if (result ) //sonuc doğru
            {
                return new ErrorResult("Bu isimde ürün zaten var.");
            }
            return new SuccessResult();
        }


        //category servisini kullandık dikkat!
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15) //sonuc doğru
            {
                return new ErrorResult("Category sayısı 15 i geçemez.");
            }
            return new SuccessResult();
        }

       
    }
}
