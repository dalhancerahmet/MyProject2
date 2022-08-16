using Business.Abstract;
using Business.Contants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
           IResult result= BusinessRules.Run(CheckNameOfCategory(category.CategoryName));
            if (result!=null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public int CategoryCount()
        {
            return _categoryDal.GetAll().Count();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        private IResult CheckNameOfCategory(string categoryName)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryName).Count();
            if (result > 0)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExist);
            }
            else
            {
                return new SuccessResult(Messages.CategoryAdded);
            }
        }
    }
}
