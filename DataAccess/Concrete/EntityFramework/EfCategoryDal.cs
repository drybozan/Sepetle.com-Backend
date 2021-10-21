using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        //ICategoryDal içindeki tüm operasyonlar, EfEntityRepositoryBase<Category,NorthwindContext> içinde tanımlıdır.
        // O zaman ICategoryDal' a ne gerek var gibi düşünülebilir ama Category e özel operasyonlar ICategoryDal içinde tanımlayacağız
    }
}
