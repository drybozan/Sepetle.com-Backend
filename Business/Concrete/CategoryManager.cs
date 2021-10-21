using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal iCategoryDal;

        public CategoryManager(ICategoryDal iCategoryDal)
        {
            this.iCategoryDal = iCategoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Category>>(iCategoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(iCategoryDal.Get(c => c.category_id == categoryId));
        }

      
    }
}
